using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantenimiento.CLS
{
    public class Compra
    {
        int _idCompra;
        String _tipoCompra;
        int _idProveedor;
        int _idComprobante;
        String _nComprobante;
        int _idUsuario;
        String _fecha;
        double _total;
        double _descuento;
        double _iva;
        double _totalPago;

        public int IdCompra { get => _idCompra; set => _idCompra = value; }
        public string TipoCompra { get => _tipoCompra; set => _tipoCompra = value; }
        public int IdProveedor { get => _idProveedor; set => _idProveedor = value; }
        public int IdComprobante { get => _idComprobante; set => _idComprobante = value; }
        public string NComprobante { get => _nComprobante; set => _nComprobante = value; }
        public int IdUsuario { get => _idUsuario; set => _idUsuario = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public double Total { get => _total; set => _total = value; }
        public double Descuento { get => _descuento; set => _descuento = value; }
        public double Iva { get => _iva; set => _iva = value; }
        public double TotalPago { get => _totalPago; set => _totalPago = value; }

        public Boolean Insertar(out int idInsertado)
        {
            Boolean resultado = false;
            idInsertado = -1; // Valor predeterminado en caso de error
            string sentencia;
            sentencia = @"insert into compra(tipoCompra,idProveedor,idComprobante,nComprobante,idUsuario,fecha,total,descuento,iva,totalPago) values('"+_tipoCompra+"',"+_idProveedor+","+_idComprobante+",'"+_nComprobante+"',"+_idUsuario+",'"+_fecha+"',"+_total+","+_descuento+","+_iva+","+_totalPago+");";

            try
            {
                DataManager.DBOperacion op = new DataManager.DBOperacion();
                Int32 filasInsertadas = 0;
                filasInsertadas = op.EjecutarSentencia(sentencia);
                if (filasInsertadas > 0)
                {
                    resultado = true;

                    // Ahora, obtén el ID del pedido insertado usando una consulta adicional
                    string consultaId = "SELECT LAST_INSERT_ID();";
                    idInsertado = Convert.ToInt32(op.ConsultarScalar(consultaId));
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
            sentencia = @"update compra set tipoCompra = '"+_tipoCompra+"', idProveedor = "+_idProveedor+", idComprobante = "+_idComprobante+", nComprobante ='"+_nComprobante+"', idUsuario = "+_idUsuario+", fecha = '"+_fecha+"', total = "+_total+", descuento = "+_descuento+", iva = "+_iva+", totalPago = "+_totalPago+" where idCompra = "+_idCompra+";";

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
            sentencia = @"delete from compra where idCompra = "+_idCompra+";";

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
