using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DBOperacion : DBConexion
    {
        public Int32 EjecutarSentencia(String sentencia)
        {
            Int32 filasAfectadas = 0;
            MySqlCommand Comando = new MySqlCommand();
            if (base.Conectar())
            {
                Comando.Connection = base.conexion;
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = sentencia;
                try
                {
                    filasAfectadas = Comando.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    String Mensaje = e.Message;
                    filasAfectadas = -1;
                }
                base.Desconectar();
            }
            return filasAfectadas;
        }

        public int EjecutarTransaccion(List<string> sentencias)
        {
            int filasAfectadas = 0;
            MySqlCommand comando = new MySqlCommand();
            MySqlTransaction transaction = null;

            if (base.Conectar())
            {
                comando.Connection = base.conexion;
                comando.CommandType = System.Data.CommandType.Text;
                try
                {
                    transaction = base.conexion.BeginTransaction();
                    comando.Transaction = transaction;

                    foreach (string sentencia in sentencias)
                    {
                        comando.CommandText = sentencia;
                        filasAfectadas += comando.ExecuteNonQuery();
                    }

                    if (filasAfectadas >= sentencias.Count)
                    {
                        transaction.Commit(); // Confirmar la transacción si todo se ejecuta correctamente
                    }
                    else
                    {
                        transaction.Rollback();
                        filasAfectadas = -1;
                    }

                    
                }
                catch (Exception)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback(); // Revertir la transacción en caso de error
                    }
                    filasAfectadas = -1;
                }
                finally
                {
                    base.Desconectar();
                }
            }
            return filasAfectadas;
        }



        public DataTable Consultar(String consulta)
        {
            MySqlDataAdapter adaptador = new MySqlDataAdapter();
            MySqlCommand comando = new MySqlCommand();
            DataTable Resultado = new DataTable();
            if (base.Conectar())
            {
                comando.Connection = base.conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;
                adaptador.SelectCommand = comando;
                try
                {
                    adaptador.Fill(Resultado);
                }
                catch (Exception)
                {
                    Resultado = new DataTable();
                }
                base.Desconectar();
            }
            return Resultado;
        }

    }
}