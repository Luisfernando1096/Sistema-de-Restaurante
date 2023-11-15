using Mantenimiento.CLS;
using Newtonsoft.Json;
using Reportes.REP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Linq;

public class Server
{
    private TcpListener tcpListener;
    private Thread listenerThread;
    private bool isServerRunning;
    ConfiguracionManager.CLS.Configuracion oConfiguracion = ConfiguracionManager.CLS.Configuracion.Instancia;
    ConfiguracionManager.CLS.Empresa oEmpresa = ConfiguracionManager.CLS.Empresa.Instancia;

    public void StartServer()
    {

       /*OBETNER IP AUTOMATICAMENTE
        string hostName = Dns.GetHostName();
        // Inicializar la variable
        IPAddress[] localIPs = Dns.GetHostAddresses(hostName);
        // Filtrar las direcciones IPv4
        IPAddress ipv4Address = localIPs.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
        isServerRunning = true;
        tcpListener = new TcpListener(IPAddress.Parse(ipv4Address.ToString()), 4000);*/

        isServerRunning = true;
        tcpListener = new TcpListener(IPAddress.Parse("192.168.2.105"), 4000);
        listenerThread = new Thread(new ThreadStart(ListenForClients));
        listenerThread.Start();
        Console.WriteLine("Servidor iniciado. Esperando conexiones...");
    }

    public void StopServer()
    {
        isServerRunning = false;
        tcpListener.Stop();
        listenerThread.Join(); // Esperar a que el hilo del escuchador termine
        Console.WriteLine("Servidor detenido.");
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

                        try
                        {
                            // Intentar deserializar la solicitud como una lista de objetos
                            List<PedidoDetalle> listaObjetos = JsonConvert.DeserializeObject<List<PedidoDetalle>>(contenido);

                            // Si la deserialización tiene éxito, trabajar con la lista de objetos
                            Console.WriteLine($"Lista de objetos recibida. Cantidad: {listaObjetos.Count}");

                            // Aquí puedes realizar acciones específicas para la lista de objetos como imprimir una comanda
                            ImprimirComandaActual(listaObjetos);

                            // Imprimir el contenido para ayudar a diagnosticar el problema
                            Console.WriteLine($"Contenido recibido: {contenido}");

                        }
                        catch (JsonException ex)
                        {
                            // Imprimir detalles completos de la excepción
                            Console.WriteLine($"Error al deserializar la lista de objetos: {ex}");
                        }
                    }
                    else
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

    private void ImprimirComandaActual(List<PedidoDetalle> listaObjetos)
    {
        if (listaObjetos.Count > 0)
        {
            // Cargar los datos en un DataTable
            RepComandaParcial oReporte = new RepComandaParcial();
            GenerarComandaParcial(oReporte, listaObjetos);
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
                // Configurar la ruta de destino en la impresora virtual XPS
                PrinterSettings settings = new PrinterSettings();
                settings.PrinterName = oConfiguracion.PrinterComanda; // Nombre de la impresora virtual XPS

                // Imprimir el informe en la impresora virtual XPS
                oReporte.PrintOptions.PrinterName = settings.PrinterName;
                oReporte.PrintToPrinter(1, false, 0, 0);

                MessageBox.Show($"Informe para el grupo {kvp.Key} finalizado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}

