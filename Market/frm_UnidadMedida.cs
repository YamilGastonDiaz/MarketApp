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
    public partial class frm_UnidadMedida : Form
    {
        private NegocioUnidadMedida negocioUnidad = new NegocioUnidadMedida();
        private List<UnidadMedida> listar;
        private bool editar = false;
        private int idEditar = 0;

        public frm_UnidadMedida()
        {
            InitializeComponent();
        }

        private void CargarLista()
        {
            listar = negocioUnidad.ListarUnidad();
            dgv_Principal.DataSource = listar;
            FormatoUnidad();
        }

        private void FormatoUnidad()
        {
            dgv_Principal.Columns[0].Width = 80;
            dgv_Principal.Columns[0].HeaderText = "ID";
            dgv_Principal.Columns[1].Width = 150;
            dgv_Principal.Columns[1].HeaderText = "ABREVIATURA";
            dgv_Principal.Columns[2].Width = 300;
            dgv_Principal.Columns[2].HeaderText = "UNIDAD MEDIDA";
        }

        private void EstadoBtnPrincipales(bool estado)
        {
            btn_Nuevo.Enabled = estado;
            btn_Actualizar.Enabled = estado;
            btn_Elimiar.Enabled = estado;
            btn_Reporte.Enabled = estado;
            btn_Salir.Enabled = estado;
        }

        private void EstadoBtnProcesos(bool estado)
        {
            btn_Cancelar.Visible = estado;
            btn_Guardar.Visible = estado;
        }

        private void frm_UnidadMedida_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Medida_dc.Text = "";
            txt_Abreviatura.Text = "";
            txt_Medida_dc.ReadOnly = false;
            txt_Abreviatura.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Medida_dc.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                UnidadMedida seleccionada = (UnidadMedida)dgv_Principal.CurrentRow.DataBoundItem;

                txt_Medida_dc.Text = seleccionada.descripcion;
                txt_Abreviatura.Text = seleccionada.abreviatura;
                txt_Abreviatura.ReadOnly = false;
                txt_Medida_dc.ReadOnly = false;
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
                    Categoria seleccionada = (Categoria)dgv_Principal.CurrentRow.DataBoundItem;
                    int idEliminar = seleccionada.id;

                    negocioUnidad.EliminarUnidad(idEliminar);

                    MessageBox.Show("Categoría eliminada correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string abreviatura = txt_Abreviatura.Text.Trim();
            string descripcion = txt_Medida_dc.Text.Trim();

            if (string.IsNullOrWhiteSpace(abreviatura) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                UnidadMedida unidad = new UnidadMedida();

                if(negocioUnidad.ExisteUnidad(abreviatura, descripcion))
                {
                    MessageBox.Show("Ya existe una categoría con esa descripción.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                unidad.abreviatura = abreviatura;
                unidad.descripcion = descripcion;

                if (editar)
                {
                    unidad.id = idEditar;
                    negocioUnidad.ModificarUnidad(unidad);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioUnidad.AgregarUnidad(unidad);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_Medida_dc.Text = "";
                txt_Abreviatura.Text = "";
                txt_Medida_dc.ReadOnly = true;
                txt_Abreviatura.ReadOnly = true;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Medida_dc.Text = "";
            txt_Abreviatura.Text = "";
            txt_Medida_dc.ReadOnly = true;
            txt_Abreviatura.ReadOnly = true;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }   
    }
}
