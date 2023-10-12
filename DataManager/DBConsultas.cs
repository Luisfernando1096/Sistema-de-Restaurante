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

        public static DataTable TicketsFacturados(String nFactura)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia;
                if (nFactura!="")
                {
                    sentencia = @"SELECT p.idPedido, c.nombre, p.fecha, p.total, p.descuento, p.iva, p.propina, p.totalPago, p.saldo,
                                     p.idTiraje, p.nFactura, p.efectivo
                                    FROM pedido p
                                    LEFT JOIN cliente c ON p.idCliente = c.idCliente
                                    WHERE p.nFactura = '" + nFactura + @"' AND p.anular != 1; ";
                }
                else
                {
                    sentencia = @"SELECT p.idPedido, c.nombre, p.fecha, p.total, p.descuento, p.iva, p.propina, p.totalPago, p.saldo,
                                     p.idTiraje, p.nFactura, p.efectivo
                                    FROM pedido p
                                    LEFT JOIN cliente c ON p.idCliente = c.idCliente
                                    WHERE p.nFactura > 0 AND p.anular != 1; ";
                }
                
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

        public static DataTable ObtenerDetallePedidoConIdParaAnular(string text)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT p.nombre, cantidad, pd.precio, subTotal 
                                     FROM pedido_detalle pd, producto p WHERE p.idProducto=pd.idProducto AND pd.idPedido = " + text + ";";
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

        public static DataTable Meseros()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT * FROM empleado;";
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

        public static DataTable ComandosPorRol(String rol)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT c.idComando FROM comando c, rol r, permiso p, usuario u
                                    WHERE p.idComando = c.idComando AND p.idRol = r.idRol AND u.idRol = r.idRol AND r.idRol=" + rol + @" 
                                    group by c.idComando;";
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

        public static DataTable PedidoPorId(int idPedido)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT p.idPedido, p.idCliente, c.nombre, m.nombre as mesa, p.idCuenta, p.idMesero, e.nombres, p.fecha, p.iva, p.descuento, p.propina,
                                     p.totalPago
                                    FROM pedido p
                                    LEFT JOIN cliente c ON p.idCliente = c.idCliente
                                    LEFT JOIN empleado e ON e.idEmpleado = p.idMesero
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

        public static DataTable UsuariosPin(String pin)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = "SELECT * FROM usuario WHERE pinCode=md5(" + pin + ");";
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

        public static DataTable PedidosEnMesa(string idMesa)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT
                                        pd.idPedido
                                    FROM
                                        pedido pe
                                    JOIN
                                        pedido_detalle pd ON pe.idPedido = pd.idPedido
                                    JOIN
                                        producto pro ON pd.idProducto = pro.idProducto
                                    JOIN
                                        mesa m ON pe.idMesa = m.idMesa
                                    WHERE
                                        pe.idMesa = " + idMesa + @"
                                        AND pe.cancelado = 0
                                        AND m.disponible = 0
                                    GROUP BY
                                        pd.idPedido;";
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
                String sentencia = @"SELECT 
                                        pd.idPedido, 
                                        pd.idProducto, 
                                        pd.cantidad, 
                                        pd.precio, 
                                        pro.nombre, 
                                        pd.subTotal, 
                                        pe.fecha,
                                        pd.idDetalle
                                    FROM 
                                        pedido_detalle pd
                                    JOIN 
                                        producto pro ON pd.idProducto = pro.idProducto
                                    JOIN 
                                        (SELECT pe.idPedido, pe.idMesa, pe.fecha
                                         FROM pedido pe
                                         JOIN mesa m ON pe.idMesa = m.idMesa
                                         WHERE pe.idMesa = " + idMesa + @" 
                                           AND pe.cancelado = 0 
                                           AND m.disponible = 0
                                         ORDER BY pe.fecha ASC
                                         LIMIT 1) AS pe ON pd.idPedido = pe.idPedido
                                    ORDER BY 
                                        pd.horaPedido DESC;";
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

        public static object ProductosEnMesaConIdPedido(string idMesa, int idPedido)
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT 
                                        pd.idPedido, 
                                        pd.idProducto, 
                                        pd.cantidad, 
                                        pd.precio, 
                                        pro.nombre, 
                                        pd.subTotal, 
                                        pe.fecha,
                                        pd.idDetalle
                                    FROM 
                                        pedido_detalle pd
                                    JOIN 
                                        producto pro ON pd.idProducto = pro.idProducto
                                    JOIN 
                                        (SELECT pe.idPedido, pe.idMesa, pe.fecha
                                         FROM pedido pe
                                         JOIN mesa m ON pe.idMesa = m.idMesa
                                         WHERE pe.idMesa = " + idMesa + @"
                                         AND pe.idPedido = " + idPedido + @"
                                           AND pe.cancelado = 0 
                                           AND m.disponible = 0
                                         ORDER BY pe.fecha ASC
                                         LIMIT 1) AS pe ON pd.idPedido = pe.idPedido
                                    ORDER BY 
                                        pd.horaPedido DESC;";
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
        public static DataTable Cuentas()
        {
            try
            {
                DataTable resultado = new DataTable();
                string sentencia = "SELECT * FROM cuenta;";
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

        public static DataTable Cajas(Boolean soloAbiertas)
        {
            try
            {
                DataTable resultado = new DataTable();
                string sentencia;
                if (soloAbiertas)
                {
                    sentencia = @"SELECT
                                    c.idCaja,
                                    c.idCajero,
                                    c.estado,
                                    c.fechaApertura,
                                    c.fechaCierre,
                                    c.saldoInicial,
                                    c.efectivo,
                                    c.saldo,
                                    e.nombres,
                                    COALESCE(SUM(eg.cantidad), 0) AS cantidad
                                FROM
                                    caja c
                                LEFT JOIN
                                    empleado e ON c.idCajero = e.idEmpleado
                                LEFT JOIN
                                    egreso eg ON e.idEmpleado = eg.idUsuario AND eg.idCaja = c.idCaja AND c.estado = 1
                                WHERE c.estado = 1
                                GROUP BY
                                    c.idCaja,  
                                    c.idCajero,
                                    c.estado,
                                    c.fechaApertura,
                                    c.fechaCierre,
                                    c.saldoInicial,
                                    c.efectivo,
                                    c.saldo,
                                    e.nombres;";
                }
                else
                {
                    sentencia = @"SELECT
                                c.idCaja,
                                c.idCajero,
                                c.estado,
                                c.fechaApertura,
                                c.fechaCierre,
                                c.saldoInicial,
                                c.efectivo,
                                c.saldo,
                                e.nombres,
                                COALESCE(SUM(eg.cantidad), 0) AS cantidad
                            FROM
                                caja c
                            LEFT JOIN
                                empleado e ON c.idCajero = e.idEmpleado
                            LEFT JOIN
                                egreso eg ON e.idEmpleado = eg.idUsuario AND eg.idCaja = c.idCaja
                            GROUP BY
                                c.idCaja,  
                                c.idCajero,
                                c.estado,
                                c.fechaApertura,
                                c.fechaCierre,
                                c.saldoInicial,
                                c.efectivo,
                                c.saldo,
                                e.nombres;";
                }
                
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

        public static DataTable ObtenerTirajeActual()
        {
            try
            {
                DataTable resultado = new DataTable();
                string sentencia = @"SELECT idTiraje, actual, fin FROM tiraje_factura where activo=1;";
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

        public static DataTable CajaAbierta()
        {
            try
            {
                DataTable resultado = new DataTable();
                string sentencia = @"SELECT c.idCaja, c.idCajero, c.estado, c.fechaApertura, c.fechaCierre,
                                     c.saldoInicial, c.efectivo, c.saldo, e.nombres FROM caja c, empleado e WHERE c.idCajero = e.idEmpleado AND c.estado = 1; ";
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
        public static DataTable Egreso()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em where e.idUsuario = em.idEmpleado;";
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
        public static DataTable ConsultaFiltros1(string txtFechaDesde, string txtFechaHasta)
        {
            try
            {
                DataTable resultado = new DataTable();
                DBOperacion operacion = new DBOperacion();

                if (txtFechaHasta == string.Empty & txtFechaDesde == string.Empty)
                {
                    String sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em where e.idUsuario = em.idEmpleado;";
                    resultado = operacion.Consultar(sentencia);

                }
                else if (txtFechaDesde != string.Empty & txtFechaHasta == string.Empty)
                {
                    if (DateTime.TryParse(txtFechaDesde, out DateTime fechaConvertida))
                    {
                        string fechaConvertidaString = fechaConvertida.ToString("yyyy-MM-dd");
                        if (txtFechaDesde == fechaConvertidaString)
                        {
                            string sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em WHERE e.idUsuario = em.idEmpleado AND e.fecha >= '" + txtFechaDesde + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else if (txtFechaDesde == string.Empty & txtFechaHasta != string.Empty)
                {
                    if (DateTime.TryParse(txtFechaHasta, out DateTime fechaConvertida))
                    {
                        string fechaConvertidaString = fechaConvertida.ToString("yyyy-MM-dd");
                        if (txtFechaHasta == fechaConvertidaString)
                        {
                            string sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em WHERE e.idUsuario = em.idEmpleado AND e.fecha  <= '" + txtFechaHasta + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else if (txtFechaDesde != string.Empty & txtFechaHasta != string.Empty)
                {
                    if (DateTime.TryParse(txtFechaDesde, out DateTime fechaConvertidaDesde) && DateTime.TryParse(txtFechaHasta, out DateTime fechaConvertidaHasta))
                    {
                        string fechaConvertidaStringDesde = fechaConvertidaDesde.ToString("yyyy-MM-dd");
                        string fechaConvertidaStringHasta = fechaConvertidaHasta.ToString("yyyy-MM-dd");

                        if ((txtFechaDesde == fechaConvertidaStringDesde)&&(txtFechaHasta == fechaConvertidaStringHasta))
                        {
                            string nuevoTxtDesde = txtFechaDesde + " 00:00:00";
                            string nuevoTxtHasta = txtFechaHasta + " 23:59:59";

                            string sentencia = "SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em WHERE e.idUsuario = em.idEmpleado AND e.fecha >= '" + txtFechaDesde + "' AND e.fecha  <= '" + nuevoTxtHasta + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else
                {
                    return new DataTable();
                }
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public static DataTable ConsultaFiltros2(string txtFechaDesde, string txtFechaHasta, int cmbID)
        {
            try
            {
                DataTable resultado = new DataTable();
                DBOperacion operacion = new DBOperacion();

                if (cmbID == 0 & txtFechaHasta == string.Empty & txtFechaDesde == string.Empty)
                {
                    String sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em where e.idUsuario = em.idEmpleado;";
                    resultado = operacion.Consultar(sentencia);
                }
                else if (cmbID != 0 & txtFechaDesde == string.Empty & txtFechaHasta == string.Empty)
                {
                    String sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em where e.idUsuario = em.idEmpleado and e.idCaja = " + cmbID + ";";
                    resultado = operacion.Consultar(sentencia);
                }
                else if (cmbID != 0 & txtFechaDesde != string.Empty & txtFechaHasta == string.Empty)
                {
                    if (DateTime.TryParse(txtFechaDesde, out DateTime fechaConvertida))
                    {
                        string fechaConvertidaString = fechaConvertida.ToString("yyyy-MM-dd");
                        if (txtFechaDesde == fechaConvertidaString)
                        {
                            string sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em  WHERE e.idUsuario = em.idEmpleado AND e.idCaja = " + cmbID + " AND e.fecha >= '" + txtFechaDesde + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else if (cmbID != 0 & txtFechaDesde == string.Empty & txtFechaHasta != string.Empty)
                {
                    if (DateTime.TryParse(txtFechaHasta, out DateTime fechaConvertida))
                    {
                        string fechaConvertidaString = fechaConvertida.ToString("yyyy-MM-dd");
                        if (txtFechaHasta == fechaConvertidaString)
                        {
                            string sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em  WHERE e.idUsuario = em.idEmpleado AND e.idCaja = " + cmbID + " AND e.fecha  <= '" + txtFechaHasta + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else if (cmbID != 0 & txtFechaDesde != string.Empty & txtFechaHasta != string.Empty)
                {
                    if (DateTime.TryParse(txtFechaDesde, out DateTime fechaConvertidaDesde) && DateTime.TryParse(txtFechaHasta, out DateTime fechaConvertidaHasta))
                    {
                        string fechaConvertidaStringDesde = fechaConvertidaDesde.ToString("yyyy-MM-dd");
                        string fechaConvertidaStringHasta = fechaConvertidaHasta.ToString("yyyy-MM-dd");

                        if ((txtFechaDesde == fechaConvertidaStringDesde) && (txtFechaHasta == fechaConvertidaStringHasta))
                        {
                            string nuevoTxtDesde = txtFechaDesde + " 00:00:00";
                            string nuevoTxtHasta = txtFechaHasta + " 23:59:59";

                            string sentencia = @"SELECT e.idEgreso, e.idCaja, em.nombres, e.fecha, e.descripcion, e.cantidad FROM egreso e, empleado em  WHERE e.idUsuario = em.idEmpleado AND e.idCaja = " + cmbID + " AND e.fecha BETWEEN '" + nuevoTxtDesde + "' AND'" + nuevoTxtHasta + "'";
                            resultado = operacion.Consultar(sentencia);
                        }
                        else
                        {
                            return new DataTable();
                        }
                    }
                    else
                    {
                        return new DataTable();
                    }
                }
                else
                {
                    return new DataTable();
                }
                return resultado;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        public static DataTable Mesas()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select m.idMesa, m.numero,m.nombre nomMesa, m.capacidad, m.disponible,s.idSalon, s.nombre, s.fondo, s.nMesas from mesa m, salon s where m.idSalon  = s.idSalon;";
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
        public static DataTable Comprobante()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select idComprobante, tipo from comprobante";
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

        public static DataTable Proveedor()
        {
            try
            {
                DataTable resultado = new DataTable();
                String sentencia = @"select idProveedor, nombre, NIT, telefono,email,regContable, contacto, direccion from proveedor";
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

