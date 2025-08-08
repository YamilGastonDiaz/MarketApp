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
    public partial class frm_StockProducto : Form
    {
        private Producto productoSeleccionado;
        public frm_StockProducto(Producto producto)
        {
            InitializeComponent();
            productoSeleccionado = producto;
        }

        private void frm_StockProducto_Load(object sender, EventArgs e)
        {
            txt_Producto.Text = productoSeleccionado.marca.descripcion;
           
            NegocioStockProducto negocio = new NegocioStockProducto();
            StockProducto stock = negocio.ObtenerStockPorProducto(productoSeleccionado.id);

            if (stock != null)
            {
                txt_Stock.Text = stock.stock_actual.ToString("N2");
                txt_Precio.Text = stock.precio_unitario.ToString("N2");
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            decimal stockActual;
            decimal precioUnitario;
            StockProducto stock = new StockProducto();
            NegocioStockProducto negocioStock = new NegocioStockProducto();

            if (!decimal.TryParse(txt_Stock.Text, out stockActual) || stockActual <= 0)
            {
                MessageBox.Show("El stock actual debe ser un número mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txt_Precio.Text, out precioUnitario) || precioUnitario <= 0)
            {
                MessageBox.Show("El precio unitario debe ser un número mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            stock.idProducto = productoSeleccionado.id;
            stock.stock_actual = stockActual;
            stock.precio_unitario = precioUnitario;

            if (negocioStock.HayStock(stock) )
            {
                negocioStock.ModificarStockProducto(stock);
                MessageBox.Show("Stock modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                negocioStock.AgregarStockProducto(stock);
                MessageBox.Show("Stock guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
