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
    public partial class frm_Seccion : Form
    {
        public frm_Seccion()
        {
            InitializeComponent();
        }

        private void btn_Administrar_Click(object sender, EventArgs e)
        {
            Hide();
            frm_Dashboard dashboard = new frm_Dashboard();
            dashboard.ShowDialog();
        }

        private void btn_Venta_Click(object sender, EventArgs e)
        {
            Hide();
            frm_Ventas venta = new frm_Ventas();
            venta.ShowDialog();
        }
    }
}
