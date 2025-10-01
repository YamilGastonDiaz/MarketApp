using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int id { get; set; }                 
        public Usuario usuario { get; set; }       
        public DateTime fechaInicio { get; set; }  
        public DateTime fechaFin { get; set; }    
        public decimal montoRecaudado { get; set; } 
        
        public Turno()
        {
            id = 0;
            usuario = new Usuario();
            fechaInicio = DateTime.MinValue;
            fechaFin = DateTime.MinValue;
            montoRecaudado = 0;
        }
    }
}
