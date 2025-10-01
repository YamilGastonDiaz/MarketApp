using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Market
{
    public partial class frm_Producto : Form
    {
        private NegocioProducto negocioProducto = new NegocioProducto();
        private NegocioCategoria negocioCategoria = new NegocioCategoria();
        private NegocioMarca negocioMarca = new NegocioMarca();
        private NegocioEmpaque negocioEmpaque = new NegocioEmpaque();
        private NegocioStockProducto negocioStock = new NegocioStockProducto();
        private List<Producto> listar;
        private List<Categoria> listarC;
        private List<Marca> listarM;
        private List<Empaque> listarE;
        private int categoriaSeleccionadaId = 0;
        private int marcaSeleccionadaId = 0;
        private int empaqueSeleccionadaId = 0;
        int stock = 0;
        decimal precioD = 0;
        decimal precioN = 0;
        private bool editar = false;
        private int idEditar = 0;

        public frm_Producto()
        {
            InitializeComponent();
            txt_Producto_dc.CharacterCasing = CharacterCasing.Upper;
            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
            txt_BuscarC.CharacterCasing = CharacterCasing.Upper;
            txt_BuscarM.CharacterCasing = CharacterCasing.Upper;
            txt_BuscarE.CharacterCasing = CharacterCasing.Upper;
            txt_Stockmin.KeyPress += SoloNumeros_KeyPress;
            txt_CodigoBarra.KeyPress += SoloNumeros_KeyPress;
        }

        private void CargarLista()
        {
            listar = negocioProducto.ListarProducto();
            dgv_Principal.DataSource = listar;
            FormatoProducto();
        }

        private void FormatoProducto()
        {
            dgv_Principal.Columns["id"].Visible = false;
            dgv_Principal.Columns["codigoBarra"].Width = 150;
            dgv_Principal.Columns["codigoBarra"].HeaderText = "CODIGO BARRA";
            dgv_Principal.Columns["categoria"].Width = 200;
            dgv_Principal.Columns["categoria"].HeaderText = "CATEGORIA";
            dgv_Principal.Columns["marca"].Width = 150;
            dgv_Principal.Columns["marca"].HeaderText = "MARCA";
            dgv_Principal.Columns["empaque"].Width = 100;
            dgv_Principal.Columns["empaque"].HeaderText = "EMPAQUE";
            dgv_Principal.Columns["descripcion"].Width = 300;
            dgv_Principal.Columns["descripcion"].HeaderText = "DESCRIPCION";
            dgv_Principal.Columns["stock_min"].Width = 120;
            dgv_Principal.Columns["stock_min"].HeaderText = "STOCK MIN";
        }

        private void EstadoBtnPrincipales(bool estado)
        {
            btn_Nuevo.Enabled = estado;
            btn_Actualizar.Enabled = estado;
            btn_Elimiar.Enabled = estado;
            btn_Reporte.Enabled = estado;
            btn_Salir.Enabled = estado;
        }

        private void EstadoBtnProcesos(bool estado)
        {
            btn_Cancelar.Visible = estado;
            btn_Guardar.Visible = estado;
            btn_LupaCategoria.Visible = estado;
            btn_LupaMarca.Visible = estado;
            btn_LupaEmpaque.Visible = estado;
        }

        private void frm_Producto_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarListaCategoria();
            CargarListaMarca();
            CargarListaEmpaque();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Producto_dc.Text = "";
            txt_CodigoBarra.ReadOnly = false;
            txt_Producto_dc.ReadOnly = false;
            txt_Stockmin.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Producto_dc.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Producto seleccionada = (Producto)dgv_Principal.CurrentRow.DataBoundItem;

                txt_CodigoBarra.Text = seleccionada.codigoBarra;
                txt_Producto_dc.Text = seleccionada.descripcion;
                txt_Stockmin.Text = seleccionada.stock_min.ToString();
                txt_Categoria.Text = seleccionada.categoria.descripcion;
                txt_Marca.Text = seleccionada.marca.descripcion;
                txt_Empaque.Text = seleccionada.empaque.descripcion;

                categoriaSeleccionadaId = seleccionada.categoria.id;
                marcaSeleccionadaId = seleccionada.marca.id;
                empaqueSeleccionadaId = seleccionada.empaque.id;

                txt_CodigoBarra.ReadOnly = false;
                txt_Producto_dc.ReadOnly = false;
                txt_Stockmin.ReadOnly = false;

                tab_Principal.SelectedIndex = 1;

                editar = true;
                idEditar = seleccionada.id;

                EstadoBtnPrincipales(false);
                EstadoBtnProcesos(true);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    Producto seleccionada = (Producto)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    if (!negocioStock.HayStock(idEliminar))
                    {
                        negocioProducto.EliminarProducto(idEliminar);

                        MessageBox.Show("Producto eliminado correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarLista();
                    }
                    else
                    {
                        MessageBox.Show("No se puede eliminar el producto porque tiene stock asociado.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string cogo_barra = txt_CodigoBarra.Text.Trim();
            string stock_min = txt_Stockmin.Text.Trim();
            string descripcion = txt_Producto_dc.Text.Trim();

            if (negocioProducto.ExisteCodigoBarras(txt_CodigoBarra.Text))
            {
                MessageBox.Show("El codigo de barra ingresado ya se encuentra registrado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(stock_min, out decimal stockMinDecimal))
            {
                MessageBox.Show("Stock mínimo debe ser números válidos.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cogo_barra) || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(stock_min) || string.IsNullOrWhiteSpace(txt_Categoria.Text) ||
                 string.IsNullOrWhiteSpace(txt_Marca.Text) || string.IsNullOrWhiteSpace(txt_Empaque.Text))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Producto producto = new Producto();

                producto.codigoBarra = cogo_barra;
                producto.descripcion = descripcion;
                producto.stock_min = decimal.Parse(stock_min);
                producto.categoria.id = categoriaSeleccionadaId;
                producto.marca.id = marcaSeleccionadaId;
                producto.empaque.id = empaqueSeleccionadaId;

                if (editar)
                {
                    producto.id = idEditar;
                    negocioProducto.ModificarProducto(producto);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    int id = negocioProducto.AgregarProducto(producto);
                    negocioStock.AgregarStockProducto(id, stock, precioD, precioN);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_CodigoBarra.Text = "";
                txt_Producto_dc.Text = "";
                txt_Stockmin.Text = "";
                txt_Categoria.Text = "";
                txt_Marca.Text = "";
                txt_Empaque.Text = "";
                txt_CodigoBarra.ReadOnly = true;
                txt_Producto_dc.ReadOnly = true;
                txt_Stockmin.ReadOnly = true;
                categoriaSeleccionadaId = 0;
                marcaSeleccionadaId = 0;
                empaqueSeleccionadaId = 0;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_CodigoBarra.Text = "";
            txt_Producto_dc.Text = "";
            txt_Stockmin.Text = "";
            txt_Categoria.Text = "";
            txt_Marca.Text = "";
            txt_Empaque.Text = "";
            txt_CodigoBarra.ReadOnly = true;
            txt_Producto_dc.ReadOnly = true;
            txt_Stockmin.ReadOnly = true;
            pnl_ListadoCategoria.Visible = false;
            pnl_ListadoMarca.Visible = false;
            pnl_ListadoEmpaque.Visible = false;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }

        private void dgv_Principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Producto productoSeleccionado = (Producto)dgv_Principal.Rows[e.RowIndex].DataBoundItem;

                frm_StockProducto stockForm = new frm_StockProducto(productoSeleccionado);
                stockForm.ShowDialog();
            }
        }

        private void btn_LupaCategoria_Click(object sender, EventArgs e)
        {
            pnl_ListadoCategoria.Location = btn_LupaCategoria.Location;
            pnl_ListadoCategoria.Visible = true;
        }

        private void CargarListaCategoria()
        {
            listarC = negocioCategoria.ListarCategoria();
            dgv_Categorias.DataSource = listarC;
            FormatoCategoria();
        }

        private void FormatoCategoria()
        {
            dgv_Categorias.Columns["id"].Visible = false;
            dgv_Categorias.Columns["descripcion"].Width = 250;
            dgv_Categorias.Columns["descripcion"].HeaderText = "CATEGORIAS";
        }

        private void SelecionCategoria()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Categorias.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                categoriaSeleccionadaId = Convert.ToInt32(dgv_Categorias.CurrentRow.Cells[0].Value);
                txt_Categoria.Text = Convert.ToString(dgv_Categorias.CurrentRow.Cells[1].Value);
            }
        }

        private void dgv_Categorias_DoubleClick(object sender, EventArgs e)
        {
            SelecionCategoria();
            pnl_ListadoCategoria.Visible = false;
        }

        private void btn_LupaMarca_Click(object sender, EventArgs e)
        {
            pnl_ListadoMarca.Location = btn_LupaCategoria.Location;
            pnl_ListadoMarca.Visible = true;
        }

        private void CargarListaMarca()
        {
            listarM = negocioMarca.ListarMarca();
            dgv_Marcas.DataSource = listarM;
            FormatoMarca();
        }

        private void FormatoMarca()
        {
            dgv_Marcas.Columns["id"].Visible = false;
            dgv_Marcas.Columns["descripcion"].Width = 250;
            dgv_Marcas.Columns["descripcion"].HeaderText = "MARCAS";
        }

        private void SelecionMarca()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Marcas.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                marcaSeleccionadaId = Convert.ToInt32(dgv_Marcas.CurrentRow.Cells[0].Value);
                txt_Marca.Text = Convert.ToString(dgv_Marcas.CurrentRow.Cells[1].Value);
            }
        }

        private void dgv_Marcas_DoubleClick(object sender, EventArgs e)
        {
            SelecionMarca();
            pnl_ListadoMarca.Visible = false;
        }

        private void btn_LupaEmpaque_Click(object sender, EventArgs e)
        {
            pnl_ListadoEmpaque.Location = btn_LupaCategoria.Location;
            pnl_ListadoEmpaque.Visible = true;
        }

        private void CargarListaEmpaque()
        {
            listarE = negocioEmpaque.ListarEmpaque();
            dgv_Empaque.DataSource = listarE;
            FormatoEmpaque();
        }

        private void FormatoEmpaque()
        {
            dgv_Empaque.Columns["id"].Visible = false;
            dgv_Empaque.Columns["descripcion"].Width = 250;
            dgv_Empaque.Columns["descripcion"].HeaderText = "EMPAQUE";
            dgv_Empaque.Columns["cantidadxUnidad"].Visible = false;
        }

        private void SelecionEmpaque()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_Empaque.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                empaqueSeleccionadaId = Convert.ToInt32(dgv_Empaque.CurrentRow.Cells[0].Value);
                txt_Empaque.Text = Convert.ToString(dgv_Empaque.CurrentRow.Cells[1].Value);
            }
        }

        private void dgv_Empaque_DoubleClick(object sender, EventArgs e)
        {
            SelecionEmpaque();
            pnl_ListadoEmpaque.Visible = false;
        }

        private void btn_RetornarC_Click(object sender, EventArgs e)
        {
            pnl_ListadoCategoria.Visible = false;
        }

        private void btn_RetornarM_Click(object sender, EventArgs e)
        {
            pnl_ListadoMarca.Visible = false;
        }

        private void btn_RetortnarE_Click(object sender, EventArgs e)
        {
            pnl_ListadoEmpaque.Visible = false;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            dgv_Principal.DataSource = negocioProducto.BuscarPorDescripcion(txt_Buscar.Text);
        }

        private void btn_BuscarC1_Click(object sender, EventArgs e)
        {
            dgv_Categorias.DataSource = negocioCategoria.BuscarPorDescripcion(txt_BuscarC.Text);
        }

        private void btn_BuscarM1_Click(object sender, EventArgs e)
        {
            dgv_Marcas.DataSource = negocioMarca.BuscarPorDescripcion(txt_BuscarM.Text);
        }

        private void btn_BuscarE1_Click(object sender, EventArgs e)
        {
            dgv_Empaque.DataSource = negocioEmpaque.BuscarPorDescripcion(txt_BuscarE.Text);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txt_CodigoBarra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (negocioProducto.ExisteCodigoBarras(txt_CodigoBarra.Text))
                    MessageBox.Show("El codigo de barra ingresado ya se encuentra registrado", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
