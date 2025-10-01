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
using System.Windows.Media.Media3D;

namespace Market
{
    public partial class frm_VentaDetalle : Form
    {
        private NegocioDetalleVenta negocioDetalle = new NegocioDetalleVenta();
        private List<DetalleVenta> listar;
        private Venta productoSeleccionado;

        public frm_VentaDetalle(Venta venta)
        {
            InitializeComponent();
            productoSeleccionado = venta;
        }

        private void CargarLista()
        {
            listar = negocioDetalle.ListarDetalle(productoSeleccionado.id);
            dgv_listarDetalle.DataSource = listar;
            FormatoDetalleVenta();
        }

        private void FormatoDetalleVenta()
        {
            dgv_listarDetalle.Columns["id"].Visible = false;
            dgv_listarDetalle.Columns["venta"].Visible = false;
            dgv_listarDetalle.Columns["producto"].Width = 250;
            dgv_listarDetalle.Columns["producto"].HeaderText = "PRODUCTO";
            dgv_listarDetalle.Columns["marca"].Width = 220;
            dgv_listarDetalle.Columns["marca"].HeaderText = "MARCA";
            dgv_listarDetalle.Columns["cantidad"].Width = 130;
            dgv_listarDetalle.Columns["cantidad"].HeaderText = "CANTIDAD";
            dgv_listarDetalle.Columns["precioVenta"].Width = 160;
            dgv_listarDetalle.Columns["precioVenta"].HeaderText = "PRECIO VENTA";
            dgv_listarDetalle.Columns["subTotal"].Width = 130;
            dgv_listarDetalle.Columns["subTotal"].HeaderText = "SUBTOTAL";
        }

        private void frm_VentaDetalle_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
