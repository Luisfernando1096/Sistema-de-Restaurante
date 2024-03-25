using CrystalDecisions.CrystalReports.Engine;
using Mantenimiento.CLS;
using Newtonsoft.Json;
using Reportes.REP;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

public class Server
{
    private TcpListener tcpListener;
    private Thread listenerThread;
    private bool isServerRunning;
    ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
    ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;
    ConfiguracionManager.CLS.Ticket oTicket = ConfiguracionManager.CLS.Ticket.Instancia;

    public void StartServer()
    {
        //OBETNER IP AUTOMATICAMENTE
        string hostName = Dns.GetHostName();
        // Inicializar la variable
        IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
        // Filtrar las direcciones IPv4
        IPAddress ipv4Address = localIPs.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);

        string archivoConfiguracion = "configuracion.xml";

        if (File.Exists(archivoConfiguracion))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(archivoConfiguracion);

            if (xmlDoc.SelectSingleNode("/Configuracion/IpLocal") != null
                && xmlDoc.SelectSingleNode("/Configuracion/Puerto") != null)
            {
                string ipLocal = xmlDoc.SelectSingleNode("/Configuracion/IpLocal").InnerText;
                string puerto = xmlDoc.SelectSingleNode("/Configuracion/Puerto").InnerText;
                if (ipv4Address.ToString().Equals(ipLocal))
                {
                    isServerRunning = true;
                    tcpListener = new TcpListener(IPAddress.Parse(ipLocal), Int32.Parse(puerto));
                    listenerThread = new Thread(new ThreadStart(ListenForClients));
                    listenerThread.Start();
                    Console.WriteLine("Servidor iniciado. Esperando conexiones...");
                }
                else
                {
                    MessageBox.Show("El servidor no se pudo iniciar verifique la direccion Ip.", "Ip incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("El servidor no se pudo iniciar verifique establecer puerto e Ip.", "Ip null", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }


    }

    public void StopServer()
    {
        if (isServerRunning)
        {
            isServerRunning = false;
            tcpListener.Stop();
            listenerThread.Join(); // Esperar a que el hilo del escuchador termine
            Console.WriteLine("Servidor detenido.");
        }

    }

    private void ListenForClients()
    {
        tcpListener.Start();

        while (isServerRunning)
        {
            try
            {
                TcpClient client = tcpListener.AcceptTcpClient();

                // Procesa la solicitud del cliente en un hilo separado
                var clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
            catch (SocketException ex)
            {
                // Manejar la excepción de Socket
                if (isServerRunning)
                {
                    Console.WriteLine($"Error de Socket: {ex.Message}");
                }
            }
        }
    }

    private void HandleClient(TcpClient client)
    {
        try
        {
            using (StreamReader reader = new StreamReader(client.GetStream()))
            {
                // Leer todas las líneas del encabezado HTTP
                StringBuilder headerBuilder = new StringBuilder();
                string line;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    headerBuilder.AppendLine(line);
                }

                // Extraer el cuerpo del mensaje (JSON)
                string contenido = reader.ReadToEnd();

                // Comprobar si la solicitud es POST
                if (headerBuilder.ToString().StartsWith("POST"))
                {
                    // Extraer la ruta de la solicitud
                    string[] tokens = headerBuilder.ToString().Split(' ');
                    string ruta = tokens[1];

                    // Comprobar si la solicitud está en la ruta de notificación esperada
                    if (ruta.StartsWith("/notificar"))
                    {
                        // Procesar la solicitud solo si está en la ruta '/notificar'
                        Console.WriteLine($"Solicitud POST en la ruta '/notificar'.");

                        // Imprimir el contenido para ayudar a diagnosticar el problema
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            // Intentar deserializar la solicitud como una lista de objetos
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);

                            // Si la deserialización tiene éxito, trabajar con la lista de objetos
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Aquí puedes realizar acciones específicas para la lista de objetos como imprimir una comanda
                            ImprimirComandaActual(listaObjetos);

                        }
                        catch (JsonException ex)
                        {
                            // Imprimir detalles completos de la excepción
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else if (ruta.StartsWith("/comandaCompleta"))
                    {
                        //MessageBox.Show("Generando comanda completa");
                        // Procesar la solicitud solo si está en la ruta '/comanda'
                        Console.WriteLine($"Solicitud POST en la ruta '/comandaCompleta'.");
                        // Imprimir el contenido para ayudar a diagnosticar el problema
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            // Intentar deserializar la solicitud como una lista de objetos
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);

                            // Si la deserialización tiene éxito, trabajar con la lista de objetos
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Aquí puedes realizar acciones específicas para la lista de objetos como imprimir una comanda
                            ImprimirComandaCompleta(listaObjetos);

                        }
                        catch (JsonException ex)
                        {
                            // Imprimir detalles completos de la excepción
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else if (ruta.StartsWith("/datosPrecuenta"))
                    {
                        //MessageBox.Show("Generando comanda completa");
                        // Procesar la solicitud solo si está en la ruta '/comanda'
                        Console.WriteLine($"Solicitud POST en la ruta '/datosPrecuenta'.");
                        // Imprimir el contenido para ayudar a diagnosticar el problema
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            // Intentar deserializar la solicitud como una lista de objetos
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);

                            // Si la deserialización tiene éxito, trabajar con la lista de objetos
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Aquí puedes realizar acciones específicas para la lista de objetos como imprimir una comanda
                            ImprimirPrecuenta(listaObjetos);

                        }
                        catch (JsonException ex)
                        {
                            // Imprimir detalles completos de la excepción
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    {
                        Console.WriteLine("Solicitud no reconocida.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar otras excepciones
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    private void ImprimirPrecuenta(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            // Cargar los datos en un DataTable
            RepImprimirPrecuenta oReporte = new RepImprimirPrecuenta();
            GenerarPrecuenta(oReporte, listaObjetos);
        }
    }

    private void GenerarPrecuenta(RepImprimirPrecuenta oReporte, List<PedidoDetalle> listaObjetos)
    {
        // Crear un solo grupo para almacenar todos los detalles
        var grupoUnico = new List<PedidoDetalle>();

        // Iterar a través de los detalles y agregarlos al grupo único
        foreach (PedidoDetalle detalle in listaObjetos)
        {
            grupoUnico.Add(detalle);
        }

        Double total = CalcularSubTotal(listaObjetos);
        Double descuento = 0;
        Double propina = CalcularPropina(total);
        Double iva = 0;
        Double totalPagar = total + propina;

        // Configurar el informe con los detalles del grupo único
        oReporte.SetDataSource(grupoUnico);
        oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
        oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
        oReporte.SetParameterValue("Telefono", oEmpresa.Telefono);
        oReporte.SetParameterValue("Mesero", grupoUnico[0].Mesero);
        oReporte.SetParameterValue("Cliente", grupoUnico[0].Cliente);
        oReporte.SetParameterValue("Total", "$" + total.ToString("0.00"));
        oReporte.SetParameterValue("Descuento", "$" + descuento.ToString("0.00"));
        oReporte.SetParameterValue("Propina", "$" + propina.ToString("0.00"));
        oReporte.SetParameterValue("Iva", "$" + iva.ToString("0.00"));
        oReporte.SetParameterValue("TotalPagar", "$" + totalPagar.ToString("0.00"));

        if (Boolean.Parse(oTicket.ShowSaludo))
        {
            oReporte.SetParameterValue("Footer3", oTicket.Footer3);
        }
        else
        {
            oReporte.SetParameterValue("Footer3", "");
        }

        try
        {
            if (oReporte != null)
            {
                try
                {
                    // Imprimir el informe en la impresora seleccionada
                    PrinterSettings settings = new PrinterSettings
                    {
                        PrinterName = oConfiguracion.PrinterComanda
                    };

                    oReporte.PrintOptions.PrinterName = settings.PrinterName;
                    oReporte.PrintToPrinter(1, false, 0, 0);

                    // Muestra un mensaje de éxito
                    /*MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones específicas de Crystal Reports si es necesario
            MessageBox.Show($"Error al imprimir el informe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private double CalcularPropina(Double total)
    {
        Double propina = 0;
        Double porcentaje;
        if (Boolean.Parse(oConfiguracion.IncluirPropina))
        {
            porcentaje = Double.Parse(oConfiguracion.Propina) / 100;
            propina = porcentaje * total;
        }
        return Math.Round(propina, 2);
    }

    private void ImprimirComandaActual(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            // Cargar los datos en un DataTable
            RepComandaParcial oReporte = new RepComandaParcial();
            GenerarComandaParcial(oReporte, listaObjetos);
        }

    }

    private void ImprimirComandaCompleta(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            // Cargar los datos en un DataTable
            RepComandaCompleta oReporte = new RepComandaCompleta();
            GenerarComandaCompleta(oReporte, listaObjetos);
        }

    }

    private void GenerarComandaParcial(ReportClass oReporte, List<PedidoDetalle> listaObjetos)
    {
        // Crear un diccionario para almacenar listas de detalles por grupo
        var grupos = new Dictionary<string, List<PedidoDetalle>>();

        // Iterar a través de los detalles y agregar los detalles a las listas de grupos correspondientes
        foreach (PedidoDetalle detalle in listaObjetos)
        {
            string grupoKey = detalle.Grupo; // Asegúrate de tener una propiedad "Grupo" en tu clase PedidoDetalle

            if (!grupos.ContainsKey(grupoKey))
            {
                grupos[grupoKey] = new List<PedidoDetalle>();
            }
            grupos[grupoKey].Add(detalle);
        }

        // Ahora, itera a través de los grupos y crea e imprime el informe para cada grupo
        foreach (var kvp in grupos)
        {
            List<PedidoDetalle> detallesDelGrupo = kvp.Value;

            oReporte.SetDataSource(detallesDelGrupo);
            oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
            oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
            oReporte.SetParameterValue("Salon", detallesDelGrupo[0].Salon);
            oReporte.SetParameterValue("Grupo", kvp.Key.ToString());


            oReporte.SetParameterValue("Mesero", detallesDelGrupo[0].Mesero);

            oReporte.SetParameterValue("Cliente", detallesDelGrupo[0].Cliente);

            if (oReporte != null)
            {
                try
                {
                    // Crear un diccionario para asociar cada grupo con su impresora
                    Dictionary<string, string> impresorasPorGrupo = new Dictionary<string, string>{
                                { "COCINA", oConfiguracion.ImpresoraCocina },
                                { "BAR", oConfiguracion.ImpresoraBar },
                                { "GRUPO1", oConfiguracion.ImpresoraGrupoUno },
                                { "GRUPO2", oConfiguracion.ImpresoraGrupoDos },
                            };

                    if (impresorasPorGrupo.TryGetValue(kvp.Key, out string nombreImpresora))
                    {
                        // Configurar impresora según el grupo
                        PrinterSettings settings = new PrinterSettings
                        {
                            PrinterName = nombreImpresora
                        };

                        oReporte.PrintOptions.PrinterName = settings.PrinterName;
                        oReporte.PrintToPrinter(1, false, 0, 0);
                    }
                    else
                    {
                        //MessageBox.Show($"No se encontró una impresora asociada al grupo: {kvp.Key}, se recomienda revisar los nombres de los grupos para evitar fallas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void GenerarComandaCompleta(ReportClass oReporte, List<PedidoDetalle> listaObjetos)
    {
        // Crear un solo grupo para almacenar todos los detalles
        var grupoUnico = new List<PedidoDetalle>();

        // Iterar a través de los detalles y agregarlos al grupo único
        foreach (PedidoDetalle detalle in listaObjetos)
        {
            grupoUnico.Add(detalle);
        }

        // Configurar el informe con los detalles del grupo único
        oReporte.SetDataSource(grupoUnico);
        oReporte.SetParameterValue("Empresa", oEmpresa.NombreEmpresa);
        oReporte.SetParameterValue("Slogan", oEmpresa.Slogan);
        oReporte.SetParameterValue("Salon", grupoUnico[0].Salon);
        oReporte.SetParameterValue("Mesero", grupoUnico[0].Mesero);
        oReporte.SetParameterValue("Cliente", grupoUnico[0].Cliente);

        try
        {
            if (oReporte != null)
            {
                try
                {
                    // Imprimir el informe en la impresora seleccionada
                    PrinterSettings settings = new PrinterSettings
                    {
                        PrinterName = oConfiguracion.PrinterComanda
                    };

                    oReporte.PrintOptions.PrinterName = settings.PrinterName;
                    oReporte.PrintToPrinter(1, false, 0, 0);

                    // Muestra un mensaje de éxito
                    /*MessageBox.Show($"Finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
                }
                catch (Exception ex)
                {
                    // Manejo de excepciones: muestra un mensaje de error en caso de problemas
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        catch (Exception ex)
        {
            // Manejar excepciones específicas de Crystal Reports si es necesario
            MessageBox.Show($"Error al imprimir el informe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private Double CalcularSubTotal(List<PedidoDetalle> lst)
    {
        Double total = 0;
        foreach (PedidoDetalle item in lst)
        {
            total += item.SubTotal;
        }

        return Math.Round(total, 2);
    }
}