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
            FormatoCategoria();
        }

        private void FormatoCategoria()
        {
            dgv_listarDetalle.Columns[0].Visible = false;
            dgv_listarDetalle.Columns[1].Visible = false;
            dgv_listarDetalle.Columns[2].Width = 250;
            dgv_listarDetalle.Columns[2].HeaderText = "PRODUCTO";
            dgv_listarDetalle.Columns[3].Width = 220;
            dgv_listarDetalle.Columns[3].HeaderText = "MARCA";
            dgv_listarDetalle.Columns[4].Width = 130;
            dgv_listarDetalle.Columns[4].HeaderText = "CANTIDAD";
            dgv_listarDetalle.Columns[5].Width = 160;
            dgv_listarDetalle.Columns[5].HeaderText = "PRECIO COMPRA";
            dgv_listarDetalle.Columns[6].Width = 130;
            dgv_listarDetalle.Columns[6].HeaderText = "SUBTOTAL";
        }

        private void frm_DetalleCompra_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
    }
}
