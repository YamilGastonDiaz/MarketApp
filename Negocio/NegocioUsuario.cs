using Dominio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        private ConexionDB datos = new ConexionDB();
        private readonly PasswordHasher<Usuario> passHasher;

        public NegocioUsuario()
        {
            passHasher = new PasswordHasher<Usuario>();
        }

        public List<Usuario> ListarUser()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                datos.setearConsulta("SELECT Usuario_Id, Nombre, Usuario FROM Usuarios WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();

                    aux.id = (int)datos.Lector["Usuario_Id"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.usuario = (string)datos.Lector["Usuario"];                                    

                    lista.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return lista;
        }

        public int RegistroUser(Usuario usuario)
        {
            try
            {
                //Hashear la contraseña antes de guardarla en la base de datos
                string hashedPassword = passHasher.HashPassword(usuario, usuario.contrasenia);

                datos.setearProcedure("SP_INSERTAR_USER");

                datos.setearParametro("@nombre", usuario.nombre);
                datos.setearParametro("@usuario", usuario.usuario);
                datos.setearParametro("@pass", hashedPassword);

                return datos.ejecutarScalar();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Logear(Usuario user)
        {
            try
            {
                datos.setearConsulta("SELECT Usuario_Id, Nombre, Usuario, Rol, Contrasenia FROM Usuarios WHERE Usuario = @usuario"); // no olvidar colocar el Estado = 1                
                datos.setearParametro("@usuario", user.usuario);

                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    user.id = (int)datos.Lector["Usuario_Id"];
                    user.nombre = (string)datos.Lector["Nombre"];
                    user.usuario = (string)datos.Lector["Usuario"];
                    user.rol = (int)(datos.Lector["Rol"]) == 1 ? Rol.ADMIN : Rol.CAJERO;

                    //Obtener la contraseña hasheada desde la base de datos
                    string hashedPassword = (string)datos.Lector["Contrasenia"];

                    //Verificar si la contraseña ingresada coincide con el hash
                    var resultado = passHasher.VerifyHashedPassword(user, hashedPassword, user.contrasenia);

                    return resultado == PasswordVerificationResult.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return false;
        }

        public void ModificarUser(Usuario user)
        {
            try
            {
                string hashedPassword = passHasher.HashPassword(user, user.contrasenia);

                datos.setearConsulta("UPDATE Usuarios SET Nombre = @nombre, Usuario = @usuario, Contrasenia = @contrasenia WHERE Usuario_Id = @id");
                datos.setearParametro("@nombre", user.nombre);
                datos.setearParametro("@usuario", user.usuario);
                datos.setearParametro("@contrasenia", hashedPassword);
                datos.setearParametro("id", user.id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void EliminarUser(int id)
        {
            try
            {
                datos.setearConsulta("UPDATE Usuarios set Estado = 0 WHERE Usuario_Id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteUser(string user)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuarios WHERE UPPER(Usuario) = UPPER(@usuario)");
                datos.setearParametro("@usuario", user);
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    int cont = datos.Lector.GetInt32(0);
                    return cont > 0;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Usuario> BuscarPorNombre(string descripcion)
        {
            List<Usuario> user = new List<Usuario>();
            try
            {
                datos.setearConsulta("SELECT Usuario_Id, Nombre, Usuario \r\nFROM Usuarios\r\nWHERE Estado = 1 AND Nombre LIKE @nombre\r\n");
                datos.setearParametro("@nombre", "%" + descripcion + "%");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.id = (int)datos.Lector["Usuario_Id"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.usuario = (string)datos.Lector["Usuario"];


                    user.Add(aux);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return user;
        }
    }
}
