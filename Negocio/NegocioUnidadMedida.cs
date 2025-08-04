using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUnidadMedida
    {
        ConexionDB datos = new ConexionDB();

        public List<UnidadMedida> ListarUnidad()
        {
            List<UnidadMedida> unidad = new List<UnidadMedida>();
            try
            {
                datos.setearConsulta("SELECT * FROM UnidadesMedidas WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    UnidadMedida aux = new UnidadMedida();
                    aux.id = (int)datos.Lector["Unidad_id"];
                    aux.abreviatura = (string)datos.Lector["Abreviatura"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    unidad.Add(aux);
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
            return unidad;
        }
        public void AgregarUnidad(UnidadMedida unidad)
        {
            try
            {
                datos.setearConsulta("INSERT INTO UnidadesMedidas (Abreviatura, Descripcion) VALUES (@Abreviatura, @Descripcion)");
                datos.setearParametro("@Abreviatura", unidad.abreviatura);
                datos.setearParametro("@Descripcion", unidad.descripcion);

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
        public void ModificarUnidad(UnidadMedida unidad)
        {
            try
            {
                datos.setearConsulta("UPDATE UnidadesMedidas SET  Abreviatura = @Abreviatura , Descripcion = @Descripcion WHERE Unidad_id = @id");
                datos.setearParametro("@Abreviatura", unidad.abreviatura);
                datos.setearParametro("@Descripcion", unidad.descripcion);
                datos.setearParametro("@id", unidad.id);

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
        public void EliminarUnidad(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE UnidadesMedidas SET Estado = 0 WHERE Unidad_id = @id");
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
        public bool ExisteUnidad(string abreviatura, string descripcion)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM UnidadesMedidas WHERE UPPER(Abreviatura) = UPPER(@abreviatura) AND UPPER(Descripcion) = UPPER(@descripcion)");
                datos.setearParametro("@abreviatura", abreviatura);
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

