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
        private NegocioUnidadMedida negocioUnidadMedida = new NegocioUnidadMedida();
        private NegocioStockProducto negocioStock = new NegocioStockProducto();
        private List<Producto> listar;
        private List<Categoria> listarC;
        private List<Marca> listarM;
        private List<UnidadMedida> listarUM;
        private int categoriaSeleccionadaId = 0;
        private int marcaSeleccionadaId = 0;
        private int medidaSeleccionadaId = 0;
        int stock = 0;
        decimal precioD = 0;
        decimal precioN = 0;
        private bool editar = false;
        private int idEditar = 0;

        public frm_Producto()
        {
            InitializeComponent();
        }

        private void CargarLista()
        {
            listar = negocioProducto.ListarProducto();
            dgv_Principal.DataSource = listar;
            FormatoProducto();
        }

        private void FormatoProducto()
        {
            dgv_Principal.Columns[0].Visible = false;
            dgv_Principal.Columns[1].Width = 200;
            dgv_Principal.Columns[1].HeaderText = "CODIGO BARRA";
            dgv_Principal.Columns[2].Width = 150;
            dgv_Principal.Columns[2].HeaderText = "CATEGORIA";
            dgv_Principal.Columns[3].Width = 150;
            dgv_Principal.Columns[3].HeaderText = "MARCA";
            dgv_Principal.Columns[4].Width = 100;
            dgv_Principal.Columns[4].HeaderText = "MEDIDA";
            dgv_Principal.Columns[5].Width = 250;
            dgv_Principal.Columns[5].HeaderText = "DESCRIPCION";
            dgv_Principal.Columns[6].Width = 100;
            dgv_Principal.Columns[6].HeaderText = "STOCK MIN";
            dgv_Principal.Columns[7].Width = 120;
            dgv_Principal.Columns[7].HeaderText = "STOCK MAX";
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
        }

        private void frm_Producto_Load(object sender, EventArgs e)
        {
            CargarLista();
            CargarListaCategoria();
            CargarListaMarca();
            CargarListaMedida();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Producto_dc.Text = "";
            txt_CodigoBarra.ReadOnly = false;
            txt_Producto_dc.ReadOnly = false;
            txt_Stockmin.ReadOnly = false;
            txt_Stockmax.ReadOnly = false;
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
                txt_Stockmax.Text = seleccionada.stock_max.ToString();
                txt_Categoria.Text = seleccionada.categoria.descripcion;
                txt_Marca.Text = seleccionada.marca.descripcion;
                txt_Medida.Text = seleccionada.unidad.descripcion;

                categoriaSeleccionadaId = seleccionada.categoria.id;
                marcaSeleccionadaId = seleccionada.marca.id;
                medidaSeleccionadaId = seleccionada.unidad.id;

                txt_CodigoBarra.ReadOnly = false;
                txt_Producto_dc.ReadOnly = false;
                txt_Stockmin.ReadOnly = false;
                txt_Stockmax.ReadOnly = false;
                              
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

                    negocioProducto.EliminarProducto(idEliminar);

                    MessageBox.Show("Producto eliminado correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string cogo_barra = txt_CodigoBarra.Text.Trim();
            string stock_min = txt_Stockmin.Text.Trim();
            string stock_max = txt_Stockmax.Text.Trim();
            string descripcion = txt_Producto_dc.Text.Trim();

           
                        
            if (!decimal.TryParse(stock_min, out decimal stockMinDecimal) ||
                !decimal.TryParse(stock_max, out decimal stockMaxDecimal))
            {
                MessageBox.Show("Stock mínimo y máximo deben ser números válidos.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cogo_barra) || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(stock_min) || string.IsNullOrWhiteSpace(stock_max) || string.IsNullOrWhiteSpace(txt_Categoria.Text) ||
                 string.IsNullOrWhiteSpace(txt_Marca.Text) || string.IsNullOrWhiteSpace(txt_Medida.Text))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Producto producto = new Producto();

                producto.codigoBarra = cogo_barra;
                producto.descripcion = descripcion;
                producto.stock_min = decimal.Parse(stock_min);
                producto.stock_max = decimal.Parse(stock_max);
                producto.categoria.id = categoriaSeleccionadaId;
                producto.marca.id = marcaSeleccionadaId;
                producto.unidad.id = medidaSeleccionadaId;

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
                txt_Stockmax.Text = "";
                txt_Categoria.Text = "";
                txt_Marca.Text = "";
                txt_Medida.Text = "";
                txt_CodigoBarra.ReadOnly = true;
                txt_Producto_dc.ReadOnly = true;
                txt_Stockmin.ReadOnly = true;
                txt_Stockmax.ReadOnly = true;
                categoriaSeleccionadaId = 0;
                marcaSeleccionadaId = 0;
                medidaSeleccionadaId = 0;
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
            txt_Stockmax.Text = "";
            txt_Categoria.Text = "";
            txt_Marca.Text = "";
            txt_Medida.Text = "";
            txt_CodigoBarra.ReadOnly = true; 
            txt_Producto_dc.ReadOnly = true;
            txt_Stockmin.ReadOnly = true;
            txt_Stockmax.ReadOnly = true;
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
            dgv_Categorias.Columns[0].Visible = false;
            dgv_Categorias.Columns[1].Width = 250;
            dgv_Categorias.Columns[1].HeaderText = "CATEGORIAS";
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
            dgv_Marcas.Columns[0].Visible = false;
            dgv_Marcas.Columns[1].Width = 250;
            dgv_Marcas.Columns[1].HeaderText = "MARCAS";
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

        private void btn_LupaMedida_Click(object sender, EventArgs e)
        {
            pnl_ListadoUM.Location = btn_LupaCategoria.Location;
            pnl_ListadoUM.Visible = true;
        }

        private void CargarListaMedida()
        {
            listarUM = negocioUnidadMedida.ListarUnidad();
            dgv_UnidadMedida.DataSource = listarUM;
            FormatoMedida();
        }

        private void FormatoMedida()
        {
            dgv_UnidadMedida.Columns[0].Visible = false;
            dgv_UnidadMedida.Columns[1].Visible = false;
            dgv_UnidadMedida.Columns[2].Width = 250;
            dgv_UnidadMedida.Columns[2].HeaderText = "UNIDAD MEDIDA";
        }

        private void SelecionUnidadMedida()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgv_UnidadMedida.CurrentRow.Cells[0].Value)))
            {
                MessageBox.Show("No se tiene la información para Visualizar", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                medidaSeleccionadaId = Convert.ToInt32(dgv_UnidadMedida.CurrentRow.Cells[0].Value);
                txt_Medida.Text = Convert.ToString(dgv_UnidadMedida.CurrentRow.Cells[2].Value);
            }
        }

        private void dgv_UnidadMedida_DoubleClick(object sender, EventArgs e)
        {
            SelecionUnidadMedida();
            pnl_ListadoUM.Visible = false;
        }

        private void btn_RetornarC_Click(object sender, EventArgs e)
        {
            pnl_ListadoCategoria.Visible = false;
        }

        private void btn_RetornarM_Click(object sender, EventArgs e)
        {
            pnl_ListadoMarca.Visible = false;
        }

        private void btn_RetornarUM_Click(object sender, EventArgs e)
        {
            pnl_ListadoUM.Visible = false;
        }
    }
}
