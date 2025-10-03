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
    public partial class frm_ListaProducto : Form
    {
        public frm_ListaProducto()
        {
            InitializeComponent();
        }

        private void frm_ListaProducto_Load(object sender, EventArgs e)
        {
            this.listarProductosActivosTableAdapter.Fill(this.dataSetMarket.ListarProductosActivos);

            this.reportViewer1.RefreshReport();
        }
    }
}
