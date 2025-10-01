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
    public partial class frm_DetalleCompra : Form
    {
        private NegocioDetalleCompra negocioDetalle = new NegocioDetalleCompra();
        private List<DetalleCompra> listar;
        private Compra productoSeleccionado;

        public frm_DetalleCompra(Compra compra)
        {
            InitializeComponent();
            productoSeleccionado = compra;
        }

        private void CargarLista()
        {
            listar = negocioDetalle.ListarDetalle(productoSeleccionado.id);
            dgv_listarDetalle.DataSource = listar;
            FormatoDetalleCompra();
        }

        private void FormatoDetalleCompra()
        {
            dgv_listarDetalle.Columns["id"].Visible = false;
            dgv_listarDetalle.Columns["compra"].Visible = false;
            dgv_listarDetalle.Columns["producto"].Width = 250;
            dgv_listarDetalle.Columns["producto"].HeaderText = "PRODUCTO";
            dgv_listarDetalle.Columns["producto"].DisplayIndex = 0;
            dgv_listarDetalle.Columns["marca"].Width = 220;
            dgv_listarDetalle.Columns["marca"].HeaderText = "MARCA";
            dgv_listarDetalle.Columns["marca"].DisplayIndex = 1;
            dgv_listarDetalle.Columns["empaqueDescripcion"].Width = 150;
            dgv_listarDetalle.Columns["empaqueDescripcion"].HeaderText = "EMPAQUE";
            dgv_listarDetalle.Columns["empaqueDescripcion"].DisplayIndex = 2;
            dgv_listarDetalle.Columns["cantidad"].Width = 130;
            dgv_listarDetalle.Columns["cantidad"].HeaderText = "CANTIDAD";
            dgv_listarDetalle.Columns["cantidad"].DisplayIndex = 3;
            dgv_listarDetalle.Columns["precioCompra"].Width = 160;
            dgv_listarDetalle.Columns["precioCompra"].HeaderText = "PRECIO COMPRA";
            dgv_listarDetalle.Columns["precioCompra"].DisplayIndex = 4;
            dgv_listarDetalle.Columns["subTotal"].Width = 130;
            dgv_listarDetalle.Columns["subTotal"].HeaderText = "SUBTOTAL";
            dgv_listarDetalle.Columns["subTotal"].DisplayIndex = 5;
        }

        private void frm_DetalleCompra_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
