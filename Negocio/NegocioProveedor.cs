using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProveedor
    {
        ConexionDB datos = new ConexionDB();

        public List<Proveedor> ListarProveedor()
        {
            List<Proveedor> proveedor = new List<Proveedor>();
            try
            {
                datos.setearConsulta("SELECT Proveedor_id, Nombre, CUIT, Direccion, Telefono, Email, Empresa FROM Proveedores WHERE Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.id = (int)datos.Lector["Proveedor_id"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.cuit = (string)datos.Lector["CUIT"];
                    aux.direccion = (string)datos.Lector["Direccion"];
                    aux.telefono = (string)datos.Lector["Telefono"];
                    aux.mail = (string)datos.Lector["Email"];
                    aux.empresa = (string)datos.Lector["Empresa"];

                    proveedor.Add(aux);
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
            return proveedor;
        }
        public void AgregarProveedor(Proveedor proveedor)
        {
            try
            {
                datos.setearConsulta("INSERT INTO Proveedores (Nombre, CUIT, Direccion, Telefono, Email, Empresa) VALUES (@Nombre, @CUIT, @Direccion, @Telefono, @Email, @Empresa)");
                datos.setearParametro("Nombre", proveedor.nombre);
                datos.setearParametro("CUIT", proveedor.cuit);
                datos.setearParametro("Direccion", proveedor.direccion);
                datos.setearParametro("Telefono", proveedor.telefono);
                datos.setearParametro("Email", proveedor.mail);
                datos.setearParametro("Empresa", proveedor.empresa);

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
        public void ModificarProveedor(Proveedor proveedor)
        {
            try
            {
                datos.setearConsulta("UPDATE Proveedores SET Nombre = @Nombre, CUIT = @CUIT, Direccion = @Direccion, Telefono = @Telefono, Email = @Email, Empresa = @Empresa WHERE Proveedor_id = @id");
                datos.setearParametro("@Nombre", proveedor.nombre);
                datos.setearParametro("@CUIT", proveedor.cuit);
                datos.setearParametro("@Direccion", proveedor.direccion);
                datos.setearParametro("@Telefono", proveedor.telefono);
                datos.setearParametro("@Email", proveedor.mail);
                datos.setearParametro("@Empresa", proveedor.empresa);
                datos.setearParametro("@id", proveedor.id);

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
        public void EliminarProveedor(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE Proveedores SET Estado = 0 WHERE Proveedor_id = @id");
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

        public bool ExisteProveedor(string cuit)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Proveedores WHERE UPPER(CUIT) = UPPER(@CUIT)");
                datos.setearParametro("@CUIT", cuit);
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
