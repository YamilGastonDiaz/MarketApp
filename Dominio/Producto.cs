using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Producto
    {
        public int id {  get; set; }
        public string codigoBarra { get; set; }
        public Categoria categoria { get; set; }
        public Marca marca { get; set; }
        public Empaque empaque { get; set; }
        public string descripcion { get; set; }
        public decimal stock_min { get; set; }

        public Producto() 
        {
            codigoBarra = string.Empty;
            categoria = new Categoria();
            marca = new Marca();
            empaque = new Empaque();
            descripcion = string.Empty;
            stock_min = 0;
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
