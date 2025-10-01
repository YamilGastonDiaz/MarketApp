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
    public partial class frm_Login : Form
    {
        private Usuario user = new Usuario();
        private NegocioUsuario negocioUsuario = new NegocioUsuario();
        public frm_Login()
        {
            InitializeComponent();
        }

        private void btn_Ingresar_Click(object sender, EventArgs e)
        {            
            user.usuario = txt_User.Text;
            user.contrasenia = txt_Pass.Text;

            bool login = negocioUsuario.Logear(user);

            if (login)
            {
                SessionActual.userAcutual = user;

                Hide();

                if (user.rol == Rol.ADMIN)
                {
                    frm_Seccion seccion = new frm_Seccion();
                    seccion.ShowDialog();
                }
                else if (user.rol == Rol.CAJERO)
                {
                    frm_Ventas venta = new frm_Ventas();
                    venta.ShowDialog();
                }

                Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            txt_Pass.UseSystemPasswordChar = true;
        }

        private void frm_Login_Activated(object sender, EventArgs e)
        {
            txt_User.Clear();
            txt_Pass.Clear();
        }
    }
}
