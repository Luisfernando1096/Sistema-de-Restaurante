using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfiguracionManager.CLS
{
    public class Salon
    {
        static Salon instancia = null;
        static readonly Object codelock = new object();
        int idSalon, nMesas;
        string nombre, fondo;
        public List<Salon> ListaSalones = null;

        /*DECLARACION DE PROPIEDADES*/
        public int IdSalon { get => idSalon; set => idSalon = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Fondo { get => fondo; set => fondo = value; }
        public int NMesas { get => nMesas; set => nMesas = value; }

        public static Salon Instancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (codelock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Salon();
                        }
                    }
                }
                return instancia;
            }
        }

        private Salon()
        {

        }

        public List<Salon> ObtenerSalon()
        {
            ListaSalones = new List<Salon>();
            try
            {
                DataTable salones = DataManager.DBConsultas.Salones(); // Obtener datos de la base de datos
                if (salones.Rows.Count > 0)
                {
                    foreach (DataRow row in salones.Rows)
                    {
                        Salon salon = new Salon
                        {
                            IdSalon = Convert.ToInt32(row["IdSalon"]),
                            Nombre = row["Nombre"].ToString()
                        };
                        ListaSalones.Add(salon);
                        Console.WriteLine($"ID: {salon.idSalon}, Nombre: {salon.Nombre}, Fondo: {salon.Fondo}, Número de Mesas: {salon.NMesas}");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ListaSalones;
        }
    }
}
