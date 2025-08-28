using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioProducto
    {
        ConexionDB datos = new ConexionDB();

        public List<Producto> ListarProducto()
        {
            List<Producto> productos = new List<Producto>();
            try
            {
                datos.setearConsulta("SELECT p.Producto_id, p.CodigoBarras, p.Descripcion, p.Stock_min, p.Stock_max, c.Categoria_id, c.Descripcion as Categoria, m.Marca_id, m.Descripcion as Marca, um.Unidad_id, um.Descripcion as Medida\r\nFROM Productos as p\r\nINNER JOIN Categorias as c ON p.id_Categoria = c.Categoria_id\r\nINNER JOIN Marcas as m ON p.id_Marca = m.Marca_id\r\nINNER JOIN UnidadesMedidas as um ON p.id_Unidad = um.Unidad_id\r\nWHERE p.Estado = 1;");
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

                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Medida"] is DBNull))
                    {
                        aux.unidad = new UnidadMedida();
                        aux.unidad.id = (int)datos.Lector["Unidad_id"];
                        aux.unidad.descripcion = (string)datos.Lector["Medida"];
                    }

                    aux.stock_min = (decimal)datos.Lector["Stock_min"];
                    aux.stock_max = (decimal)datos.Lector["Stock_max"];

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
                datos.setearConsulta("INSERT INTO Productos (CodigoBarras, id_Categoria, id_Marca, id_Unidad, Descripcion, Stock_min, Stock_max) VALUES (@CodigoBarras, @id_Categoria, @id_Marca, @id_Unidad, @Descripcion, @Stock_min, @Stock_max) SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@CodigoBarras", producto.codigoBarra);
                datos.setearParametro("@id_Categoria", producto.categoria.id);
                datos.setearParametro("@id_Marca", producto.marca.id);
                datos.setearParametro("@id_Unidad", producto.unidad.id);
                datos.setearParametro("@Descripcion", producto.descripcion);
                datos.setearParametro("@Stock_min", producto.stock_min);
                datos.setearParametro("@Stock_max", producto.stock_max);

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
                datos.setearConsulta("UPDATE Productos SET CodigoBarras = @CodigoBarras, id_Categoria = @id_Categoria, id_Marca = @id_Marca, id_Unidad = @id_Unidad, Descripcion = @Descripcion, Stock_min = @Stock_min, Stock_max = @Stock_max WHERE Producto_id = @id");
                datos.setearParametro("@CodigoBarras", producto.codigoBarra);
                datos.setearParametro("@id_Categoria", producto.categoria.id);
                datos.setearParametro("@id_Marca", producto.marca.id);
                datos.setearParametro("@id_Unidad", producto.unidad.id);
                datos.setearParametro("@Descripcion", producto.descripcion);
                datos.setearParametro("@Stock_min", producto.stock_min);
                datos.setearParametro("@Stock_max", producto.stock_max);
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
    }
}
