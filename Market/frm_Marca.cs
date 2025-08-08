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
    public partial class frm_Marca : Form
    {
        private NegocioMarca negocioMarca = new NegocioMarca();
        private List<Marca> listar;
        private bool editar = false;
        private int idEditar = 0;

        public frm_Marca()
        {
            InitializeComponent();
        }

        private void CargarLista()
        {
            listar = negocioMarca.ListarMarca();
            dgv_Principal.DataSource = listar;
            FormatoMarca();
        }

        private void FormatoMarca()
        {
            dgv_Principal.Columns[0].Width = 100;
            dgv_Principal.Columns[0].HeaderText = "ID";
            dgv_Principal.Columns[1].Width = 300;
            dgv_Principal.Columns[1].HeaderText = "MARCAS";
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

        private void frm_Marca_Load(object sender, EventArgs e)
        {
            CargarLista();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            EstadoBtnPrincipales(false);
            EstadoBtnProcesos(true);
            txt_Marca_dc.Text = "";
            txt_Marca_dc.ReadOnly = false;
            tab_Principal.SelectedIndex = 1;
            txt_Marca_dc.Focus();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (dgv_Principal.CurrentRow != null)
            {
                Marca seleccionada = (Marca)dgv_Principal.CurrentRow.DataBoundItem;

                txt_Marca_dc.Text = seleccionada.descripcion;
                txt_Marca_dc.ReadOnly = false;
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

                    negocioMarca.EliminarMarca(idEliminar);

                    MessageBox.Show("Categoría eliminada correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarLista();
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string descripcion = txt_Marca_dc.Text.Trim();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Falta ingresar datos requerido (*)", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else 
            {
                Marca marca = new Marca();

                if(negocioMarca.ExisteMarca(descripcion))
                {
                    MessageBox.Show("Ya existe una categoría con esa descripción.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                marca.descripcion = descripcion;

                if (editar)
                {
                    marca.id = idEditar;
                    negocioMarca.ModificarMarca(marca);
                    MessageBox.Show("Los datos han sido modificados correctamente.", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    negocioMarca.AgregarMarca(marca);
                    MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                    
                CargarLista();
                EstadoBtnPrincipales(true);
                EstadoBtnProcesos(false);
                txt_Marca_dc.Text = "";
                txt_Marca_dc.ReadOnly = true;
                tab_Principal.SelectedIndex = 0;

                editar = false;
                idEditar = 0;
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            txt_Marca_dc.Text = "";
            txt_Marca_dc.ReadOnly = true;
            EstadoBtnPrincipales(true);
            EstadoBtnProcesos(false);
            tab_Principal.SelectedIndex = 0;
        }   
    }
}
