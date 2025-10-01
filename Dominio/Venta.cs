using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Venta
    {
        public int id { get; set; }
        public Usuario usuario { get; set; }
        public Turno turno { get; set; }
        public DateTime fecha { get; set; }
        public decimal totalImporte { get; set; }

        public Venta()
        {
            id = 0;
            usuario = new Usuario();
            turno = new Turno();
            fecha = new DateTime();
            totalImporte = 0;
        }
    }
}
