using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ConexionDB
    {
        private SqlConnection conection;
        private SqlCommand command;
        private SqlDataReader reader;

        public SqlDataReader Lector
        {
            get { return reader; }
        }
        public ConexionDB()
        {
            string cadenaConexion = ConfigurationManager.AppSettings["cadenaConexion"];
            conection = new SqlConnection(cadenaConexion);
            command = new SqlCommand();
        }
        public void setearConsulta(string consulta)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = consulta; 
        }
        public void setearParametro(string nombre, object valor)
        {
            command.Parameters.AddWithValue(nombre, valor);
        }
        public void setearProcedure(string SP)
        {
            command.Parameters.Clear();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = SP;
        }
        public void setearParametroTablaCompra(string nombre, DataTable tabla)
        {
            SqlParameter param = new SqlParameter(nombre, SqlDbType.Structured);
            param.TypeName = "dbo.DetalleCompraType";
            param.Value = tabla;
            command.Parameters.Add(param);
        }
        public void setearParametroTablaVenta(string nombre, DataTable tabla)
        {
            SqlParameter param = new SqlParameter(nombre, SqlDbType.Structured);
            param.TypeName = "dbo.DetalleVentaType";
            param.Value = tabla;
            command.Parameters.Add(param);
        }
        public void ejecutarAccion()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conection.Close();
            }
        }
        public int ejecutarScalar()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                return int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conection.Close();
            }
        }
        public void ejecutarRead()
        {
            command.Connection = conection;
            try
            {
                conection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void cerrarConexion()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conection.Close();
        }
    }
}
