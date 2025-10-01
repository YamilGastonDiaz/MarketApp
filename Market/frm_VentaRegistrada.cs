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
    public partial class frm_VentaRegistrada : Form
    {
        NegocioVenta negocioVenta = new NegocioVenta();
        private List<Venta> ventaLista;

        public frm_VentaRegistrada()
        {
            InitializeComponent();
            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
        }

        private void CargarLista()
        {
            ventaLista = negocioVenta.ListarVenta();
            dgv_Principal.DataSource = ventaLista;
            FormatoVentaProducto();
        }

        private void FormatoVentaProducto()
        {
            dgv_Principal.Columns["id"].Width = 100;
            dgv_Principal.Columns["id"].HeaderText = "ID";
            dgv_Principal.Columns["usuario"].Width = 250;
            dgv_Principal.Columns["usuario"].HeaderText = "USUARIO";
            dgv_Principal.Columns["fecha"].Width = 150;
            dgv_Principal.Columns["turno"].Visible = false;
            dgv_Principal.Columns["fecha"].HeaderText = "FECHA";
            dgv_Principal.Columns["totalImporte"].Width = 180;
            dgv_Principal.Columns["totalImporte"].HeaderText = "TOTAL IMPORTE";
        }

        private void frm_VentaRegistrada_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void dgv_Principal_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Venta ventaSeleccionado = (Venta)dgv_Principal.Rows[e.RowIndex].DataBoundItem;

                frm_VentaDetalle detalleForm = new frm_VentaDetalle(ventaSeleccionado);
                detalleForm.ShowDialog();
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            dgv_Principal.DataSource = negocioVenta.BuscarPorNombre(txt_Buscar.Text);
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
