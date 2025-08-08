using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioStockProducto
    {
        ConexionDB datos = new ConexionDB();

        public void AgregarStockProducto(StockProducto stock)
        {
            try
            {
                datos.setearConsulta("INSERT INTO StockProductos (id_Producto, Stock_actual, Precio_unitario) VALUES (@id_Producto, @Stock_actual, @Precio_unitario)");
                datos.setearParametro("@id_Producto", stock.idProducto);
                datos.setearParametro("@Stock_actual", stock.stock_actual);
                datos.setearParametro("@Precio_unitario", stock.precio_unitario);
               
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
        public void ModificarStockProducto(StockProducto stock)
        {
            try
            {
                datos.setearConsulta("UPDATE StockProductos SET Stock_actual = Stock_actual + @Stock_actual, Precio_unitario = @Precio_unitario WHERE id_Producto = @id");
                datos.setearParametro("@Stock_actual", stock.stock_actual);
                datos.setearParametro("@Precio_unitario", stock.precio_unitario);                
                datos.setearParametro("@id", stock.idProducto);

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
        public bool HayStock(StockProducto stock)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM StockProductos WHERE id_Producto = @id_Producto");
                datos.setearParametro("@id_Producto", stock.idProducto);
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
        public StockProducto ObtenerStockPorProducto(int idProducto)
        {
            try
            {
                datos.setearConsulta("SELECT Stock_actual, Precio_unitario FROM StockProductos WHERE id_Producto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    StockProducto stock = new StockProducto();
                    stock.idProducto = idProducto;
                    stock.stock_actual = (decimal)datos.Lector["Stock_actual"];
                    stock.precio_unitario = (decimal)datos.Lector["Precio_unitario"];
                    return stock;
                }
                return null;
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
