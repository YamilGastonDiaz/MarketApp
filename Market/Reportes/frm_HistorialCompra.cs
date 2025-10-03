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
    public partial class frm_HistorialCompra : Form
    {
        public int id_Producto { get; set; } 

        public frm_HistorialCompra()
        {
            InitializeComponent();
        }

        private void frm_HistorialCompra_Load(object sender, EventArgs e)
        {
            if(id_Producto > 0)
            {
                this.reporteHistorialPreciosCompraTableAdapter.Fill(this.dataSetMarket.ReporteHistorialPreciosCompra, id_Producto);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
