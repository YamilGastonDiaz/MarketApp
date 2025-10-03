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
    public partial class frm_ReportePorVendedor : Form
    {
        public int id_Usuario { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public frm_ReportePorVendedor()
        {
            InitializeComponent();
        }

        private void frm_ReportePorVendedor_Load(object sender, EventArgs e)
        {
            if(id_Usuario > 0)
            {
                this.reporteVentasPorVendedorTableAdapter.Fill(this.dataSetMarket.ReporteVentasPorVendedor, id_Usuario, fechaDesde, fechaHasta);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
