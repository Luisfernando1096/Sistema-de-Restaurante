using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public  class Ajuste_Stock
    {
        int _idAjuste;
        int _idProducto;
        int _idIngrediente;
        String _tipoAjuste;
        double _cantidad;
        String _justificacion;
        String _fecha;
        int _idUsuario;

        public int IdAjuste { get => _idAjuste; set => _idAjuste = value; }
        public int IdProducto { get => _idProducto; set => _idProducto = value; }
        public int IdIngrediente { get => _idIngrediente; set => _idIngrediente = value; }
        public string TipoAjuste { get => _tipoAjuste; set => _tipoAjuste = value; }
        public double Cantidad { get => _cantidad; set => _cantidad = value; }
        public string Justificacion { get => _justificacion; set => _justificacion = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into ajuste_stock(idProducto,idIngrediente,tipoAjuste,Cantidad,justificacion,fecha,idUsuario) values("+_idProducto+","+_idIngrediente+",'"+_tipoAjuste+"',"+_cantidad+",'"+_justificacion+"','"+_fecha+"',"+_idUsuario+");";

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

        public Boolean Actualizar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"update ajuste_stock set idProducto = "+_idProducto+",idIngrediente = "+_idIngrediente+",tipoAjuste='"+_tipoAjuste+"',cantidad = "+_cantidad+",justificacion = '"+_justificacion+"',fecha='"+_fecha+"',idUsuario = "+_idUsuario+" where idAjuste ="+_idAjuste+";";

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
            sentencia = @"delete from ajuste_stock where idAjuste = "+_idAjuste+";";

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
