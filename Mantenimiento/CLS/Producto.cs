using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Producto
    {
        int idProducto;
        int idFamilia;
        int idUnidad;
        String nombre;
        String descripcion;
        double precio;
        double costo;
        Byte[] foto;
        int inventariable;
        int conIngrediente;
        int stock;
        int stockMinimo;
        int activo;

        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int IdFamilia { get => idFamilia; set => idFamilia = value; }
        public int IdUnidad { get => idUnidad; set => idUnidad = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public double Costo { get => costo; set => costo = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public int Inventariable { get => inventariable; set => inventariable = value; }
        public int ConIngrediente { get => conIngrediente; set => conIngrediente = value; }
        public int Stock { get => stock; set => stock = value; }
        public int StockMinimo { get => stockMinimo; set => stockMinimo = value; }
        public int Activo { get => activo; set => activo = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"INSERT INTO producto(idFamilia, idUnidad, nombre, descripcion, precio, costo, foto, inventariable, conIngrediente, stock, stockMinimo, activo) VALUES(" + idFamilia + ", " + idUnidad + ", '" + nombre + "', '" + descripcion + "', " + precio + ", " + costo + ", '" + foto + "', " + inventariable + ", " + conIngrediente + ", " + stock + ", " + stockMinimo + ", " + activo + ");";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
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

        public Boolean ActualizarStockProductos()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"update producto SET stock = " + stock + " where idProducto =" + idProducto + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasActualizadas = 0;
                filasActualizadas = op.EjecutarSentencia(sentencia);
                if (filasActualizadas > 0)
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
            string sentencia;
            sentencia = "UPDATE producto SET idFamilia = " + idFamilia + ", idUnidad = " + idUnidad + ", nombre = '" + nombre + "', descripcion = '" + descripcion + "', precio = " + precio + ", costo = " + costo + ", foto = '" + foto + "', inventariable = " + inventariable + ", conIngrediente = " + conIngrediente + ", stock = " + stock + ", stockMinimo = " + stockMinimo + ", activo = " + activo + " WHERE idProducto = " + idProducto + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasActualizadas = 0;
                filasActualizadas = op.EjecutarSentencia(sentencia);
                if (filasActualizadas > 0)
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
            string sentencia;
            sentencia = @"DELETE FROM producto " +
                "WHERE idProducto = " + idProducto + ";";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasEliminadas = 0;
                filasEliminadas = op.EjecutarSentencia(sentencia);
                if (filasEliminadas > 0)
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
