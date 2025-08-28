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
        ConexionDB datos = new ConexionDB();

        public List<DetalleCompra> ListarDetalle(int id)
        {
            List<DetalleCompra> detalle = new List<DetalleCompra>();
            try
            {
                datos.setearConsulta("SELECT Detalle_id, p.Descripcion as Producto, m.Descripcion as Marca, dc.Cantidad, dc.PrecioCompra, dc.Subtotal\r\nFROM DetalleCompras as dc\r\nINNER JOIN Productos as p on dc.id_Producto = p.Producto_id\r\nINNER JOIN Marcas as m on dc.id_Marca = m.Marca_id\r\nWHERE dc.id_Compra = @id");
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

        public void AgregarDetalle(int id, DataTable detalles)
        {
            try
            {
                foreach (DataRow fila in detalles.Rows)
                {
                    datos.setearConsulta("INSERT INTO DetalleCompras (id_Compra, id_Producto, id_Marca, Cantidad, PrecioCompra, Subtotal) VALUES (@id_Compra, @id_Producto, @id_Marca, @Cantidad, @PrecioCompra, @Subtotal);");
                    datos.setearParametro("@id_Compra", id);
                    datos.setearParametro("@id_Producto", fila["id"]);
                    datos.setearParametro("@id_Marca", fila["id_Marca"]);
                    datos.setearParametro("@Cantidad", fila["Cantidad"]);
                    datos.setearParametro("@PrecioCompra", fila["PrecioCompra"]);
                    datos.setearParametro("@Subtotal", fila["Subtotal"]);

                    datos.ejecutarAccion();
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
