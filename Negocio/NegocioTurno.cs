using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioTurno
    {
        private ConexionDB datos = new ConexionDB();

        public int AbrirTurno(int idUsuario)
        {
            int idTurno = 0;
            try
            {
                datos.setearProcedure("AbrirTurnoCajero");
                datos.setearParametro("@idUsuario", idUsuario);
                datos.setearParametro("@FechaInicio", DateTime.Now);

                idTurno = datos.ejecutarScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return idTurno;
        }

        public Turno CerrarTurno(int idTurno, DateTime fechaFin)
        {
            Turno turnoCerrado = new Turno();
            try
            {
                datos.setearProcedure("CerrarTurnoCajero");
                datos.setearParametro("@idTurno", idTurno);
                datos.setearParametro("@FechaFin", fechaFin);

                datos.ejecutarRead();

                if (datos.Lector.Read())
                {
                    turnoCerrado.id = (int)datos.Lector["Turno_id"];                    
                    turnoCerrado.usuario.id = (int)datos.Lector["Usuario_id"];
                    turnoCerrado.fechaInicio = (DateTime)datos.Lector["FechaInicio"];
                    turnoCerrado.fechaFin = (DateTime)datos.Lector["FechaFin"];
                    turnoCerrado.montoRecaudado = (decimal)datos.Lector["MontoRecaudado"];
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

            return turnoCerrado;
        }

    }
}
