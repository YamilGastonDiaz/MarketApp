using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetalleVenta
    {
        public int id { get; set; }
        public Venta venta { get; set; }
        public Producto producto { get; set; }
        public Marca marca { get; set; }
        public decimal cantidad { get; set; }
        public decimal precioVenta { get; set; }
        public decimal subTotal { get; set; }

        public DetalleVenta()
        {
            id = 0;
            venta = new Venta();
            producto = new Producto();
            marca = new Marca();
            cantidad = 0;
            precioVenta = 0;
            subTotal = 0;
        }
    }
}
