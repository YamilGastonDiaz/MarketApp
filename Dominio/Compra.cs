using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public int id {  get; set; }
        public Proveedor proveedor { get; set; }
        public DateTime fecha { get; set; }
        public decimal precioTotal { get; set; }

        public Compra()
        {
            id = 0;
            proveedor = new Proveedor();
            fecha = DateTime.MinValue;
            precioTotal = 0;
        }
    }
}
