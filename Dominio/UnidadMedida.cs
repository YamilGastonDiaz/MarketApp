using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UnidadMedida
    {
        public int id { get; set; }
        public string abreviatura { get; set; }
        public string descripcion { get; set; }

        public UnidadMedida()
        {
            id = 0;
            abreviatura = string.Empty;
            descripcion = string.Empty;
        }

        public override string ToString()
        {
            return descripcion;
        }
    }
}
