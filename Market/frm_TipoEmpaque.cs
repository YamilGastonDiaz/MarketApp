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
    public partial class frm_TipoEmpaque : Form
    {
        private NegocioEmpaque negocioEmpaque = new NegocioEmpaque();
        private List<Empaque> listar;
        private bool editar = false;
        private int idEditar = 0;
        private const string PlaceholderTexto = "INGRESE DESCRIPCION";

        public frm_TipoEmpaque()
        {
            InitializeComponent();
            TextBoxPlaceholder.SetPlaceholder(txt_Buscar, PlaceholderTexto);
            txt_Descripcion.CharacterCasing = CharacterCasing.Upper;
            txt_Buscar.CharacterCasing = CharacterCasing.Upper;
        }

        private void CargarLista()
        {
            listar = negocioEmpaque.ListarEmpaque();
            dgv_Principal.DataSource = listar;
            FormatoTipoEmpaque();
        }

        private void FormatoTipoEmpaque()
        {
            dgv_Principal.Columns["id"].Width = 80;
            dgv_Principal.Columns["id"].HeaderText = "ID";
            dgv_Principal.Columns["descripcion"].Width = 150;
            dgv_Principal.Columns["descripcion"].HeaderText = "DESCRIPCION";
            dgv_Principal.Columns["cantidadxUnidad"].Width = 300;
            dgv_Principal.Columns["cantidadxUnidad"].HeaderText = "CANTIDAD X EMPAQUE";
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

        private void frm_TipoEmpaque_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Descripcion.Text = "";
            txt_Cant_Unidad.Text = "";
            txt_Descripcion.ReadOnly = false;
            txt_Cant_Unidad.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Descripcion.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Empaque seleccionada = (Empaque)dgv_Principal.CurrentRow.DataBoundItem;

                txt_Descripcion.Text = seleccionada.descripcion;
                txt_Cant_Unidad.Text = seleccionada.cantidadxUnidad.ToString();
                txt_Cant_Unidad.ReadOnly = false;
                txt_Descripcion.ReadOnly = false;
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
                    Empaque seleccionada = (Empaque)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioEmpaque.EliminarEmpaque(idEliminar);

                    MessageBox.Show("Tipo de empaque eliminada correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string cantUnidad = txt_Cant_Unidad.Text.Trim();
            string descripcion = txt_Descripcion.Text.Trim();

            if (!decimal.TryParse(cantUnidad, out decimal cantidadUnitario))
            {
                MessageBox.Show("Cantidad por Unidad debe ser números válidos.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(descripcion) || string.IsNullOrWhiteSpace(cantUnidad))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Empaque empaque = new Empaque();

                if(negocioEmpaque.ExisteEmpaque(descripcion, decimal.Parse(cantUnidad)))
                {
                    MessageBox.Show("Ya existe una unidad de medida con esa descripción.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                empaque.descripcion = descripcion;
                empaque.cantidadxUnidad = decimal.Parse(cantUnidad);

                if (editar)
                {
                    empaque.id = idEditar;
                    negocioEmpaque.ModificarEmpaque(empaque);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioEmpaque.AgregarEmpaque(empaque);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_Descripcion.Text = "";
                txt_Cant_Unidad.Text = "";
                txt_Descripcion.ReadOnly = true;
                txt_Cant_Unidad.ReadOnly = true;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Descripcion.Text = "";
            txt_Cant_Unidad.Text = "";
            txt_Descripcion.ReadOnly = true;
            txt_Cant_Unidad.ReadOnly = true;
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
                dgv_Principal.DataSource = negocioEmpaque.BuscarPorDescripcion(texto);
            }
        }
        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
