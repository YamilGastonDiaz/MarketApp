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
    public partial class frm_Usuario : Form
    {
        private NegocioUsuario negocioUsuario = new NegocioUsuario();
        private List<Usuario> listar;
        private bool editar = false;
        private int idEditar = 0;
        private const string PlaceholderTexto = "INGRESE NOMBRE";

        public frm_Usuario()
        {
            InitializeComponent();
            TextBoxPlaceholder.SetPlaceholder(txt_Buscar, PlaceholderTexto);
            txt_Nombre.CharacterCasing = CharacterCasing.Upper;
            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
        }

        private void CargarLista()
        {
            listar = negocioUsuario.ListarUser();
            dgv_Principal.DataSource = listar;
            FormatoUser();
        }

        private void FormatoUser()
        {
            dgv_Principal.Columns["id"].Width = 80;
            dgv_Principal.Columns["id"].HeaderText = "ID";
            dgv_Principal.Columns["nombre"].Width = 150;
            dgv_Principal.Columns["nombre"].HeaderText = "NOMBRE";
            dgv_Principal.Columns["usuario"].Width = 300;
            dgv_Principal.Columns["usuario"].HeaderText = "USUARIO";
            dgv_Principal.Columns["contrasenia"].Visible = false;           
            dgv_Principal.Columns["rol"].Visible = false;
        }

        private void EstadoBtnPrincipales(bool estado)
        {
            btn_Nuevo.Enabled = estado;
            btn_Actualizar.Enabled = estado;
            btn_Elimiar.Enabled = estado;
            btn_Salir.Enabled = estado;
        }

        private void EstadoBtnProcesos(bool estado)
        {
            btn_Cancelar.Visible = estado;
            btn_Guardar.Visible = estado;
        }

        private void frm_Usuario_Load(object sender, EventArgs e)
        {
            CargarLista();
            txt_Pass.UseSystemPasswordChar = true;
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Nombre.Text = "";
            txt_User.Text = "";
            txt_Pass.Text = "";
            txt_Nombre.ReadOnly = false;
            txt_User.ReadOnly = false;
            txt_Pass.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Nombre.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Usuario seleccionada = (Usuario)dgv_Principal.CurrentRow.DataBoundItem;

                txt_Nombre.Text = seleccionada.nombre;
                txt_User.Text = seleccionada.usuario;
                txt_Pass.Text = seleccionada.contrasenia;
                txt_User.ReadOnly = false;
                txt_Nombre.ReadOnly = false;
                txt_Pass.ReadOnly = false;
                tab_Principal.SelectedIndex = 1;

                editar = true;
                idEditar = seleccionada.id;

                EstadoBtnPrincipales(false);
                EstadoBtnProcesos(true);
            }
            else
            {
                MessageBox.Show("Seleccione una fila para editar.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una fila para editar.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    Usuario seleccionada = (Usuario)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioUsuario.EliminarUser(idEliminar);

                    MessageBox.Show("Usuario eliminado correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string usuario = txt_User.Text.Trim();
            string nombre = txt_Nombre.Text.Trim();
            string pass = txt_Pass.Text.Trim();

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Usuario user = new Usuario();

                if(negocioUsuario.ExisteUser(usuario))
                {
                    MessageBox.Show("Ya existe un usuario con esa descripción.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                user.nombre = nombre;
                user.usuario = usuario;
                user.contrasenia = pass;

                if (editar)
                {
                    user.id = idEditar;
                    negocioUsuario.ModificarUser(user);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioUsuario.RegistroUser(user);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_Nombre.Text = "";
                txt_User.Text = "";
                txt_Pass.Text = "";
                txt_Nombre.ReadOnly = true;
                txt_User.ReadOnly = true;
                txt_Pass.ReadOnly = true;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Nombre.Text = "";
            txt_User.Text = "";
            txt_Pass.Text = "";
            txt_Nombre.ReadOnly = true;
            txt_User.ReadOnly = true;
            txt_Pass.ReadOnly = true;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            string texto = txt_Buscar.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || texto == PlaceholderTexto)
            {
                CargarLista();
                return;
            }
            else
            {
                dgv_Principal.DataSource = negocioUsuario.BuscarPorNombre(texto);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
