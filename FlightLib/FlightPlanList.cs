using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{

    // Clase FlightPlanList que gestiona la lista de planes de vuelo, la persistencia en ficheros y los algoritmos de detección de conflictos.
    public class FlightPlanList
    {
        // Atributos
        List<FlightPlan> listaVuelos = new List<FlightPlan>();
        double distanciaSeguridadCargada; //si no añadia estos atributos, se me complicaba bastante todo
        double tiempoSimulacionCargado;

        // Métodos de gestión de lista:

        // Obtiene el número total de aviones en la lista.
        // Parámetros: ninguno.
        // Devuelve: cantidad de vuelos (int).
        public int GetNumAviones()
        {
            return listaVuelos.Count;
        }

        // Añade un objeto FlightPlan a la lista.
        // Parámetros: p (FlightPlan).
        // Devuelve: Nada.
        public void AddFlightPlan(FlightPlan p)
        {
            listaVuelos.Add(p);
        }

        // Obtiene un plan de vuelo específico.
        // Parámetros: i (int) posición en la lista.
        // Devuelve: objeto FlightPlan o null si el índice está fuera de rango.
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= listaVuelos.Count)
                return null; 
            else
                return listaVuelos[i];
        }

        // Obtiene la distancia de seguridad que se guardó en el último fichero cargado.
        // Parámetros: ninguno.
        // Devuelve: distancia de seguridad (double).
        public double GetDistanciaCargada()
        {
            return distanciaSeguridadCargada;
        }

        // Obtiene el tiempo de simulación que se guardó en el último fichero cargado.
        // Parámetros: ninguno.
        // DEVUELVE: tiempo de simulación (double).
        public double GetTiempoCargado()
        {
            return tiempoSimulacionCargado;
        }

        // Métodos de movimiento y control:

        // Ordena a todos los aviones de la lista que avancen un paso de tiempo.
        // Parámetros: tiempo (double) diferencial de tiempo.
        // Devuelve: nada.
        public void Mover(double tiempo) //Avisa para activar movimiento
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.Mover(tiempo);
            }
        }

        // Ordena a todos los aviones que retrocedan un paso en su historial.
        // Parámetros: tiempo (double) (mantenido por consistencia).
        // Devuelve: nada.
        public void MoverAtras(double tiempo)
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.MoverAtras(tiempo);
            }
        }

        // Recorre la lista completa de vuelos y ejecuta el método de escritura en consola para cada uno.
        // Parámetros: ninguno.
        // Devuelve: nada.
        public void EscribeConsola()
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.EscribeConsola();
            }
        }

        // Método que crea los vuelos segun datos proporcionados:
        // Parámetros: id (string), xi/yi (origen; double), cx/cy (actual; double), xf/yf (destino; double), v (velocidad; double) y aerolinia (string).
        // Devuelve: nada. Lanza una excepción si los datos están fuera de los límites establecidos.
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
        // Parámetros: ninguno.
        // Devuelve: nada.
        public void GenerarConflicto()
        {
            FlightPlan conflicto1 = new FlightPlan("123", 0, 0, 0, 0, 800, 600, 10, "EETAC Air");
            FlightPlan conflicto2 = new FlightPlan("321", 800, 0, 800, 0, 0, 600, 10, "UPC Airlines");
            this.AddFlightPlan(conflicto1);
            this.AddFlightPlan(conflicto2);
        }

        //Método para obtener informe de conflictos:
        // Parámetros: distanciaSeguridad (double) mínima permitida entre aviones.
        // Devuelve: un string con la lista de parejas de IDs en conflicto, separados por saltos de línea.
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
        // Parámetros: distSeguridad (double) que define el radio de alerta.
        // Devuelve: una lista de arrays, donde cada array contiene la pareja de objetos FlightPlan que están en conflicto.
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
        // Parámetros: ninguno.
        // Devuelve: nada.
        public void ReiniciarVuelos()
        {
            foreach (FlightPlan fp in listaVuelos)
            {
                fp.Reseteo();
            }
        }

        // Exporta el estado actual de la simulación a un archivo de texto, incluyendo la configuración global y el historial de cada vuelo.
        // Parámetros: rutaArchivo (string) donde se creará el fichero, distanciaSeguridad (double) y tiempoActual (double) de la simulación.
        // Devuelve: nada.
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
        // Carga los datos de una simulación desde un archivo, reconstruyendo la lista de vuelos, configuraciones globales e historiales de movimiento (Stack).
        // Parámetros: rutaArchivo (string) con la ubicación del fichero a leer.
        // Devuelve: nada.
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
