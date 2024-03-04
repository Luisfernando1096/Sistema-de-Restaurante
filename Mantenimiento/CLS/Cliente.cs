using System;

namespace Mantenimiento.CLS
{
    public class Cliente
    {
        String _idCliente;
        String _regContable;
        String _nombre;
        String _codActividad;
        String _desActividad;
        Direccion _direccion;
        String _telefono;
        String _email;
        String _NIT;
        Documento _tipoDocumento;


        public String IdCliente { get => _idCliente; set => _idCliente = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string NIT { get => _NIT; set => _NIT = value; }
        public string RegContable { get => _regContable; set => _regContable = value; }
        public Direccion Direccion { get => _direccion; set => _direccion = value; }
        public string CodActividad { get => _codActividad; set => _codActividad = value; }
        public string DesActividad { get => _desActividad; set => _desActividad = value; }
        public Documento TipoDocumento { get => _tipoDocumento; set => _tipoDocumento = value; }

        public Boolean Insertar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"insert into cliente(nombre,idDireccion,email,telefono,NIT,regContable,codActividad,desActividad,idDocumento) values('" + _nombre + "'," + DireccionNull() + "," + EmailNull() + "," + TelefonoNull() + ",'" + _NIT + "'," + RegContNull() + "," + CodActividadNull() + "," + DescActividadNull() + ",'" + _tipoDocumento.IdDocumento + "');";

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

        private String DireccionNull()
        {
            if (_direccion.IdDireccion == null || _direccion.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return _direccion.IdDireccion;
            }
        }

        private String EmailNull()
        {
            if (_email == null || _email.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return "'" + _email + "'";
            }
        }

        private String TelefonoNull()
        {
            if (_telefono == null || _telefono.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return "'" + _telefono + "'";
            }
        }

        private String RegContNull()
        {
            if (_regContable == null || _regContable.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return "'" + _regContable + "'";
            }
        }

        private String CodActividadNull()
        {
            if (_codActividad == null || _codActividad.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return "'" + _codActividad + "'";
            }
        }

        private String DescActividadNull()
        {
            if (_desActividad == null || _desActividad.Equals(""))
            {
                return "NULL";
            }
            else
            {
                return "'" + _desActividad + "'";
            }
        }

        public Boolean Actualizar()
        {
            Boolean resultado = false;
            string sentencia;
            sentencia = @"update cliente set nombre = '" + _nombre + "', idDireccion = " + DireccionNull() + ", email = " + EmailNull() + ", telefono = " + TelefonoNull() + ", NIT = '" + _NIT + "', regContable = " + RegContNull() + ", codActividad = " + CodActividadNull() + ", desActividad = " + DescActividadNull() + ", idoDocumento = '" + _tipoDocumento.IdDocumento + "' WHERE idCliente = " + _idCliente + ";";

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
            sentencia = @"delete from cliente where idCliente = " + _idCliente + ";";

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
