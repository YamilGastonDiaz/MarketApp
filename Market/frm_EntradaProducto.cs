using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market
{
    public partial class frm_EntradaProducto : Form
    {
        private DataTable TablaDetalle;
        private NegocioProducto negocioProducto = new NegocioProducto();
        private NegocioProveedor negocioProveedor = new NegocioProveedor();
        private NegocioCompra negocioCompra = new NegocioCompra();
        private NegocioDetalleCompra negocioDetalle = new NegocioDetalleCompra();
        private NegocioStockProducto negocioStock = new NegocioStockProducto();
        private List<Producto> listar;
        private List<Proveedor> proveedorLista;
        private List<Compra> compraLista;
        private int proveedorSeleccionadoId = 0;
        private const string PlaceholderTexto = "INGRESE NOMBRE";
        private const string PlaceholderTexto1 = "INGRESE DESCRIPCION";
        private const string PlaceholderTexto2 = "INGRESE EMPRESA";

        public frm_EntradaProducto()
        {
            InitializeComponent();
            TextBoxPlaceholder.SetPlaceholder(txt_Buscar, PlaceholderTexto);
            TextBoxPlaceholder.SetPlaceholder(txt_Producto, PlaceholderTexto1);
            TextBoxPlaceholder.SetPlaceholder(txt_ProveedorB, PlaceholderTexto2);

            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
            txt_Producto.CharacterCasing = CharacterCasing.Upper;
            txt_ProveedorB.CharacterCasing = CharacterCasing.Upper;
        }

        private void CargarLista()
        {
            compraLista = negocioCompra.ListarCompra();
            dgv_Principal.DataSource = compraLista;
            FormatoEntradaProducto();
        }

        private void FormatoEntradaProducto()
        {
            dgv_Principal.Columns["id"].Width = 100;
            dgv_Principal.Columns["id"].HeaderText = "ID";
            dgv_Principal.Columns["proveedor"].Width = 280;
            dgv_Principal.Columns["proveedor"].HeaderText = "PROVEEDOR";
            dgv_Principal.Columns["fecha"].Width = 150;
            dgv_Principal.Columns["fecha"].HeaderText = "FECHA";
            dgv_Principal.Columns["precioTotal"].Width = 150;
            dgv_Principal.Columns["precioTotal"].HeaderText = "PRECIO TOTAL";
        }

        private void EstadoBtnPrincipales(bool estado)
        {
            btn_Nuevo.Enabled = estado;
            btn_Elimiar.Enabled = estado;
            btn_Salir.Enabled = estado;
        }

        private void EstadoBtnProcesos(bool estado)
        {
            btn_Cancelar.Visible = estado;
            btn_Guardar.Visible = estado;
            btn_Agregar.Visible = estado;
            btn_Quitar.Visible = estado;
            btn_LupaProveedor.Visible = estado;
        }

        private void frm_EntradaProducto_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarListaProveedor();
            CargarListaProducto();
            CargarListaDetalle();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Proveedor.Text = "";
            dgv_ListaDetalle.Columns["Cantidad"].ReadOnly = false;
            dgv_ListaDetalle.Columns["PrecioCompra"].ReadOnly = false;
            txt_Proveedor.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Proveedor.Focus();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para editar.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    Compra seleccionada = (Compra)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioCompra.EliminarCompra(idEliminar);

                    MessageBox.Show("Compra eliminada correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string descripcion = txt_Proveedor.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion) || proveedorSeleccionadoId == 0)
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (TablaDetalle.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto al detalle.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Total.Text) || Convert.ToDecimal(txt_Total.Text) <= 0)
            {
                MessageBox.Show("El total no puede estar vacío o en cero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Compra compra = new Compra();
            compra.proveedor = new Proveedor();
            compra.proveedor.id = proveedorSeleccionadoId;
            compra.fecha = dtp_Fecha.Value;
            compra.precioTotal = Convert.ToDecimal(txt_Total.Text);

            DataTable tablaSP = ConvertirTablaParaSP(TablaDetalle);
            int idCompra = negocioCompra.AgregarCompraConDetalles(compra, tablaSP);

            MessageBox.Show("Compra registrada correctamente con ID: " + idCompra, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


            TablaDetalle.Clear();
            CargarLista();
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            txt_Proveedor.Text = "";
            txt_Proveedor.ReadOnly = true;

            tab_Principal.SelectedIndex = 0;
        }

        private DataTable ConvertirTablaParaSP(DataTable tablaDetalle)
        {
            DataTable tablaSP = new DataTable();
            tablaSP.Columns.Add("id_Producto", typeof(int));
            tablaSP.Columns.Add("id_Marca", typeof(int));
            tablaSP.Columns.Add("Cantidad", typeof(decimal));
            tablaSP.Columns.Add("StockCalculado", typeof(decimal));
            tablaSP.Columns.Add("PrecioCompra", typeof(decimal));
            tablaSP.Columns.Add("Subtotal", typeof(decimal));

            foreach (DataRow fila in tablaDetalle.Rows)
            {
                int idProducto = Convert.ToInt32(fila["id_Producto"]);
                int idMarca = Convert.ToInt32(fila["id_Marca"]);
                decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
                decimal stockCalculado = Convert.ToDecimal(fila["Stock"]);
                decimal precio = Convert.ToDecimal(fila["PrecioCompra"]);
                decimal subtotal = Convert.ToDecimal(fila["Subtotal"]);

                tablaSP.Rows.Add(idProducto, idMarca, cantidad, stockCalculado, precio, subtotal);
            }

            return tablaSP;
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Proveedor.Text = "";
            txt_Proveedor.ReadOnly = true;
            dgv_ListaDetalle.Columns["Cantidad"].ReadOnly = true;
            dgv_ListaDetalle.Columns["PrecioCompra"].ReadOnly = true;
            TablaDetalle.Clear();
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }

        private void dgv_Principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Compra compraSeleccionado = (Compra)dgv_Principal.Rows[e.RowIndex].DataBoundItem;

                frm_DetalleCompra detalleForm = new frm_DetalleCompra(compraSeleccionado);
                detalleForm.ShowDialog();
            }
        }

        private void btn_LupaProveedor_Click(object sender, EventArgs e)
        {
            pnl_ListadoProveedor.Location = btn_LupaProveedor.Location;
            pnl_ListadoProveedor.Visible = true;
        }

        private void CargarListaDetalle()
        {
            CrearTablaDetalle();
        }

        private void CrearTablaDetalle()
        {
            TablaDetalle = new DataTable("TablaDetalle");

            TablaDetalle.Columns.Add("id_Producto", typeof(int));
            TablaDetalle.Columns.Add("descripcion_P", typeof(string));
            TablaDetalle.Columns.Add("id_Marca", typeof(string));
            TablaDetalle.Columns.Add("descripcion_M", typeof(string));
            TablaDetalle.Columns.Add("Empaque", typeof(string)); 
            TablaDetalle.Columns.Add("TotalEmpaque", typeof(decimal));
            TablaDetalle.Columns.Add("Cantidad", typeof(decimal));
            TablaDetalle.Columns.Add("Stock", typeof(decimal));   
            TablaDetalle.Columns.Add("PrecioCompra", typeof(decimal));
            TablaDetalle.Columns.Add("Subtotal", typeof(decimal));

            dgv_ListaDetalle.DataSource = TablaDetalle;
            FormatoDetalle();
        }

        private void FormatoDetalle()
        {
            dgv_ListaDetalle.Columns["id_Producto"].Visible = false;
            dgv_ListaDetalle.Columns["id_Marca"].Visible = false;
            dgv_ListaDetalle.Columns["TotalEmpaque"].Visible = false;

            dgv_ListaDetalle.Columns["descripcion_P"].Width = 280;
            dgv_ListaDetalle.Columns["descripcion_P"].HeaderText = "PRODUCTO";
            dgv_ListaDetalle.Columns["descripcion_M"].Width = 200;
            dgv_ListaDetalle.Columns["descripcion_M"].HeaderText = "MARCA";
            dgv_ListaDetalle.Columns["Empaque"].Width = 100;
            dgv_ListaDetalle.Columns["Empaque"].HeaderText = "EMPAQUE";
            dgv_ListaDetalle.Columns["Cantidad"].Width = 100;
            dgv_ListaDetalle.Columns["Cantidad"].HeaderText = "CANTIDAD";
            dgv_ListaDetalle.Columns["Stock"].Width = 100;
            dgv_ListaDetalle.Columns["Stock"].HeaderText = "STOCK";
            dgv_ListaDetalle.Columns["PrecioCompra"].Width = 160;
            dgv_ListaDetalle.Columns["PrecioCompra"].HeaderText = "PRECIO COMPRA";
            dgv_ListaDetalle.Columns["Subtotal"].Width = 130;
            dgv_ListaDetalle.Columns["Subtotal"].HeaderText = "SUBTOTAL";

            dgv_ListaDetalle.Columns["descripcion_P"].ReadOnly = true;
            dgv_ListaDetalle.Columns["descripcion_M"].ReadOnly = true;
            dgv_ListaDetalle.Columns["Empaque"].ReadOnly = true;
            dgv_ListaDetalle.Columns["Stock"].ReadOnly = true;
            dgv_ListaDetalle.Columns["Cantidad"].ReadOnly = true;
            dgv_ListaDetalle.Columns["PrecioCompra"].ReadOnly = true;
            dgv_ListaDetalle.Columns["Subtotal"].ReadOnly = true;
        }

        private void AgregarItem(Producto producto, Marca marca, Empaque empaque, decimal cantidad, decimal precioCompra, decimal subTotal)
        {
            DataRow fila = TablaDetalle.NewRow();
            fila["id_Producto"] = producto.id;
            fila["descripcion_P"] = producto.descripcion;
            fila["id_Marca"] = marca.id;
            fila["descripcion_M"] = marca.descripcion;
            fila["Empaque"] = empaque.descripcion;
            fila["TotalEmpaque"] = empaque.cantidadxUnidad;
            fila["Cantidad"] = cantidad;
            fila["Stock"] = 0;
            fila["PrecioCompra"] = precioCompra;
            fila["Subtotal"] = subTotal;

            TablaDetalle.Rows.Add(fila);
            TablaDetalle.AcceptChanges();
        }

        private void CargarListaProveedor()
        {
            proveedorLista = negocioProveedor.ListarProveedor();
            dgv_Proveedor.DataSource = proveedorLista;
            FormatoProveedor();
        }

        private void FormatoProveedor()
        {
            dgv_Proveedor.Columns["id"].Visible = false;
            dgv_Proveedor.Columns["nombre"].Width = 200;
            dgv_Proveedor.Columns["nombre"].HeaderText = "NOMBRE";
            dgv_Proveedor.Columns["cuit"].Visible = false;
            dgv_Proveedor.Columns["direccion"].Visible = false;
            dgv_Proveedor.Columns["telefono"].Visible = false;
            dgv_Proveedor.Columns["mail"].Visible = false;
            dgv_Proveedor.Columns["empresa"].Width = 200;
            dgv_Proveedor.Columns["empresa"].HeaderText = "EMPRESA";
        }

        private void SelecionProveedor()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Proveedor.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                proveedorSeleccionadoId = Convert.ToInt32(dgv_Proveedor.CurrentRow.Cells[0].Value);
                txt_Proveedor.Text = Convert.ToString(dgv_Proveedor.CurrentRow.Cells[1].Value);
            }
        }

        private void dgv_Proveedor_DoubleClick(object sender, EventArgs e)
        {
            SelecionProveedor();
            pnl_ListadoProveedor.Visible = false;
        }

        private void btn_RetornarP_Click(object sender, EventArgs e)
        {
            pnl_ListadoProveedor.Visible = false;
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            pnl_ListaProducto.Location = btn_Agregar.Location;
            pnl_ListaProducto.Visible = true;
        }

        private void CargarListaProducto()
        {
            listar = negocioProducto.ListarProducto();

            var listaMostrar = listar.Select(p => new
            {
                id = p.id,
                descripcion = p.descripcion,
                codigoBarra = p.codigoBarra,
                categoria = p.categoria.descripcion,
                idCategoria = p.categoria.id,
                marca = p.marca.descripcion,
                idMarca = p.marca.id,
                idEmpaque = p.empaque.id,
                totalEmpaque = p.empaque.cantidadxUnidad,
                empaque = p.empaque.descripcion,
                stock_min = p.stock_min,
            }).ToList();

            dgv_Producto.DataSource = listaMostrar;

            FormatoProducto();
        }

        private void FormatoProducto()
        {
            dgv_Producto.Columns["id"].Visible = false;
            dgv_Producto.Columns["codigoBarra"].Visible = false;
            dgv_Producto.Columns["idCategoria"].Visible = false;
            dgv_Producto.Columns["idMarca"].Visible = false;
            dgv_Producto.Columns["idEmpaque"].Visible = false;
            dgv_Producto.Columns["stock_min"].Visible = false;
            dgv_Producto.Columns["totalEmpaque"].Visible = false;

            dgv_Producto.Columns["descripcion"].Width = 250;
            dgv_Producto.Columns["descripcion"].HeaderText = "PRODUCTO";
            dgv_Producto.Columns["categoria"].Width = 200;
            dgv_Producto.Columns["categoria"].HeaderText = "CATEGORIA";
            dgv_Producto.Columns["marca"].Width = 200;
            dgv_Producto.Columns["marca"].HeaderText = "MARCA";
            dgv_Producto.Columns["empaque"].Width = 150;
            dgv_Producto.Columns["empaque"].HeaderText = "TOTAL X CAJA";
        }

        private void SelecionProducto()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Producto.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Producto producto = new Producto();
                Marca marca = new Marca();
                Empaque empaque = new Empaque();
                decimal cantidad;
                decimal precioCompra;
                decimal subTotal;

                bool agregar = true;

                producto.id = Convert.ToInt32(dgv_Producto.CurrentRow.Cells["id"].Value);

                foreach (DataRow fila in TablaDetalle.Rows)
                {
                    if (Convert.ToInt32(fila["id_Producto"]) == producto.id)
                    {
                        agregar = false;
                        MessageBox.Show("El producto ya se encuentra agregado", "Aviso del Sistema");
                    }
                }

                if (agregar)
                {
                    producto.descripcion = Convert.ToString(dgv_Producto.CurrentRow.Cells["descripcion"].Value);

                    marca.id = Convert.ToInt32(dgv_Producto.CurrentRow.Cells["idMarca"].Value);
                    marca.descripcion = Convert.ToString(dgv_Producto.CurrentRow.Cells["marca"].Value);
                    empaque.descripcion = Convert.ToString(dgv_Producto.CurrentRow.Cells["empaque"].Value);
                    empaque.cantidadxUnidad = Convert.ToDecimal(dgv_Producto.CurrentRow.Cells["totalEmpaque"].Value);
                    cantidad = 0;
                    precioCompra = 0;
                    subTotal = 0;


                    AgregarItem(producto, marca, empaque, cantidad, precioCompra, subTotal);
                }
            }
        }

        private void dgv_Producto_DoubleClick(object sender, EventArgs e)
        {
            SelecionProducto();
            pnl_ListaProducto.Visible = false;
        }

        private void btn_RetornarPR_Click(object sender, EventArgs e)
        {
            pnl_ListaProducto.Visible = false;
        }

        private void CalcularTotalDetalle()
        {
            decimal totalImporte = 0;

            if (dgv_ListaDetalle.Rows.Count == 0)
            {
                totalImporte = 0;
            }
            else
            {
                TablaDetalle.AcceptChanges();
                foreach (DataRow fila in TablaDetalle.Rows)
                {
                    totalImporte = totalImporte + Convert.ToDecimal(fila["Subtotal"]);
                }

                txt_Total.Text = Convert.ToString(totalImporte);
            }
        }

        private void dgv_ListaDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRow fila = ((DataRowView)dgv_ListaDetalle.Rows[e.RowIndex].DataBoundItem).Row;

            decimal cantidad = 0;
            decimal precio = 0;
            decimal totalEmpaque = 0;

            decimal.TryParse(fila["Cantidad"]?.ToString(), out cantidad);
            decimal.TryParse(fila["PrecioCompra"]?.ToString(), out precio);
            decimal.TryParse(fila["TotalEmpaque"]?.ToString(), out totalEmpaque);

            fila["Subtotal"] = decimal.Round(cantidad * precio, 2).ToString("N2");
            fila["Stock"] = decimal.Round(cantidad * totalEmpaque, 2);

            CalcularTotalDetalle();
        }

        private void btn_Quitar_Click(object sender, EventArgs e)
        {
            if (dgv_ListaDetalle.Rows.Count > 0)
            {
                if (dgv_ListaDetalle.CurrentRow != null)
                {
                    dgv_ListaDetalle.Rows.Remove(dgv_ListaDetalle.CurrentRow);
                    dgv_ListaDetalle.Refresh();
                    TablaDetalle.AcceptChanges();
                    CalcularTotalDetalle();
                }
            }
        }

        private void dgv_ListaDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgv_ListaDetalle.CurrentCell.ColumnIndex == 4 ||
                dgv_ListaDetalle.CurrentCell.ColumnIndex == 5)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(SoloNumeros_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(SoloNumeros_KeyPress);
                }
            }
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            TextBox txt = sender as TextBox;
            if (e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void dgv_ListaDetalle_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Ingrese solo valores numéricos en esta columna.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = true;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string texto = txt_Buscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || texto == PlaceholderTexto)
            {
                CargarLista();
                return;
            }
            else 
            {
                dgv_Principal.DataSource = negocioCompra.BuscarPorNombre(texto);
            }
        }

        private void btn_BuscarPR_Click(object sender, EventArgs e)
        {
            string texto = txt_Producto.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || texto == PlaceholderTexto1)
            {
                CargarListaProducto();
                return;
            }
            else
            {
                dgv_Producto.DataSource = negocioProducto.BuscarPorDescripcion(texto);
            }   
        }

        private void btn_BuscarP1_Click(object sender, EventArgs e)
        {
            string texto = txt_ProveedorB.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || texto == PlaceholderTexto2)
            {
                CargarListaProveedor();
            }
            else 
            {
                dgv_Proveedor.DataSource = negocioProveedor.BuscarPorEmpresa(texto);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
