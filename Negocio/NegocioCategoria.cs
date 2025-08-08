using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCategoria
    {
        ConexionDB datos = new ConexionDB();

        public List<Categoria> ListarCategoria()
        {
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                datos.setearConsulta("SELECT Categoria_id, Descripcion FROM Categorias WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.id = (int)datos.Lector["Categoria_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    categorias.Add(aux);
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
            return categorias;
        }
        public void AgregarCategoria(Categoria categoria)
        {
            try
            {
                datos.setearConsulta("INSERT INTO Categorias (Descripcion) VALUES (@Descripcion)");
                datos.setearParametro("@Descripcion", categoria.descripcion);

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
        public void ModificarCategoria(Categoria categoria)
        {
            try
            {
                datos.setearConsulta("UPDATE Categorias SET Descripcion = @Descripcion WHERE Categoria_id = @id");
                datos.setearParametro("@Descripcion", categoria.descripcion);
                datos.setearParametro("@id", categoria.id);

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
        public void EliminarCategoria(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE Categorias SET Estado = 0 WHERE Categoria_id = @id");
                datos.setearParametro("@id", eliminar);

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
        public bool ExisteCategoria(string descripcion)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Categorias WHERE UPPER(Descripcion) = UPPER(@descripcion)");
                datos.setearParametro("@descripcion", descripcion);
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
    }
}
