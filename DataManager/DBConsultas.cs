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

        public static DataTable PedidoPorId(int idPedido)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT p.idPedido, c.nombre, m.nombre as mesa, p.idCuenta, p.idMesero, p.fecha, p.iva, p.descuento, p.propina,
                                     p.totalPago
                                    FROM pedido p
                                    LEFT JOIN cliente c ON p.idCliente = c.idCliente
                                    JOIN mesa m ON p.idMesa = m.idMesa
                                    WHERE p.idPedido = " + idPedido + "; ";
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

        public static DataTable Clientes()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = "SELECT idCliente, nombre, direccion, email, telefono, NIT, regContable FROM cliente;";
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
        public static DataTable UltimoPedido()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = "SELECT idPedido FROM pedido order by idPedido desc limit 1;";
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

        public static DataTable ObtenerPrecioDeProducto(int id)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT precio FROM producto
                                    WHERE idProducto = " + id + "; ";
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

        public static DataTable ObtenerDetallePedidoConId(int id)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT idDetalle, cocinando, extras, horaEntregado, horaPedido, idCocinero, idProducto, idPedido, cantidad, precio, subTotal, grupo, usuario, fecha FROM pedido_detalle
                                    WHERE idDetalle= " + id + "; ";
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
        public static DataTable Configuraciones()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = "SELECT idConfiguracion, controlStock, incluirPropina, propina, incluirImpuesto, iva, mesaVIP, autorizarDescProp, printerComanda, printerFactura, printerInformes, alertaCaja, multisesion, numSesiones, muchosProductos FROM configuracion;";
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

        public static DataTable MesasOcupadas(string salon)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT m.idMesa, m.numero, m.nombre, m.capacidad, m.disponible, s.idSalon, s.nombre FROM mesa m, salon s
                                        WHERE m.idSalon=s.idSalon AND m.idSalon=" + salon + " AND m.disponible = 0;";
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
        public static DataTable VerProductos()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select p.idProducto, f.familia, u.unidadMedida, p.nombre, p.descripcion, p.precio, p.costo, p.foto, p.inventariable, p.conIngrediente, p.stock, p.stockMinimo, p.activo from producto p, familia f, unidadmedida u where p.idFamilia = f.idFamilia and p.idUnidad = u.idUnidad;";
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
        public static DataTable ListaProductos()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT idProducto, nombre FROM producto;";
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
        public static DataTable VerFamilia()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select idFamilia, familia, grupoPrinter, activo from familia;";
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
        public static DataTable VerUnidad()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select * from unidadmedida;";
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
        public static DataTable VerIngrediente()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select i.idIngrediente, i.nombre, u.unidadMedida, i.stock, i.precio from ingrediente i, unidadmedida u where i.idUnidad = u.idUnidad;";
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
        public static DataTable VerReceta()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select i.idIngrediente, i.nombre, ip.cantidad from ingrediente i, ingrediente_producto ip where ip.idIngrediente = i.idIngrediente;";
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
        public static DataTable VerStock()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT aj.idAjuste, aj.idProducto, p.nombre AS producto, aj.idIngrediente, i.nombre AS ingredientes, aj.tipoAjuste, aj.cantidad, aj.justificacion, aj.fecha, u.idUsuario
                                        FROM ajuste_stock aj
                                        LEFT JOIN producto p ON aj.idProducto = p.idProducto
                                        LEFT JOIN ingrediente i ON aj.idIngrediente = i.idIngrediente
                                        INNER JOIN usuario u ON aj.idUsuario = u.idUsuario;";
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
        public static DataTable ProductosActivos()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT aj.idAjuste, aj.idProducto, p.nombre as producto, aj.tipoAjuste, aj.cantidad, aj.justificacion, aj.fecha, u.idUsuario FROM ajuste_stock aj, producto p, usuario u where aj.idProducto = p.idProducto and aj.idUsuario = u.idUsuario;";
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
        public static DataTable IngredientesActivos()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT aj.idAjuste, aj.idIngrediente, i.nombre as ingredientes, aj.tipoAjuste, aj.cantidad, aj.justificacion, aj.fecha, u.idUsuario FROM ajuste_stock aj, ingrediente i, usuario u where aj.idIngrediente = i.idIngrediente and aj.idUsuario = u.idUsuario;";
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

