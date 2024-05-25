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
        // Obtener IP automáticamente
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
                    try
                    {
                        tcpListener = new TcpListener(IPAddress.Parse(ipLocal), Int32.Parse(puerto));
                        tcpListener.Start(); // Intentar iniciar el listener

                        isServerRunning = true;
                        listenerThread = new Thread(new ThreadStart(ListenForClients));
                        listenerThread.Start();
                        Console.WriteLine("Servidor iniciado. Esperando conexiones...");
                    }
                    catch (SocketException ex)
                    {
                        if (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                        {
                            MessageBox.Show("El puerto está ocupado. No se puede iniciar el servidor.", "Puerto ocupado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show($"Error al iniciar el servidor: {ex.Message}", "Error del servidor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El servidor no se pudo iniciar. Verifique la dirección IP.", "IP incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("El servidor no se pudo iniciar. Establezca el puerto y la IP en el archivo de configuración.", "Configuración incompleta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            using (StreamWriter writer = new StreamWriter(client.GetStream()))
            {
                // Leer todas las líneas del encabezado HTTP
                StringBuilder headerBuilder = new StringBuilder();
                string line;
                while (!string.IsNullOrEmpty(line = reader.ReadLine()))
                {
                    headerBuilder.AppendLine(line);
                }

                // Extraer la longitud del contenido del encabezado Content-Length
                string headers = headerBuilder.ToString();
                int contentLength = GetContentLength(headers);

                // Leer el cuerpo del mensaje (JSON) en función de la longitud del contenido
                char[] buffer = new char[contentLength];
                int totalRead = 0;
                while (totalRead < contentLength)
                {
                    int bytesRead = reader.Read(buffer, totalRead, contentLength - totalRead);
                    if (bytesRead == 0)
                    {
                        // Se ha alcanzado el final del flujo antes de leer todo el contenido
                        break;
                    }
                    totalRead += bytesRead;
                }
                string contenido = new string(buffer);

                // Comprobar si la solicitud es POST
                if (headerBuilder.ToString().StartsWith("POST"))
                {
                    // Extraer la ruta de la solicitud
                    string[] tokens = headerBuilder.ToString().Split(' ');
                    string ruta = tokens[1];

                    bool success = false;

                    // Comprobar si la solicitud está en la ruta de notificación esperada
                    if (ruta.StartsWith("/notificar"))
                    {
                        Console.WriteLine($"Solicitud POST en la ruta '/notificar'.");
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Realizar acciones específicas
                            ImprimirComandaActual(listaObjetos);
                            success = true;
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else if (ruta.StartsWith("/comandaCompleta"))
                    {
                        Console.WriteLine($"Solicitud POST en la ruta '/comandaCompleta'.");
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Realizar acciones específicas
                            ImprimirComandaCompleta(listaObjetos);
                            success = true;
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else if (ruta.StartsWith("/datosPrecuenta"))
                    {
                        Console.WriteLine($"Solicitud POST en la ruta '/datosPrecuenta'.");
                        Console.WriteLine($"Contenido recibido: {contenido}");

                        try
                        {
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Realizar acciones específicas
                            ImprimirPrecuenta(listaObjetos);
                            success = true;
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Solicitud no reconocida.");
                    }

                    // Enviar la respuesta
                    EnviarRespuesta(writer, success);
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

    private void EnviarRespuesta(StreamWriter writer, bool success)
    {
        writer.WriteLine("HTTP/1.1 200 OK");
        writer.WriteLine("Content-Type: application/json");
        writer.WriteLine($"Content-Length: {(success ? 4 : 5)}");
        writer.WriteLine();
        writer.WriteLine(success ? "true" : "false");
        writer.Flush();
    }

    private int GetContentLength(string headers)
    {
        int contentLength = 0;
        using (StringReader reader = new StringReader(headers))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase))
                {
                    string lengthStr = line.Substring("Content-Length:".Length).Trim();
                    int.TryParse(lengthStr, out contentLength);
                    break;
                }
            }
        }
        return contentLength;
    }

    private void ImprimirPrecuenta(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            // Cargar los datos en un DataTable
            using (RepImprimirPrecuenta oReporte = new RepImprimirPrecuenta())
            {
                GenerarPrecuenta(oReporte, listaObjetos);
            }
                
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
            using (RepComandaParcial oReporte = new RepComandaParcial())
            {
                GenerarComandaParcial(oReporte, listaObjetos);
            }
                
        }

    }

    private void ImprimirComandaCompleta(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            using (RepComandaCompleta oReporte = new RepComandaCompleta())
            {
                GenerarComandaCompleta(oReporte, listaObjetos);
            }
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
                                { "JUGOS", oConfiguracion.ImpresoraGrupoDos },
                                { "COCTELES", oConfiguracion.ImpresoraGrupoDos },
                                { "BARRA", oConfiguracion.ImpresoraBar },
                                { "HELADOS", oConfiguracion.ImpresoraGrupoDos },
                                { "COMIDA", oConfiguracion.ImpresoraGrupoDos },
                                { "ATRAS", oConfiguracion.ImpresoraGrupoDos },
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