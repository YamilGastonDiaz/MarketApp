using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empaque
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public decimal cantidadxUnidad { get; set; }

        public Empaque()
        {
            id = 0;
            descripcion = string.Empty;
            cantidadxUnidad = 0;
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
