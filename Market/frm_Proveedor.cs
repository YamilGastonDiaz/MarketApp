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
    public partial class frm_Proveedor : Form
    {
        private NegocioProveedor negocioProveedor = new NegocioProveedor();
        private List<Proveedor> listar;
        private bool editar = false;
        private int idEditar = 0;
        private const string PlaceholderTexto = "INGRESE EMPRESA";

        public frm_Proveedor()
        {
            InitializeComponent();
            TextBoxPlaceholder.SetPlaceholder(txt_Buscar, PlaceholderTexto);
            txt_Nombre.CharacterCasing = CharacterCasing.Upper;
            txt_Direccion.CharacterCasing = CharacterCasing.Upper;
            txt_Mail.CharacterCasing = CharacterCasing.Upper;
            txt_Empresa.CharacterCasing = CharacterCasing.Upper;
            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
            txt_Cuit.KeyPress += SoloNumeros_KeyPress;
            txt_Telefono.KeyPress += SoloNumeros_KeyPress;
        }

        private void CargarLista()
        {
            listar = negocioProveedor.ListarProveedor();
            dgv_Principal.DataSource = listar;
            FormatoProveedor();
        }

        private void FormatoProveedor()
        {
            dgv_Principal.Columns["id"].Visible = false;
            dgv_Principal.Columns["nombre"].Width = 200;
            dgv_Principal.Columns["nombre"].HeaderText = "NOMBRE";
            dgv_Principal.Columns["cuit"].Width = 150;
            dgv_Principal.Columns["cuit"].HeaderText = "CUIT";
            dgv_Principal.Columns["direccion"].Width = 250;
            dgv_Principal.Columns["direccion"].HeaderText = "DIRECCION";
            dgv_Principal.Columns["telefono"].Width = 150;
            dgv_Principal.Columns["telefono"].HeaderText = "TELEFONO";
            dgv_Principal.Columns["mail"].Width = 200;
            dgv_Principal.Columns["mail"].HeaderText = "EMAIL";
            dgv_Principal.Columns["empresa"].Width = 150;
            dgv_Principal.Columns["empresa"].HeaderText = "EMPRESA";
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

        private void frm_Proveedor_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Nombre.Text = "";
            txt_Cuit.Text = "";
            txt_Direccion.Text = "";
            txt_Telefono.Text = "";
            txt_Mail.Text = "";
            txt_Empresa.Text = "";
            txt_Nombre.ReadOnly = false;
            txt_Cuit.ReadOnly = false;
            txt_Direccion.ReadOnly = false;
            txt_Telefono.ReadOnly = false;
            txt_Mail.ReadOnly = false;
            txt_Empresa.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Nombre.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Proveedor seleccionada = (Proveedor)dgv_Principal.CurrentRow.DataBoundItem;

                txt_Nombre.Text = seleccionada.nombre;
                txt_Cuit.Text = seleccionada.cuit;
                txt_Direccion.Text = seleccionada.direccion;
                txt_Telefono.Text = seleccionada.telefono;
                txt_Mail.Text = seleccionada.mail;
                txt_Empresa.Text = seleccionada.empresa;

                txt_Nombre.ReadOnly = false;
                txt_Cuit.ReadOnly = false;
                txt_Direccion.ReadOnly = false;
                txt_Telefono.ReadOnly = false;
                txt_Mail.ReadOnly = false;
                txt_Empresa.ReadOnly = false;
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
                MessageBox.Show("Seleccione una fila para eliminar.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult opcion;
                opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (opcion == DialogResult.Yes)
                {
                    Proveedor seleccionada = (Proveedor)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioProveedor.EliminarProveedor(idEliminar);

                    MessageBox.Show("Proveedor eliminado/a correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string nombre = txt_Nombre.Text.Trim();
            string cuit = txt_Cuit.Text.Trim();
            string direccion = txt_Direccion.Text.Trim();
            string telefono = txt_Telefono.Text.Trim();
            string mail = txt_Mail.Text.Trim();
            string empresa = txt_Empresa.Text.Trim();


            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(direccion) || string.IsNullOrWhiteSpace(telefono)
                || string.IsNullOrWhiteSpace(mail) || string.IsNullOrWhiteSpace(empresa))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Proveedor proveedor = new Proveedor();

                if(negocioProveedor.ExisteProveedor(cuit))
                {
                    MessageBox.Show("Ya existe un proveedor con ese numero de cuit.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                proveedor.nombre = nombre;
                proveedor.cuit = cuit;
                proveedor.direccion = direccion;
                proveedor.telefono = telefono;
                proveedor.mail = mail;
                proveedor.empresa = empresa;

                if (editar)
                {
                    proveedor.id = idEditar;
                    negocioProveedor.ModificarProveedor(proveedor);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioProveedor.AgregarProveedor(proveedor);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_Nombre.Text = "";
                txt_Nombre.ReadOnly = true;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Nombre.Text = "";
            txt_Cuit.Text = "";
            txt_Direccion.Text = "";
            txt_Telefono.Text = "";
            txt_Mail.Text = "";
            txt_Empresa.Text = "";
            txt_Nombre.ReadOnly = true;
            txt_Cuit.ReadOnly = true;
            txt_Direccion.ReadOnly = true;
            txt_Telefono.ReadOnly = true;
            txt_Mail.ReadOnly = true;
            txt_Empresa.ReadOnly = true;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }

        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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
                dgv_Principal.DataSource = negocioProveedor.BuscarPorEmpresa(texto);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
