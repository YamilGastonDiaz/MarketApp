using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioMarca
    {
        private ConexionDB datos = new ConexionDB();

        public List<Marca> ListarMarca()
        {
            List<Marca> marcas = new List<Marca>();
            try
            {
                datos.setearConsulta("SELECT Marca_id, Descripcion FROM Marcas WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)datos.Lector["Marca_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    marcas.Add(aux);
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
            return marcas;
        }
        public void AgregarMarca(Marca marca)
        {
            try
            {
                datos.setearConsulta("INSERT INTO Marcas (Descripcion) VALUES (@Descripcion)");
                datos.setearParametro("@Descripcion", marca.descripcion);

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
        public void ModificarMarca(Marca marca)
        {
            try
            {
                datos.setearConsulta("UPDATE Marcas SET Descripcion = @Descripcion WHERE Marca_id = @id");
                datos.setearParametro("@Descripcion", marca.descripcion);
                datos.setearParametro("@id", marca.id);

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
        public void EliminarMarca(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE Marcas SET Estado = 0 WHERE Marca_id = @id");
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
        public bool ExisteMarca(string descripcion)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Marcas WHERE UPPER(Descripcion) = UPPER(@descripcion)");
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

        public List<Marca> BuscarPorDescripcion(string descripcion)
        {
            List<Marca> marca = new List<Marca>();
            try
            {
                datos.setearConsulta("SELECT Marca_id, Descripcion FROM Marcas WHERE Estado = 1 AND Descripcion LIKE @descripcion");
                datos.setearParametro("@descripcion", "%" + descripcion + "%");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)datos.Lector["Marca_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    marca.Add(aux);
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
            return marca;
        }
    }
}

