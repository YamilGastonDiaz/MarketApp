using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProducto
    {
        private ConexionDB datos = new ConexionDB();

        public List<Producto> ListarProducto()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                datos.setearConsulta("SELECT p.Producto_id, p.CodigoBarras, p.Descripcion, p.Stock_min, c.Categoria_id, c.Descripcion as Categoria, m.Marca_id, m.Descripcion as Marca, te.Empaque_id, te.CantidadUnidad, te.Descripcion as Empaque\r\nFROM Productos as p\r\nINNER JOIN Categorias as c ON p.id_Categoria = c.Categoria_id\r\nINNER JOIN Marcas as m ON p.id_Marca = m.Marca_id\r\nINNER JOIN TiposEmpaques as te ON p.id_Empaque = te.Empaque_id\r\nWHERE p.Estado = 1;");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.id = (int)datos.Lector["Producto_id"];
                    aux.codigoBarra = (string)datos.Lector["CodigoBarras"];

                    aux.categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {                        
                        aux.categoria.id = (int)datos.Lector["Categoria_id"];
                        aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.marca = new Marca();
                        aux.marca.id = (int)datos.Lector["Marca_id"];
                        aux.marca.descripcion = (string)datos.Lector["Marca"];
                    }

                    if (!(datos.Lector["Empaque"] is DBNull))
                    {
                        aux.empaque = new Empaque();
                        aux.empaque.id = (int)datos.Lector["Empaque_id"];
                        aux.empaque.cantidadxUnidad = (decimal)datos.Lector["CantidadUnidad"];
                        aux.empaque.descripcion = (string)datos.Lector["Empaque"];
                    }

                    aux.descripcion = (string)datos.Lector["Descripcion"];


                    aux.stock_min = (decimal)datos.Lector["Stock_min"];

                    productos.Add(aux);
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
            return productos;
        }
        public int AgregarProducto(Producto producto)
        {
            int id = 0;

            try
            {
                datos.setearProcedure("AgregarProducto");
                datos.setearParametro("@CodigoBarras", producto.codigoBarra);
                datos.setearParametro("@id_Categoria", producto.categoria.id);
                datos.setearParametro("@id_Marca", producto.marca.id);
                datos.setearParametro("@id_Empaque", producto.empaque.id);
                datos.setearParametro("@Descripcion", producto.descripcion);
                datos.setearParametro("@Stock_min", producto.stock_min);

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
        
        public void ModificarProducto(Producto producto)
        {
            try
            {
                datos.setearConsulta("UPDATE Productos SET CodigoBarras = @CodigoBarras, id_Categoria = @id_Categoria, id_Marca = @id_Marca, id_Empaque = @id_Empaque, Descripcion = @Descripcion, Stock_min = @Stock_min WHERE Producto_id = @id");
                datos.setearParametro("@CodigoBarras", producto.codigoBarra);
                datos.setearParametro("@id_Categoria", producto.categoria.id);
                datos.setearParametro("@id_Marca", producto.marca.id);
                datos.setearParametro("@id_Empaque", producto.empaque.id); // corregido
                datos.setearParametro("@Descripcion", producto.descripcion);
                datos.setearParametro("@Stock_min", producto.stock_min);
                datos.setearParametro("@id", producto.id);

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
        public void EliminarProducto(int eliminar)
        {
            try
            {
                datos.setearConsulta("UPDATE Productos SET Estado = 0 WHERE Producto_id = @id");
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
        public bool ExisteCodigoBarras(string codigo)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Productos WHERE CodigoBarras = @CodigoBarras");
                datos.setearParametro("@CodigoBarras", codigo);
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

        public void AgregarCompraConDetalles(Compra compra, DataTable detalles)///ver luego
        {
            try
            {
                datos.setearProcedure("AgregarCompraConDetalles");
                datos.setearParametro("@idProveedor", compra.proveedor.id);
                datos.setearParametro("@Fecha", compra.fecha);
                datos.setearParametro("@Total", compra.precioTotal);
                datos.setearParametroTablaCompra("@Detalles", detalles);

                datos.ejecutarRead();
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

        public List<Producto> BuscarPorDescripcion(string descripcion)
        {
            List<Producto> producto = new List<Producto>();
            try
            {
                datos.setearConsulta("SELECT p.Producto_id, p.CodigoBarras, p.Descripcion, p.Stock_min, c.Categoria_id, c.Descripcion as Categoria, m.Marca_id, m.Descripcion as Marca, te.Empaque_id, te.CantidadUnidad, te.Descripcion as Empaque\r\nFROM Productos as p\r\nINNER JOIN Categorias as c ON p.id_Categoria = c.Categoria_id\r\nINNER JOIN Marcas as m ON p.id_Marca = m.Marca_id\r\nINNER JOIN TiposEmpaques as te ON p.id_Empaque = te.Empaque_id WHERE p.Estado = 1 AND p.Descripcion LIKE @descripcion");
                datos.setearParametro("@descripcion", "%" + descripcion + "%");
                datos.ejecutarRead();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.id = (int)datos.Lector["Producto_id"];
                    aux.codigoBarra = (string)datos.Lector["CodigoBarras"];

                    aux.categoria = new Categoria();
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.categoria.id = (int)datos.Lector["Categoria_id"];
                        aux.categoria.descripcion = (string)datos.Lector["Categoria"];
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.marca = new Marca();
                        aux.marca.id = (int)datos.Lector["Marca_id"];
                        aux.marca.descripcion = (string)datos.Lector["Marca"];
                    }

                    if (!(datos.Lector["Empaque"] is DBNull))
                    {
                        aux.empaque = new Empaque();
                        aux.empaque.id = (int)datos.Lector["Empaque_id"];
                        aux.empaque.cantidadxUnidad = (decimal)datos.Lector["CantidadUnidad"];
                        aux.empaque.descripcion = (string)datos.Lector["Empaque"];
                    }

                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    aux.stock_min = (decimal)datos.Lector["Stock_min"];

                    producto.Add(aux);
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
            return producto;
        }
    }
}
