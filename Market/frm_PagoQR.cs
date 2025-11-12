using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace Market
{
    public partial class frm_PagoQR : Form
    {
        private string qrData;
        private decimal monto;

        public frm_PagoQR(string qr, decimal montoPagar)
        {
            InitializeComponent();
            qrData = qr;
            monto = montoPagar;
        }

        private void frm_PagoQR_Load(object sender, EventArgs e)
        {
            lblMonto.Text = $"MONTO A PAGAR: ${monto:F2}";
            MostrarQR(qrData);
        }

        private void MostrarQR(string data)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrImage = qrCode.GetGraphic(6);
            picQR.Image = qrImage;
        }
    }
}
