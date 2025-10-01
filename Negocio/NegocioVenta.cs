using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioVenta
    {
        private ConexionDB datos = new ConexionDB();

        public List<Venta> ListarVenta()
        {
            List<Venta> venta = new List<Venta>();
            try
            {
                datos.setearConsulta("SELECT Venta_id, u.Nombre as Usuario, v.id_Turno, Fecha, Total_importe\r\nFROM Ventas as v\r\nINNER JOIN Usuarios as u on u.Usuario_id = v.id_Usuario  \r\nWHERE v.Estado = 1");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.id = (int)datos.Lector["Venta_id"];

                    aux.turno = new Turno();
                    aux.turno.id = (int)datos.Lector["id_Turno"];

                    if (!(datos.Lector["Usuario"] is DBNull))
                    {
                        aux.usuario = new Usuario();
                        aux.usuario.nombre = (string)datos.Lector["Usuario"];
                    }

                    aux.fecha = (DateTime)datos.Lector["Fecha"];
                    aux.totalImporte = (decimal)datos.Lector["Total_importe"];

                    venta.Add(aux);
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
            return venta;
        }

        public ProductoVenta BuscarProductoPorCodigo(string codigoBarras)
        {
            ProductoVenta aux = new ProductoVenta();
            try
            {
                datos.setearConsulta("SELECT p.Producto_id, m.Marca_id, m.Descripcion as Marca, p.Descripcion, sp.PrecioDia, sp.PrecioNoche\r\nFROM Productos as p\r\nINNER JOIN Marcas as m on m.Marca_id = p.id_Marca\r\nINNER JOIN StockProductos as sp on sp.id_Producto = p.Producto_id\r\nWHERE p.CodigoBarras = @CodigoBarras");
                datos.setearParametro("@CodigoBarras", codigoBarras);

                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    aux.id = (int)datos.Lector["Producto_id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.marca = new Marca();
                        aux.marca.id = (int)datos.Lector["Marca_id"];
                        aux.marca.descripcion = (string)datos.Lector["Marca"];
                    }

                    aux.precioDia = (decimal)datos.Lector["PrecioDia"];
                    aux.precioNoche = (decimal)datos.Lector["PrecioNoche"];
                }

                return aux;
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

        public int AgregarVentaConDetalles(Venta venta, DataTable detalles)
        {
            int id = 0;
            try
            {
                datos.setearProcedure("AgregarVentaConDetalles");
                datos.setearParametro("@idUsuario", venta.usuario.id);
                datos.setearParametro("@idTurno", venta.turno.id);
                datos.setearParametro("@Fecha", venta.fecha);
                datos.setearParametro("@Total", venta.totalImporte);
                datos.setearParametroTablaVenta("@Detalles", detalles);

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

        public List<Venta> BuscarPorNombre(string descripcion)
        {
            List<Venta> venta = new List<Venta>();
            try
            {
                datos.setearConsulta("SELECT Venta_id, u.Nombre as Usuario, v.id_Turno, Fecha, Total_importe\r\nFROM Ventas as v\r\nINNER JOIN Usuarios as u on u.Usuario_id = v.id_Usuario\r\nWHERE v.Estado = 1 AND u.Nombre LIKE @nombre");
                datos.setearParametro("@nombre", "%" + descripcion + "%");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.id = (int)datos.Lector["Venta_id"];

                    aux.turno = new Turno();
                    aux.turno.id = (int)datos.Lector["id_Turno"];

                    if (!(datos.Lector["Usuario"] is DBNull))
                    {
                        aux.usuario = new Usuario();
                        aux.usuario.nombre = (string)datos.Lector["Usuario"];
                    }

                    aux.fecha = (DateTime)datos.Lector["Fecha"];
                    aux.totalImporte = (decimal)datos.Lector["Total_importe"];

                    venta.Add(aux);
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
            return venta;
        }
    }
}
