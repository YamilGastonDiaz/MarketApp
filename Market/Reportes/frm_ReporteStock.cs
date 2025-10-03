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
    public partial class frm_ReporteStock : Form
    {
        public frm_ReporteStock()
        {
            InitializeComponent();
        }

        private void frm_ReporteStock_Load(object sender, EventArgs e)
        {
            this.reporteStockVsMinimoTableAdapter.Fill(this.dataSetMarket.ReporteStockVsMinimo);

            this.reportViewer1.RefreshReport();
        }
    }
}
