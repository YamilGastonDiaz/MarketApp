using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioDetalleCompra
    {
        private ConexionDB datos = new ConexionDB();

        public List<DetalleCompra> ListarDetalle(int id)
        {
            List<DetalleCompra> detalle = new List<DetalleCompra>();
            try
            {
                datos.setearConsulta("SELECT Detalle_id, p.Descripcion AS Producto, m.Descripcion AS Marca, e.Descripcion AS Empaque, dc.Cantidad, dc.PrecioCompra, dc.Subtotal\r\nFROM DetalleCompras AS dc\r\nINNER JOIN Productos AS p ON dc.id_Producto = p.Producto_id\r\nINNER JOIN Marcas AS m ON dc.id_Marca = m.Marca_id\r\nINNER JOIN TiposEmpaques AS e ON p.id_Empaque = e.Empaque_id\r\nWHERE dc.id_Compra = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    DetalleCompra aux = new DetalleCompra();
                    aux.id = (int)datos.Lector["Detalle_id"];

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

                    if (!(datos.Lector["Empaque"] is DBNull))
                    {
                        aux.producto.empaque = new Empaque();
                        aux.producto.empaque.descripcion = (string)datos.Lector["Empaque"];
                    }

                    aux.cantidad = (decimal)datos.Lector["Cantidad"];
                    aux.precioCompra = (decimal)datos.Lector["PrecioCompra"];
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
