using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioStockProducto
    {
        ConexionDB datos = new ConexionDB();

        public void AgregarStockActual(DataTable detalles)
        {
            try
            {
                foreach (DataRow fila in detalles.Rows)
                {
                    int idProducto = Convert.ToInt32(fila["id"]);
                    decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
                    decimal precioCompra = Convert.ToDecimal(fila["PrecioCompra"]);
                    
                    datos.setearConsulta("UPDATE StockProductos SET Stock_actual = Stock_actual + @cantidad WHERE id_Producto = @idProducto");

                    datos.setearParametro("@cantidad", cantidad);
                    datos.setearParametro("@idProducto", idProducto);

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

        public void AgregarStockProducto(int id, decimal stock, decimal precioD, decimal precioN)
        {
            try
            {
                datos.setearConsulta("INSERT INTO StockProductos (id_Producto, Stock_actual, PrecioDia, PrecioNoche) VALUES (@id_Producto, @Stock_actual, @PrecioDia, @PrecioNoche)");
                datos.setearParametro("@id_Producto", id);
                datos.setearParametro("@Stock_actual", stock);
                datos.setearParametro("@PrecioDia", precioD);
                datos.setearParametro("@PrecioNoche", precioN);

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
        public void ModificarPrecioProducto(StockProducto stock)
        {
            try
            {
                datos.setearConsulta("UPDATE StockProductos SET  PrecioDia = @PrecioDia, PrecioNoche = @PrecioNoche WHERE id_Producto = @id");
                datos.setearParametro("@PrecioDia", stock.precio_dia);
                datos.setearParametro("@PrecioNoche", stock.precio_noche);
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
       
        public StockProducto ObtenerStockPorProducto(int idProducto)
        {
            try
            {
                datos.setearConsulta("SELECT Stock_actual, PrecioDia, PrecioNoche FROM StockProductos WHERE id_Producto = @idProducto");
                datos.setearParametro("@idProducto", idProducto);
                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    StockProducto stock = new StockProducto();
                    stock.idProducto = idProducto;
                    stock.stock_actual = (decimal)datos.Lector["Stock_actual"];
                    stock.precio_dia = (decimal)datos.Lector["PrecioDia"];
                    stock.precio_noche = (decimal)datos.Lector["PrecioNoche"];
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
