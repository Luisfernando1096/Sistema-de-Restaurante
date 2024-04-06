using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

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
                catch (Exception e)
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

        public int? ConsultarScalar(String consulta)
        {
            int? resultado = null;
            MySqlCommand comando = new MySqlCommand();

            if (base.Conectar())
            {
                comando.Connection = base.conexion;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = consulta;

                try
                {
                    var scalarResult = comando.ExecuteScalar();
                    if (scalarResult != null && scalarResult != DBNull.Value)
                    {
                        resultado = Convert.ToInt32(scalarResult); // Ejecuta la consulta y obtiene un valor escalar
                    }
                }
                catch (Exception)
                {
                    resultado = null;
                }

                base.Desconectar();
            }

            return resultado;
        }

        public (bool, TimeSpan) Respaldo(string ruta)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool respaldoExitoso = false;

            try
            {
                MySqlConnection conexion = new MySqlConnection();
                MySqlCommand Comando = new MySqlCommand();
                MySqlBackup bk = new MySqlBackup(Comando);

                if (base.Conectar())
                {
                    Comando.Connection = base.conexion;

                    // Inicia el cronómetro
                    stopwatch.Start();

                    try
                    {
                        bk.ExportToFile(ruta);
                        respaldoExitoso = true;
                    }
                    catch (Exception e)
                    {
                        String Mensaje = e.Message;
                    }

                    // Detiene el cronómetro
                    stopwatch.Stop();

                    base.Desconectar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el respaldo: {ex.Message}");
                Console.WriteLine($"Trace de la Pila: {ex.StackTrace}");
            }
            return (respaldoExitoso, stopwatch.Elapsed);
        }


        public (bool, TimeSpan) RestaurarRespaldo(string ruta)
        {
            Stopwatch stopwatch = new Stopwatch();
            bool restauracionExitosa = false;
            try
            {
                MySqlConnection conexion = new MySqlConnection();
                MySqlCommand comando = new MySqlCommand();
                MySqlBackup bk = new MySqlBackup(comando);

                if (base.Conectar())
                {
                    comando.Connection = base.conexion;

                    // Inicia el cronómetro
                    stopwatch.Start();

                    try
                    {
                        bk.ImportFromFile(ruta);
                        restauracionExitosa = true;
                    }
                    catch (Exception e)
                    {
                        restauracionExitosa = false;
                        String Mensaje = e.Message;
                    }

                    // Detiene el cronómetro
                    stopwatch.Stop();

                    base.Desconectar();
                }
                else
                {
                    restauracionExitosa = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al restaurar el respaldo: {ex.Message}");
                Console.WriteLine($"Trace de la Pila: {ex.StackTrace}");
                // En caso de error, la restauración no fue exitosa
                restauracionExitosa = false;
            }
            return (restauracionExitosa, stopwatch.Elapsed);
        }

        public bool EjecutarScript(List<string> sentencias)
        {
            bool resultado = false;
            int comandosEjecutados = 0;
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
                        int resultadoSentencia = comando.ExecuteNonQuery();
                        if (resultadoSentencia >= 0) // Aquí puedes ajustar la condición según tus necesidades
                        {
                            comandosEjecutados++;
                        }
                    }

                    if (comandosEjecutados == sentencias.Count)
                    {
                        transaction.Commit();
                        resultado = true;
                    }
                    else
                    {
                        transaction.Rollback();
                    }
                }
                catch (Exception e)
                {
                    if (transaction != null)
                    {
                        transaction.Rollback(); // Revertir la transacción en caso de error
                    }
                }
                finally
                {
                    base.Desconectar();
                }
            }
            return resultado;
        }
    }
}