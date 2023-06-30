using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    class Ingrediente
    {
        /*DECLARACION DE VARIABLES*/
        int idIngrediente;
        int idUnidad;
        string nombre;
        decimal stock;
        decimal precio;

        /*DECLARACION DE PROPIEDADES*/
        public int IdIngrediente { get => idIngrediente; set => idIngrediente = value; }
        public int IdUnidad { get => idUnidad; set => idUnidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public decimal Stock { get => stock; set => stock = value; }
        public decimal Precio { get => precio; set => precio = value; }

        /*OPERACIONES BASICAS*/
        public Boolean Insertar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "INSERT INTO ingrediente(idUnidad, nombre, stock, precio) VALUES(" + idUnidad + ", '" + nombre + "'," + stock + "," + precio + ");";
            try
            {
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        public Boolean Actualizar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "UPDATE ingrediente SET idUnidad = " + idUnidad + ", nombre = '" + nombre + "', stock = " + stock + ", precio = " + precio + " WHERE idIngrediente = " + idIngrediente + ";";
            try
            {
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
        public Boolean Eliminar()
        {
            Boolean resultado = false;
            DataManager.DBOperacion op = new DataManager.DBOperacion();
            string sentencia;
            sentencia = "DELETE FROM ingrediente WHERE idIngrediente = " + idIngrediente + ";";
            try
            {
                int filasAfectadas = 0;
                filasAfectadas = op.EjecutarSentencia(sentencia);
                if (filasAfectadas > 0)
                {
                    resultado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return resultado;
        }
    }
}
