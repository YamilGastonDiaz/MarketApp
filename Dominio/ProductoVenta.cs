using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductoVenta
    {
        public int id { get; set; }
        public Marca marca { get; set; }
        public StockProducto stock {  get; set; }
        public decimal stock_Min { get; set; }
        public string descripcion { get; set; }
        public decimal precioDia { get; set; }
        public decimal precioNoche { get; set; }
    }
}
