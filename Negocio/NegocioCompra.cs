using Dominio;
using System;
using System.Collections.Generic;
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
        public int AgregarCompra(Compra compra)
        {
            int id = 0;

            try
            {
                datos.setearConsulta("INSERT INTO Compras (id_Proveedor, Fecha, Total_importe) VALUES (@id_Proveedor, @Fecha, @Total_importe) SELECT SCOPE_IDENTITY();");
                datos.setearParametro("@id_Proveedor", compra.proveedor.id);
                datos.setearParametro("@Fecha", compra.fecha);
                datos.setearParametro("@Total_importe", compra.precioTotal);

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
    }
}
