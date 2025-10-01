using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioEmpaque
    {
        private ConexionDB datos = new ConexionDB();

        public List<Empaque> ListarEmpaque()
        {
            List<Empaque> empaque = new List<Empaque>();
            try
            {
                datos.setearConsulta("SELECT Empaque_id, Descripcion, CantidadUnidad FROM TiposEmpaques WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Empaque aux = new Empaque();
                    aux.id = (int)datos.Lector["Empaque_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.cantidadxUnidad = (decimal)datos.Lector["CantidadUnidad"];

                    empaque.Add(aux);
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
            return empaque;
        }
        public void AgregarEmpaque(Empaque empaque)
        {
            try
            {
                datos.setearConsulta("INSERT INTO TiposEmpaques (Descripcion, CantidadUnidad) VALUES (@Descripcion, @CantidadUnidad)");
                datos.setearParametro("@Descripcion", empaque.descripcion);
                datos.setearParametro("@CantidadUnidad", empaque.cantidadxUnidad);

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
        public void ModificarEmpaque(Empaque empaque)
        {
            try
            {
                datos.setearConsulta("UPDATE TiposEmpaques SET Descripcion = @Descripcion, CantidadUnidad = @CantidadUnidad WHERE Empaque_id = @id");
                datos.setearParametro("@Descripcion", empaque.descripcion);
                datos.setearParametro("@CantidadUnidad", empaque.cantidadxUnidad);
                datos.setearParametro("@id", empaque.id);

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
        public void EliminarEmpaque(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE TiposEmpaques SET Estado = 0 WHERE Empaque_id = @id");
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
        public bool ExisteEmpaque(string descripcion, decimal cantUnidad)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM TiposEmpaques WHERE UPPER(Descripcion) = UPPER(@descripcion) SELECT COUNT(*) FROM TiposEmpaques WHERE UPPER(Descripcion) = UPPER(@descripcion) AND CantidadUnidad = @cantidadUnidad");
                datos.setearParametro("@descripcion", descripcion);
                datos.setearParametro("@cantidadUnidad", cantUnidad);
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

        public List<Empaque> BuscarPorDescripcion(string descripcion)
        {
            List<Empaque> empaque = new List<Empaque>();
            try
            {
                datos.setearConsulta("SELECT Empaque_id, Descripcion, CantidadUnidad FROM TiposEmpaques WHERE Estado = 1 AND Descripcion LIKE @descripcion");
                datos.setearParametro("@descripcion", "%" + descripcion + "%");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Empaque aux = new Empaque();
                    aux.id = (int)datos.Lector["Empaque_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.cantidadxUnidad = (decimal)datos.Lector["CantidadUnidad"];

                    empaque.Add(aux);
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
            return empaque;
        }
    }
}
