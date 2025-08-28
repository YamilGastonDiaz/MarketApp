using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class StockProducto
    {
        public int id {  get; set; }
        public int idProducto { get; set; }
        public decimal stock_actual { get; set; }
        public decimal precio_dia { get; set; }
        public decimal precio_noche { get; set; }

        public StockProducto() 
        {
            id = 0;
            idProducto = 0;
            stock_actual = 0;
            precio_dia = 0;
            precio_noche = 0;
        }
    }
}
