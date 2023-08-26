using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public static class DBConsultas
    {
        public static DataTable IniciarSesion(string pClave)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT r.idRol, r.rol, u.idUsuario, e.idEmpleado, e.nombres
                                    FROM rol r, usuario u, empleado e
                                    WHERE u.idRol=r.idRol AND u.pinCode=MD5('" + pClave + "') AND u.idUsuario=e.idEmpleado;";
                DataManager.DBOperacion operacion = new DataManager.DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }

        }

        public static DataTable Familias()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT * FROM familia;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable Salones()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT * FROM salon;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable Productos(string idfamilia)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT p.idProducto, p.nombre, p.descripcion, p.precio, p.costo, p.inventariable, 
                                    p.conIngrediente, p.stock, p.stockMinimo, p.activo, s.idFamilia, s.familia, s.grupoPrinter 
                                    FROM producto p, familia s
                                    WHERE p.idFamilia=s.idFamilia AND p.idFamilia=" + idfamilia + " AND p.activo=1;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable Mesas(string salon)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT m.idMesa, m.numero, m.nombre, m.capacidad, m.disponible, s.idSalon, s.nombre FROM mesa m, salon s
                                        WHERE m.idSalon=s.idSalon AND m.idSalon=" + salon + ";";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable ProductosEnMesa(string idMesa)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT pe.idPedido, pd.idProducto, pd.cantidad, pd.precio, pro.nombre, pd.subTotal, pe.fecha
                                     FROM pedido pe, pedido_detalle pd, producto pro
                                     WHERE pe.idPedido=pd.idPedido AND pro.idProducto=pd.idProducto AND (pe.idMesa=" + idMesa + @" AND pe.cancelado=0)
                                     order by pd.idpedido, pe.fecha desc;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable Empleados()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT idEmpleado,nombres,apellidos,telefono,email,DUI,NIT,sueldoBase,comision,direccion FROM empleado;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable Roles()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT * FROM rol;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable UsuariosSinRol()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT e.idEmpleado,concat(nombres,' ',apellidos)Empleado FROM  empleado e left join usuario u On e.idEmpleado = u.idUsuario where u.idUsuario is null;";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

        public static DataTable UsuariosSegunRol(String IDROL)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"Select e.idEmpleado,concat(e.nombres,' ',e.apellidos)Empleado From empleado e, usuario u, rol r where e.idEmpleado = u.idUsuario and u.idRol = r.idRol and r.idRol = "+IDROL+";";
                DBOperacion operacion = new DBOperacion();

                resultado = operacion.Consultar(sentencia);
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
                throw;
            }
        }

    }
}

