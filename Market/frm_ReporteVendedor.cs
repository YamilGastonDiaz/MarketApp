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
    public partial class frm_ReporteVendedor : Form
    {
        public frm_ReporteVendedor()
        {
            InitializeComponent();
            CargarComboBoxUsuarios();
        }

        private void CargarComboBoxUsuarios()
        {
            NegocioUsuario negocio = new NegocioUsuario();
            List<Usuario> listaUser = negocio.ListarUser();

            cbox_Usuario.DataSource = listaUser;
            cbox_Usuario.DisplayMember = "nombre";
            cbox_Usuario.ValueMember = "id";

            cbox_Usuario.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbox_Usuario.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void txt_Buscar_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;

            if (dtp_Desde.Value.Date > dtp_Hasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtp_Desde.Value.Date > hoy || dtp_Hasta.Value.Date > hoy)
            {
                MessageBox.Show("La fecha no pueden ser futuras", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbox_Usuario.SelectedValue != null)
            {
                int id = Convert.ToInt32(cbox_Usuario.SelectedValue);
                Reportes.frm_ReportePorVendedor rptVendedor = new Reportes.frm_ReportePorVendedor();
                rptVendedor.id_Usuario = id;
                rptVendedor.fechaDesde = dtp_Desde.Value.Date;
                rptVendedor.fechaHasta = dtp_Hasta.Value.Date;

                rptVendedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Porfavor seleccione un vendedor");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
