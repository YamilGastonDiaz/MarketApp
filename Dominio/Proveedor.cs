using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Proveedor
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string cuit {  get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string mail { get; set; }
        public string empresa { get; set; }

        public Proveedor()
        {
            id = 0;
            nombre = string.Empty;
            cuit = string.Empty;
            direccion = string.Empty;
            telefono = string.Empty;
            mail = string.Empty;
            empresa = string.Empty;
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
