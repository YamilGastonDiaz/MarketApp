using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum Rol
    {
        ADMIN = 1,
        CAJERO = 2
    }
    public class Usuario
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public string usuario { get; set; }
        public string contrasenia { get; set; }
        public Rol rol { get; set; }
        
        public Usuario()
        {
            id = 0;
            nombre = string.Empty;
            usuario = string.Empty;
            contrasenia = string.Empty;
        }

        public Usuario(string user, string pass, int tipoRol)
        {
            usuario = user;
            contrasenia = pass;

            if(tipoRol == 1)
            {
                rol = Rol.ADMIN;
            }
            else
            {
                rol = Rol.CAJERO;
            }
        }

        public override string ToString()
        {
            return nombre;
        }
    }
}
