using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioCompra
    {
        ConexionDB datos = new ConexionDB();

        public List<Compra> ListarCompra()
        {
            List<Compra> compra = new List<Compra>();
            try
            {
                datos.setearConsulta("SELECT Compra_id, p.Nombre as Proveedor, Fecha, Total_importe\r\nFROM Compras as c\r\nINNER JOIN Proveedores as p on c.id_Proveedor = p.Proveedor_id \r\nWHERE c.Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Compra aux = new Compra();
                    aux.id = (int)datos.Lector["Compra_id"];

                    if (!(datos.Lector["Proveedor"] is DBNull))
                    {
                        aux.proveedor = new Proveedor();
                        aux.proveedor.nombre = (string)datos.Lector["Proveedor"];
                    }

                    aux.fecha = (DateTime)datos.Lector["Fecha"];
                    aux.precioTotal = (decimal)datos.Lector["Total_importe"];

                    compra.Add(aux);
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
            return compra;
        }

        public int AgregarCompraConDetalles(Compra compra, DataTable detalles)
        {
            int id = 0;
            try
            {
                datos.setearProcedure("AgregarCompraConDetalles");
                datos.setearParametro("@idProveedor", compra.proveedor.id);
                datos.setearParametro("@Fecha", compra.fecha);
                datos.setearParametro("@Total", compra.precioTotal);
                datos.setearParametroTabla("@Detalles", detalles);

                id = datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            return id;
        }

        public void EliminarCompra(int idCompra)
        {
            try
            {
                datos.setearProcedure("EliminarCompra");
                datos.setearParametro("@idCompra", idCompra);
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
    }
}
