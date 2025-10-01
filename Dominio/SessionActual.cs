using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public static class SessionActual
    {
        public static Usuario userAcutual {  get; set; }
        public static int? idTurnoActual { get; set; }

        public static void CerrarSession()
        {
            userAcutual = null;
            idTurnoActual = null;
        }
    }
}
