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
    public partial class frm_ResumenTurno : Form
    {
        public frm_ResumenTurno(Turno turno, string nombreUsuario)
        {
            InitializeComponent();

            lbl_Nombre.Text = nombreUsuario;
            lbl_FechaIngreso.Text = $"FECHA INGRESO: {turno.fechaInicio.ToString("g")}";
            lbl_FechaSalida.Text = $"FECHA SALIDA: {turno.fechaFin.ToString("g")}";
            lbl_Recaudacion.Text = $"${turno.montoRecaudado:F2}";
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
