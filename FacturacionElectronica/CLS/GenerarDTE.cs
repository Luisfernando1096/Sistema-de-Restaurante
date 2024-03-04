using Mantenimiento.CLS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionElectronica.CLS
{
    public class GenerarDTE
    {

        ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
        List<PagoCombinado> lstPago_Combinado = new List<PagoCombinado>();
        List<PedidoDetalle> lstPedido_Detalle = new List<PedidoDetalle>();

        public GenerarDTE(List<PagoCombinado> lst, List<PedidoDetalle> lstPd)
        {
            lstPago_Combinado = lst;
            lstPedido_Detalle = lstPd;
        }

        public dteJson GenerarFactura()
        {
            dteJson nuevoJson = null;
            try
            {

                nuevoJson = new dteJson
                {
                    identificacion = new identificacion
                    {
                        version = 1,
                        ambiente = "00",
                        tipoDte = "01",
                        numeroControl = "DTE-01-12345678-000000000000001",
                        codigoGeneracion = "C6A9868C-028D-421B-A9A0-36274CECC2C7",
                        tipoModelo = 1,
                        tipoOperacion = 1,
                        tipoContingencia = null,
                        motivoContin = null,
                        fecEmi = "2022-11-28",
                        horEmi = "10:19:44",
                        tipoMoneda = "USD"
                    },
                    documentoRelacionado = null,

                    emisor = new emisor
                    {
                        nit = oEmpresa.Nit,
                        nrc = oEmpresa.Nrc,
                        nombre = oEmpresa.NombreEmpresa,
                        codActividad = oEmpresa.CodActividad.ToString(),
                        descActividad = oEmpresa.DesActividad,
                        nombreComercial = null,
                        tipoEstablecimiento = oEmpresa.CodEstablecimiento.ToString("00"),
                        direccion = new direccion
                        {
                            departamento = oEmpresa.CodDepartamento.ToString("00"),
                            municipio = oEmpresa.CodMunicipio.ToString("00"),
                            complemento = oEmpresa.Complemento
                        },
                        telefono = oEmpresa.Telefono,
                        correo = oEmpresa.Correo,
                        codEstableMH = null,
                        codEstable = null,
                        codPuntoVentaMH = null,
                        codPuntoVenta = null
                    },

                    receptor = new receptor
                    {
                        nrc = null,
                        nombre = "SALVADOR CABAL",
                        codActividad = "00069",
                        descActividad = "ACTIVIDADES JURÍDICAS Y CONTABLES",
                        direccion = new direccion
                        {
                            departamento = "06",
                            municipio = "14",
                            complemento = "Dirección de Prueba 1, N°1234"
                        },
                        telefono = "22444444",
                        correo = "salvadorcabal@prueba.com",
                        numDocumento = "054118871",
                        tipoDocumento = "36"

                    },

                    otrosDocumentos = null,

                    ventaTercero = null,

                    cuerpoDocumento = AgregarCuerpo(),

                    resumen = new resumen
                    {
                        totalNoSuj = 0,
                        totalExenta = 0,
                        totalGravada = 2000,
                        subTotalVentas = 2000,
                        descuNoSuj = 0,
                        descuExenta = 0,
                        descuGravada = 0,
                        porcentajeDescuento = 0,
                        totalDescu = 0,
                        tributos = null,
                        subTotal = 2000,
                        ivaRete1 = 0,
                        reteRenta = 0,
                        montoTotalOperacion = 2260,
                        totalNoGravado = 0,
                        totalPagar = 2260,
                        totalLetras = "DOS MIL DOSCIENTOS SESENTA DÓLARES",
                        totalIva = 0,
                        saldoFavor = 0,
                        condicionOperacion = 1,
                        pagos = AgregarPagos(),
                        numPagoElectronico = null
                    },

                    extension = new extension
                    {
                        nombEntrega = null,
                        docuEntrega = null,
                        nombRecibe = null,
                        docuRecibe = null,
                        observaciones = null,
                        placaVehiculo = null
                    },

                    apendice = null
                };
            }
            catch (Exception e)
            {

                MessageBox.Show("Error: " + e);
                throw;
            }

            return nuevoJson;
        }

        private List<cuerpoDocumento> AgregarCuerpo()
        {
            List<cuerpoDocumento> lst = new List<cuerpoDocumento>();
            int n = 1;
            foreach (PedidoDetalle item in lstPedido_Detalle)
            {
                cuerpoDocumento cd = new cuerpoDocumento();
                cd.numItem = n;
                cd.tipoItem = 1;
                cd.numeroDocumento = null;
                cd.codigo = null;
                cd.codTributo = null;
                cd.descripcion = item.Nombre;
                cd.cantidad = item.Cantidad;
                cd.uniMedida = 59;
                cd.precioUni = item.Precio;
                cd.montoDescu = 0;
                cd.ventaNoSuj = 0;
                cd.ventaExenta = 0;
                cd.ventaGravada = item.SubTotal;
                cd.tributos = null;
                cd.psv = 1.00;
                cd.noGravado = 0;

                cd.ivaItem = 0;
                n++;
                lst.Add(cd);
            }

            return lst;
        }

        private List<pagos> AgregarPagos()
        {
            List<pagos> lst = new List<pagos>();

            foreach (PagoCombinado item in lstPago_Combinado)
            {
                pagos p = new pagos();
                if (item.IdCuenta == 1)
                {
                    p.codigo = "01";
                    p.montoPago = item.Monto;
                    p.referencia = "";
                }
                else if (item.IdCuenta == 2)
                {
                    p.codigo = "03";
                    p.montoPago = item.Monto;
                    p.referencia = "";
                }
                else if (item.IdCuenta == 3)
                {
                    p.codigo = "11";
                    p.montoPago = item.Monto;
                    p.referencia = "";
                }
                p.plazo = null;
                p.periodo = null;

                lst.Add(p);
            }

            return lst;
        }

        public void SerializarFactura(dteJson dte, String path)
        {
            if (dte != null)
            {
                try
                {
                    String FacturaJson = JsonConvert.SerializeObject(dte, Formatting.Indented);

                    File.WriteAllText(path, FacturaJson);
                    MessageBox.Show("Se guardo el JSON.");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Ocurrio un error al exportar. " + e);
                    throw;
                }

            }
            else
            {
                MessageBox.Show("No se genero el JSON.");
            }

        }
    }
}
