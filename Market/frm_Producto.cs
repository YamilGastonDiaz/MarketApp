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

namespace Market
{
    public partial class frm_Producto : Form
    {
        private NegocioProducto negocioProducto = new NegocioProducto();
        private List<Producto> listar;
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
            FormatoCategoria();
        }

        private void FormatoCategoria()
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
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Producto_dc.Text = "";
            CargarCategoriasEnCombo();
            CargarMarcasEnCombo();
            CargarUnidadEnCombo();
            txt_CodigoBarra.ReadOnly = false;
            txt_Producto_dc.ReadOnly = false;
            txt_Stockmin.ReadOnly = false;
            txt_Stockmax.ReadOnly = false;
            cbox_Categoria.Enabled = true;
            cbox_Marca.Enabled = true;
            cbox_Unidad.Enabled = true;
            tab_Principal.SelectedIndex = 1;
            txt_Producto_dc.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Producto seleccionada = (Producto)dgv_Principal.CurrentRow.DataBoundItem;

                CargarCategoriasEnCombo();
                CargarMarcasEnCombo();
                CargarUnidadEnCombo();

                txt_Producto_dc.Text = seleccionada.descripcion;
                txt_Stockmin.Text = seleccionada.stock_min.ToString();
                txt_Stockmax.Text = seleccionada.stock_max.ToString();

                txt_CodigoBarra.ReadOnly = false;
                txt_Producto_dc.ReadOnly = false;
                txt_Stockmin.ReadOnly = false;
                txt_Stockmax.ReadOnly = false;
                cbox_Categoria.Enabled = true;
                cbox_Marca.Enabled = true;
                cbox_Unidad.Enabled = true;

                cbox_Categoria.Text = seleccionada.categoria.descripcion;
                cbox_Marca.Text = seleccionada.marca.descripcion;
                cbox_Unidad.Text = seleccionada.unidad.descripcion;
                              
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
                    Categoria seleccionada = (Categoria)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioProducto.EliminarProducto(idEliminar);

                    MessageBox.Show("Categoría eliminada correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (cbox_Categoria.SelectedValue == null || cbox_Categoria.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una categoría.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbox_Marca.SelectedValue == null || cbox_Marca.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una marca.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbox_Unidad.SelectedValue == null || cbox_Unidad.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar una unidad de medida.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
                        
            if (!decimal.TryParse(stock_min, out decimal stockMinDecimal) ||
                !decimal.TryParse(stock_max, out decimal stockMaxDecimal))
            {
                MessageBox.Show("Stock mínimo y máximo deben ser números válidos.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cogo_barra) || string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(stock_min) || string.IsNullOrWhiteSpace(stock_max))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Producto producto = new Producto();

                producto.codigoBarra = cogo_barra;
                producto.descripcion = descripcion;
                producto.categoria = (Categoria)cbox_Categoria.SelectedItem;
                producto.marca = (Marca)cbox_Marca.SelectedItem;
                producto.unidad = (UnidadMedida)cbox_Unidad.SelectedItem;
                producto.stock_min = decimal.Parse(stock_min);
                producto.stock_max = decimal.Parse(stock_max);

                if (editar)
                {
                    producto.id = idEditar;
                    negocioProducto.ModificarProducto(producto);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioProducto.AgregarProducto(producto);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_CodigoBarra.Text = "";
                txt_Producto_dc.Text = "";
                txt_Stockmin.Text = "";
                txt_Stockmax.Text = "";
                txt_CodigoBarra.ReadOnly = true;
                txt_Producto_dc.ReadOnly = true;
                txt_Stockmin.ReadOnly = true;
                txt_Stockmax.ReadOnly = true;
                cbox_Categoria.Enabled = false;
                cbox_Marca.Enabled = false;
                cbox_Unidad.Enabled = false;
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
            txt_CodigoBarra.ReadOnly = true; 
            txt_Producto_dc.ReadOnly = true;
            txt_Stockmin.ReadOnly = true;
            txt_Stockmax.ReadOnly = true;
            cbox_Categoria.Enabled = false;
            cbox_Marca.Enabled = false;
            cbox_Unidad.Enabled = false;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }

        private void CargarCategoriasEnCombo()
        {
            NegocioCategoria negocio = new NegocioCategoria();
            List<Categoria> lista = negocio.ListarCategoria();

            cbox_Categoria.DataSource = lista;
            cbox_Categoria.DisplayMember = "descripcion";
            cbox_Categoria.ValueMember = "id";
        }

        private void CargarMarcasEnCombo()
        {
            NegocioMarca negocio = new NegocioMarca();
            List<Marca> lista = negocio.ListarMarca();

            cbox_Marca.DataSource = lista;
            cbox_Marca.DisplayMember = "descripcion";
            cbox_Marca.ValueMember = "id";
        }

        private void CargarUnidadEnCombo()
        {
            NegocioUnidadMedida negocio = new NegocioUnidadMedida();
            List<UnidadMedida> lista = negocio.ListarUnidad();

            cbox_Unidad.DataSource = lista;
            cbox_Unidad.DisplayMember = "descripcion";
            cbox_Unidad.ValueMember = "id";
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
    }
}
