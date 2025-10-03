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
    public partial class frm_ReporteVentaRango : Form
    {
        public frm_ReporteVentaRango()
        {
            InitializeComponent();
        }

        private void txt_Buscar_Click(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Today;

            if (dtp_Desde.Value.Date > dtp_Hasta.Value.Date)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (dtp_Desde.Value.Date > hoy || dtp_Hasta.Value.Date > hoy)
            {
                MessageBox.Show("La fecha no pueden ser futuras", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Reportes.frm_ReportePorRango rptVentaRango = new Reportes.frm_ReportePorRango();
                rptVentaRango.fechaDesde = dtp_Desde.Value.Date;
                rptVentaRango.fechaHasta = dtp_Hasta.Value.Date;

                rptVentaRango.ShowDialog();
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
