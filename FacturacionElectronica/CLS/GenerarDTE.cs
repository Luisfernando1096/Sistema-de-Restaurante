﻿using Mantenimiento.CLS;
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
        ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
        List<PagoCombinado> lstPago_Combinado = new List<PagoCombinado>();
        List<PedidoDetalle> lstPedido_Detalle = new List<PedidoDetalle>();
        List<String> lstCliente = new List<String>();
        receptor rec = new receptor();
        direccion direc = new direccion();
        string idDireccion = "";
        String totalLetras;
        double propina;
        double exento;
        double iva;
        double descuento;

        public string TotalLetras { get => totalLetras; set => totalLetras = value; }
        public double Propina { get => propina; set => propina = value; }
        public double Exento { get => exento; set => exento = value; }
        public double Iva { get => iva; set => iva = value; }
        public double Descuento { get => descuento; set => descuento = value; }

        public GenerarDTE(List<PagoCombinado> lst, List<PedidoDetalle> lstPd, List<String> lstC)
        {
            lstPago_Combinado = lst;
            lstPedido_Detalle = lstPd;
            lstCliente = lstC;
            AgregarReceptor();
        }

        public dteJson GenerarFactura(Boolean normal, int nfactura, String fech, String cGeneracion)
        {
            DateTime fecha = DateTime.Parse(fech);
            
            dteJson nuevoJson = null;
            try
            {
                int tModelo = 1;
                int tOperacion = 1;
                int? tContingencia = null;
                String mContingencia = null;

                
                String ambiente = "00";
                String tDte = "01";
                string c1 = "DTE" + "-";
                string c2 = tDte + "-";
                string c3 = "12345678" + "-";
                String nControl = c1 + c2 + c3 + nfactura.ToString("000000000000000");
                if (!normal)
                {
                    tModelo = 2;
                    tOperacion = 2;
                    tContingencia = 2;
                    mContingencia = "No disponibilidad de sistema del MH.";
                }

                nuevoJson = new dteJson
                {
                    
                    identificacion = new identificacion
                    {
                        version = 1,
                        ambiente = ambiente,
                        tipoDte = tDte,
                        numeroControl = nControl,
                        codigoGeneracion = cGeneracion,
                        tipoModelo = tModelo,
                        tipoOperacion = tOperacion,
                        tipoContingencia = tContingencia,
                        motivoContin = mContingencia,
                        fecEmi = fecha.ToString("yyyy-MM-dd"),
                        horEmi = fecha.ToString("HH:mm:ss"),
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
                        nrc = rec.nrc,
                        nombre = rec.nombre,
                        codActividad = (rec.codActividad == "") ? null : rec.codActividad,
                        descActividad = (rec.descActividad == "") ? null : rec.descActividad,
                        direccion = (idDireccion == "") ? null : new direccion
                        {
                            departamento = direc.departamento,
                            municipio = direc.municipio,
                            complemento = direc.complemento
                        },
                        telefono = rec.telefono,
                        correo = (rec.correo == "") ? null : rec.correo,
                        numDocumento = rec.numDocumento,
                        tipoDocumento = rec.tipoDocumento
                    },

                    otrosDocumentos = null,

                    ventaTercero = null,

                    cuerpoDocumento = AgregarCuerpo(),

                    resumen = new resumen
                    {
                        totalNoSuj = propina,
                        totalExenta = exento,
                        totalGravada = Double.Parse(CalcularSubTotal().ToString("0.00")),
                        subTotalVentas = Double.Parse(CalcularSubTotal().ToString("0.00")),
                        descuNoSuj = propina,
                        descuExenta = exento,
                        descuGravada = 0,
                        porcentajeDescuento = 0,
                        totalDescu = descuento + exento,
                        tributos = null,
                        subTotal = Double.Parse(CalcularSubTotal().ToString("0.00")),
                        ivaRete1 = iva,
                        reteRenta = 0,
                        montoTotalOperacion = Double.Parse(CalcularTotalPagar().ToString("0.00")),
                        totalNoGravado = 0,
                        totalPagar = Double.Parse(CalcularTotalPagar().ToString("0.00")),
                        totalLetras = totalLetras,
                        totalIva = iva,
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

        private double CalcularTotalPagar()
        {
            Double total;

            total = Math.Round(CalcularSubTotal(), 2) + iva + propina - descuento - exento;

            return total;
        }

        private void AgregarReceptor() 
        {
            foreach (string clienteInfo in lstCliente)
            {
                string[] datosCliente = clienteInfo.Split(',');

                // Acceder a los datos individuales
                rec.nrc = null;     /*datosCliente[0].Trim()*/
                rec.nombre = datosCliente[1].Trim();
                rec.codActividad = datosCliente[2].Trim();
                rec.descActividad = datosCliente[3].Trim();
                idDireccion = datosCliente[4].Trim();
                direc.departamento = datosCliente[5].Trim();
                direc.municipio = datosCliente[6].Trim();
                direc.complemento = datosCliente[7].Trim();
                rec.telefono = datosCliente[8].Trim();
                rec.correo = datosCliente[9].Trim();
                rec.numDocumento = datosCliente[10].Trim();
                rec.tipoDocumento = datosCliente[11].Trim();
            }
        }

        private Double CalcularSubTotal()
        {
            Double sub = 0;

            foreach (PedidoDetalle item in lstPedido_Detalle)
            {
                sub += item.SubTotal;
            }

            return sub;
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
                cd.ventaGravada = Double.Parse(item.SubTotal.ToString("0.00"));
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
                    p.montoPago = Double.Parse(item.Monto.ToString("0.00"));
                    p.referencia = "";
                }
                else if (item.IdCuenta == 2)
                {
                    p.codigo = "03";
                    p.montoPago = Double.Parse(item.Monto.ToString("0.00"));
                    p.referencia = item.Referencia.ToString();
                }
                else if (item.IdCuenta == 3)
                {
                    p.codigo = "11";
                    p.montoPago = Double.Parse(item.Monto.ToString("0.00"));
                    p.referencia = item.Referencia.ToString();
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
