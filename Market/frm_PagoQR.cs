using Dominio;
using Negocio;
using QRCoder;
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
    public partial class frm_PagoQR : Form
    {
        private string qrData;
        private decimal monto;
        private string referencia;
        private DataTable tablaDetalle;
        private NegocioMercadoPagoQR negocioMP = new NegocioMercadoPagoQR();

        public frm_PagoQR(string qr, decimal montoPagar, string refe, DataTable detalle)
        {
            InitializeComponent();
            qrData = qr;
            monto = montoPagar;
            referencia = refe;
            tablaDetalle = detalle;
        }

        private void ConfigurarTimer()
        {
            timerEstado = new Timer();
            timerEstado.Interval = 5000;
            timerEstado.Tick += timerEstado_Tick;
            timerEstado.Start();
        }

        private void frm_PagoQR_Load(object sender, EventArgs e)
        {
            lblMonto.Text = $"MONTO A PAGAR: ${monto:F2}";
            MostrarQR(qrData);
            ConfigurarTimer();
        }

        private void MostrarQR(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(6);
            picQR.Image = qrImage;
        }

        private void timerEstado_Tick(object sender, EventArgs e)
        {
            try
            {
                string estado = negocioMP.ConsultarEstadoPago(referencia);

                if (estado == "approved")
                {
                    timerEstado.Stop();
                    MessageBox.Show("Pago aprobado correctamente.", "Pago exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GuardarVenta();

                    this.Close();
                }
                else if (estado == "rejected")
                {
                    timerEstado.Stop();
                    MessageBox.Show("El pago fue rechazado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                timerEstado.Stop();
                MessageBox.Show("Error al verificar el pago: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarVenta()
        {
            try
            {
                Venta venta = new Venta
                {
                    usuario = new Usuario { id = SessionActual.userAcutual.id },
                    turno = new Turno { id = (int)SessionActual.idTurnoActual },
                    fecha = DateTime.Now,
                    totalImporte = monto
                };

                NegocioVenta negocioVenta = new NegocioVenta();
                int idVenta = negocioVenta.AgregarVentaConDetalles(venta, tablaDetalle);

                MessageBox.Show("Venta registrada correctamente con ID: " + idVenta, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
