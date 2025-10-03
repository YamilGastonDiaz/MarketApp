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
    public partial class frm_ReporteHistorial : Form
    {
        public frm_ReporteHistorial()
        {
            InitializeComponent();
            CargarComboBoxProductos();
        }

        private void CargarComboBoxProductos()
        {
            NegocioProducto negocio = new NegocioProducto();
            List<Producto> listaProductos = negocio.ListarProducto();

            cbox_Producto.DataSource = listaProductos;
            cbox_Producto.DisplayMember = "descripcion";
            cbox_Producto.ValueMember = "id";

            cbox_Producto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbox_Producto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txt_Buscar_Click(object sender, EventArgs e)
        {
            if (cbox_Producto.SelectedValue != null)
            {
                int id = Convert.ToInt32(cbox_Producto.SelectedValue);
                Reportes.frm_HistorialCompra rptHistorial = new Reportes.frm_HistorialCompra();
                rptHistorial.id_Producto = id;
                rptHistorial.ShowDialog();
            }
            else
            {
                MessageBox.Show("Porfavor seleccione un producto");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
