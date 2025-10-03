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
    public partial class frm_Reporte : Form
    {
        private Form activo = null;
        public frm_Reporte()
        {
            InitializeComponent();
        }

        private void OpenFormulario(Form formulario)
        {
            if (activo != null)
            {
                activo.Close();
            }

            activo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnl_Repo.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();
        }

        private void btn_ReporteStock_Click(object sender, EventArgs e)
        {
            Reportes.frm_ReporteStock rptStock = new Reportes.frm_ReporteStock();
            rptStock.ShowDialog();
        }

        private void btn_ReporteFecha_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_ReporteVentaRango());
        }

        private void btn_ReporteCompra_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_ReporteHistorial());
        }

        private void btn_ReporteVendedor_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_ReporteVendedor());
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
