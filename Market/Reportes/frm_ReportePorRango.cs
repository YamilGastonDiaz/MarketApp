using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market.Reportes
{
    public partial class frm_ReportePorRango : Form
    {
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public frm_ReportePorRango()
        {
            InitializeComponent();
        }

        private void frm_ReportePorRango_Load(object sender, EventArgs e)
        {
            this.reporteVentasPorRangoTableAdapter.Fill(this.dataSetMarket.ReporteVentasPorRango, fechaDesde, fechaHasta);
            this.reportViewer1.RefreshReport();
        }
    }
}
