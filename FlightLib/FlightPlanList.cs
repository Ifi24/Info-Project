using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        List<FlightPlan> listaVuelos = new List<FlightPlan>();
        double distanciaSeguridadCargada; //si no añadia estos atributos, se me complicaba bastante todo
        double tiempoSimulacionCargado;

        // Métodos:
        public int GetNumAviones()
        {
            return listaVuelos.Count;
        }
        public void AddFlightPlan(FlightPlan p)
        {
            listaVuelos.Add(p);
        }
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= listaVuelos.Count)
                return null; 
            else
                return listaVuelos[i];
        }

        public double GetDistanciaCargada()
        {
            return distanciaSeguridadCargada;
        }

        public double GetTiempoCargado()
        {
            return tiempoSimulacionCargado;
        }

        public void Mover(double tiempo) //Avisa para activar movimiento
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.Mover(tiempo);
            }
        }

        public void MoverAtras(double tiempo)
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.MoverAtras(tiempo);
            }
        }

        public void EscribeConsola()
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.EscribeConsola();
            }
        }

        // Método que crea los vuelos segun datos proporcionados:
        public void CrearVuelo(string id, double xi, double yi, double cx, double cy, double xf, double yf, double v, string aerolinia)
        {
            // Comprobamos que los datos se pueden mostrar:
            if (xi < 0 || xi > 800 || yi < 0 || yi > 600 || xf < 0 || xf > 800 || yf < 0 || yf > 600)
            {
                throw new Exception($"Coordenadas fuera de límites para el avión con ID: {id}"); // Comunica error.
            }

            FlightPlan avion = new FlightPlan(id, xi, yi, cx, cy, xf, yf, v, aerolinia);
            this.AddFlightPlan(avion);
        }

        //Método para generar aviones en conflicto:
        public void GenerarConflicto()
        {
            FlightPlan conflicto1 = new FlightPlan("123", 0, 0, 0, 0, 800, 600, 10, "EETAC Air");
            FlightPlan conflicto2 = new FlightPlan("321", 800, 0, 800, 0, 0, 600, 10, "UPC Airlines");
            this.AddFlightPlan(conflicto1);
            this.AddFlightPlan(conflicto2);
        }

        //Método para obtener informe de conflictos:
        public string InformeConflictos(double distanciaSeguridad)
        {
            string informe = "";
            int numVuelos = listaVuelos.Count;

            for (int i = 0; i < numVuelos; i++)
            {
                for (int j = i + 1; j < numVuelos; j++)
                {
                    if (listaVuelos[i].PrediccionConflicto(listaVuelos[j], distanciaSeguridad))
                    {
                        // Aquí usamos los paréntesis () y añadimos un guion para que quede limpio
                        informe += $"{listaVuelos[i].GetId()} con {listaVuelos[j].GetId()}\n";
                    }
                }
            }
            return informe;
        }

        //Método que detecte todos los conflictos:
        public List<FlightPlan[]> GetConflictos(double distSeguridad)
        {
            List<FlightPlan[]> conflictos = new List<FlightPlan[]>();

            for (int i = 0; i < listaVuelos.Count(); i++)
            {
                for (int j = i+1; j < listaVuelos.Count(); j++)
                {
                    if (listaVuelos[i].Conflicto(listaVuelos[j], distSeguridad))
                        conflictos.Add(new FlightPlan[] { listaVuelos[i], listaVuelos[j] });
                }
            }
            return conflictos;
        }
        //Método para reiniciar vuelos:
        public void ReiniciarVuelos()
        {
            foreach (FlightPlan fp in listaVuelos)
            {
                fp.Reseteo();
            }
        }

        public void GuardarFichero(string rutaArchivo, double distanciaSeguridad, double tiempoActual)
        {
            StreamWriter fichero = File.CreateText(rutaArchivo);
            string cabecera = $"DISTANCIA DE SEGURIDAD Y TIEMPO | {distanciaSeguridad} | {tiempoActual}";
            fichero.WriteLine(cabecera);
            foreach (FlightPlan fp in listaVuelos)
            {
                string datosVuelo = fp.DarDatosGuardado();
                fichero.WriteLine(datosVuelo);
            }
            fichero.Close();
        }

        //HAY QUE HACER QUE SE RESETEE TODO!!!
        public void AbrirFichero(string rutaArchivo)
        {
            //Primero reseteamos y vaciamos
            listaVuelos.Clear();

            StreamReader fichero = new StreamReader(rutaArchivo);
            string lineaCabecera = fichero.ReadLine();
            if (lineaCabecera != null)
            {
                string[] lineasSegTiem = lineaCabecera.Split('|');
                distanciaSeguridadCargada = Convert.ToDouble(lineasSegTiem[1]);
                tiempoSimulacionCargado = Convert.ToDouble(lineasSegTiem[2]);
            }

            string line = fichero.ReadLine();
            while (line != null)
            {
                string[] trozos = line.Split('|');

                string[] datosBasicos = trozos[0].Split(' ');
                string id = datosBasicos[0];
                double ipx = Convert.ToDouble(datosBasicos[1]);
                double ipy = Convert.ToDouble(datosBasicos[2]);
                double cpx = Convert.ToDouble(datosBasicos[3]);
                double cpy = Convert.ToDouble(datosBasicos[4]);
                double fpx = Convert.ToDouble(datosBasicos[5]);
                double fpy = Convert.ToDouble(datosBasicos[6]);
                double vel = Convert.ToDouble(datosBasicos[7]);
                string aerolinia = datosBasicos[8];

                FlightPlan fp = new FlightPlan(id, ipx, ipy, cpx, cpy, fpx, fpy, vel, aerolinia);
                
                string[] textoVelocidades = trozos[1].Split(';');
                double[] numVelocidades = Array.ConvertAll(textoVelocidades, Convert.ToDouble); //es molt mes facil aixi
                List<double> listaVelocidades = numVelocidades.ToList();
                Stack<double> historialVelocidades = new Stack<double>(listaVelocidades);
                fp.SetHistorialVelocidades(historialVelocidades);

                string[] textoPosiciones = trozos[2].Split(';');
                List<Position> listaPosiciones = new List<Position>();
                foreach (string p in textoPosiciones)
                {
                    string[] textoPos = p.Split(',');
                    double[] pos = Array.ConvertAll(textoPos, Convert.ToDouble);
                    Position posicion = new Position(pos[0], pos[1]);
                    listaPosiciones.Add(posicion);
                }
                Stack<Position> historialPosiciones = new Stack<Position>(listaPosiciones);

                this.AddFlightPlan(fp);

                line = fichero.ReadLine();
            }
        }
    }
}
