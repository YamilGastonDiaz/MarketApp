using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDetalleVenta
    {
        private ConexionDB datos = new ConexionDB();

        public List<DetalleVenta> ListarDetalle(int id)
        {
            List<DetalleVenta> detalle = new List<DetalleVenta>();
            try
            {
                datos.setearConsulta("SELECT DetalleVenta_id, p.Descripcion as Producto, m.Descripcion as Marca, dv.Cantidad, dv.PrecioUnitario, dv.Subtotal\r\nFROM DetalleVentas as dv\r\nINNER JOIN Productos as p on dv.id_Producto = p.Producto_id\r\nINNER JOIN Marcas as m on dv.id_Marca = m.Marca_id\r\nWHERE dv.id_Venta = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();
                    aux.id = (int)datos.Lector["DetalleVenta_id"];

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.producto = new Producto();
                        aux.producto.descripcion = (string)datos.Lector["Producto"];
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.marca = new Marca();
                        aux.marca.descripcion = (string)datos.Lector["Marca"];
                    }

                    aux.cantidad = (decimal)datos.Lector["Cantidad"];
                    aux.precioVenta = (decimal)datos.Lector["PrecioUnitario"];
                    aux.subTotal = (decimal)datos.Lector["Subtotal"];

                    detalle.Add(aux);
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
            return detalle;
        }
    }
}
