using Dominio;
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
    public partial class frm_Dashboard : Form
    {
        private Form activo = null; 
        public frm_Dashboard()
        {
            InitializeComponent();
        }

        private void OpenFormulario(Form formulario)
        {
            if(activo != null)
            {
                activo.Close();
            }

            activo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            pnl_Detalles.Controls.Add(formulario);
            formulario.BringToFront();
            formulario.Show();
        }

        private void frm_Dashboard_Load(object sender, EventArgs e)
        {
            if (SessionActual.userAcutual != null) 
            {
                lbl_Bienvenida.Text = $"Nombre: {SessionActual.userAcutual.nombre}";
                lbl_TipoUser.Text = $"Tipo Usuario: {SessionActual.userAcutual.rol}";
            }
                
            lbl_Bienvenida.Visible = true;
            lbl_TipoUser.Visible = true;
            pnl_DatosMaestros.Visible = false;
            pnl_Proceso.Visible = false;
        }

        private void btn_DatosMaestros_Click(object sender, EventArgs e)
        {
            if (pnl_DatosMaestros.Visible == false)
            {
                pnl_DatosMaestros.Visible = true;
            }
            else
            {
                pnl_DatosMaestros.Visible = false;
            }
            pnl_Proceso.Visible = false;
        }

        private void btn_Productos_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_Producto());
        }

        private void btn_Marcas_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_Marca());
        }

        private void btn_Categoria_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_Categoria());
        }

        private void btn_UnidadMedida_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_TipoEmpaque());
        }

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_Usuario());
        }

        private void btn_Proveedor_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_Proveedor());
        }

        private void btn_Procesos_Click(object sender, EventArgs e)
        {
            if (pnl_Proceso.Visible == false)
            {
                pnl_Proceso.Visible = true;
            }
            else
            {
                pnl_Proceso.Visible = false;
            }
            pnl_DatosMaestros.Visible = false;
        }

        private void btn_Compra_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_EntradaProducto());
        }

        private void btn_Venta_Click(object sender, EventArgs e)
        {
            OpenFormulario(new frm_VentaRegistrada());
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            SessionActual.CerrarSession();
            Close();
        }

        private void timer_Sistema_Tick(object sender, EventArgs e)
        {
            lbl_Fecha.Text = DateTime.Now.ToLongDateString();
            lbl_Hora.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
