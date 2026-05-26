using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan 
    {
        // Atributos:
        string id;
        Position initialPosition;
        Position currentPosition; 
        Position finalPosition; 
        double velocidad; //m/s
        string aerolinia;
        

        //Para guardar un historial de posiciones para hacer y deshacer:
        Stack<Position> historialPosiciones = new Stack<Position>();
        Stack<double> historialVelocidades = new Stack<double>();


        // Constructor que inicializa un nuevo plan de vuelo con sus posiciones y velocidad:
        public FlightPlan(string id, double xi, double yi, double cx, double cy, double xf, double yf, double v, string aerolinia)
        {
            this.id = id;
            this.initialPosition = new Position(xi, yi);
            this.currentPosition = new Position(cx, cy);
            this.finalPosition = new Position(xf, yf);
            this.velocidad = v;
            this.aerolinia = aerolinia;

        }

        // Métodos:
        // Gets y Sets:

        // Obtiene el id del vuelo
        public string GetId()
        {
            return id;
        }

        // Asigna un nuevo identificador al vuelo.
        public void SetId(string id)
        {
            this.id = id;
        }

        // Obtiene la posición inicial de origen del vuelo.
        public Position GetInitialPosition()
        {
            return initialPosition;
        }

        // Establece una nueva posición inicial para el vuelo.
        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        // Obtiene la posición actual en la que se encuentra el avión.
        public Position GetCurrentPosition()
        {
            return currentPosition;
        }

        // Actualiza la posición actual del avión manualmente.
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        // Obtiene la posición de destino final del vuelo.
        public Position GetFinalPosition()
        {
            return finalPosition;
        }

        // Establece una nueva posición final de destino.
        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        // Obtiene el valor de la velocidad escalar del avión.
        public double GetVelocidad()
        {
            return velocidad;
        }

        // Asigna una nueva velocidad al plan de vuelo.
        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }

        // Calcula la componente X de la velocidad actual.
        public double GetVelocidadX()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetX() - this.currentPosition.GetX()) / distTotal * this.velocidad;
        }

        // Calcula la componente Y de la velocidad actual.
        public double GetVelocidadY()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetY() - this.currentPosition.GetY()) / distTotal * this.velocidad;
        }

        // Asigna el nombre de la aerolínea a la que pertenece el avión.
        public void SetAerolinia(string aerolinia)
        {
            this.aerolinia = aerolinia;
        }

        // Obtiene el nombre de la aerolínea propietaria del vuelo.
        public string GetAerolinia()
        {
            return aerolinia;
        }

        // Sobrescribe el historial de posiciones.
        public void SetHistorialPosiciones(Stack<Position> historial)
        {
            this.historialPosiciones = historial;
        }

        // Sobrescribe el historial de velocidades.
        public void SetHistorialVelocidades(Stack<double> historial)
        {
            this.historialVelocidades = historial;
        }

        //Métodos de movimiento

        // Método que mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro.
        public void Mover(double tiempo)
        {
            if (!this.HaLlegado()) //Para que no se guarde la posicion final muchas veces.
            {
                // Guardamos el estado actual
                historialPosiciones.Push(new Position(currentPosition.GetX(), currentPosition.GetY()));
                historialVelocidades.Push(this.velocidad);

                // Comprobamos que aún no hemos llegado.
                if (this.HaLlegado())
                {
                    currentPosition = finalPosition;
                    return; //Sale del loop
                }

                // Calculamos la distancia recorrida en el tiempo dado
                double distancia = tiempo * this.velocidad; //Tiempo en s

                //Calculamos las razones trigonométricas
                double hipotenusa = currentPosition.Distancia(finalPosition);
                double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
                double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

                //Calculamos la nueva posición del vuelo
                double x = currentPosition.GetX() + distancia * coseno;
                double y = currentPosition.GetY() + distancia * seno;

                // Cambiamos el nombre porque la vamos a usar para saber si estamos todavía en el vuelo o si hemos llegado al final de este por lo que nos pararíamos
                Position nextPosition = new Position(x, y);

                if (currentPosition.Distancia(nextPosition) < hipotenusa)
                    currentPosition = nextPosition;
                else
                    currentPosition = finalPosition;
            }
        }

        // Método que mueve el vuelo hacia atrás en la posición correspondiente según el tiempo que se recibe de parámetro:
        public void MoverAtras()
        {
            if (historialPosiciones.Count > 0)
            {
                this.currentPosition = historialPosiciones.Pop();
                this.velocidad = historialVelocidades.Pop();
            }
            else
            {
                this.Reseteo(); //si el historial esta vacío, significa que el avion ya esta en origen
            }
        }

        // Métodos de estado y conflictos

        // Método que nos dice si un vuelo ha llegado a su destino o no.
        public bool HaLlegado()
        {
            bool destino = false;
            if (currentPosition.Distancia(finalPosition) < 0.1) //Corregido por pequeños errores
                destino = true;
            return destino;
        }

        // Comprueba si el avión se encuentra todavía en su posición inicial (origen).
        public bool SigueEnOrigen()
        {
            bool origen = false;
            if (currentPosition.Distancia(initialPosition) < 0.1)
                origen = true;
            return origen;
        }

        // Método que devuelve al avión a su posición inicial.
        public void Reseteo()
        {
            currentPosition = initialPosition;

            historialPosiciones.Clear();
            historialVelocidades.Clear();
        }

        // Método que da la distancia que se ha movido el avion.
        public double DistanciaViajada(FlightPlan plan)
        {
            return this.currentPosition.Distancia(plan.currentPosition);
        }

        // Método que detecta si hay un conflicto según la distancia de seguridad proporcionada
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;
            return conflicto;
        }

        //FASE 10: Predice si habrá un conflicto a lo largo de toda la trayectoria.
        public Position PuntoConflicto(FlightPlan otroVuelo, double distSeguridad)
        {
            // Utilizamos t = (-(dist*vel))/|vel|^2 = a/b
            // Derivadas
            double dx = otroVuelo.currentPosition.GetX() - this.currentPosition.GetX();
            double dy = otroVuelo.currentPosition.GetY() - this.currentPosition.GetY();
            double dvx = otroVuelo.GetVelocidadX() - this.GetVelocidadX();
            double dvy = otroVuelo.GetVelocidadY() - this.GetVelocidadY();

            double a = -((dx * dvx) + (dy * dvy));
            double b = (dvx * dvx) + (dvy * dvy);

            if (b == 0)
                return null; // Van a la misma velocidad y dirección, no se encuentran.

            // Finalmente encontramos el tiempo donde la distancia entre aviones es mínima:
            double tmin = a / b;

            // Solo nos interesa si el conflicto es en el futuro (tmin > 0)
            if (tmin > 0)
            {
                double x1Conflicto = this.currentPosition.GetX() + this.GetVelocidadX() * tmin;
                double y1Conflicto = this.currentPosition.GetY() + this.GetVelocidadY() * tmin;

                double x2Conflicto = otroVuelo.currentPosition.GetX() + otroVuelo.GetVelocidadX() * tmin;
                double y2Conflicto = otroVuelo.currentPosition.GetY() + otroVuelo.GetVelocidadY() * tmin;

                Position p1 = new Position(x1Conflicto, y1Conflicto);
                Position p2 = new Position(x2Conflicto, y2Conflicto);

                if (p1.Distancia(p2) < distSeguridad) //Si no cumplen la distancia de seguridad entre ellos:
                    return p1;
            }
            return null;

        }
        // Método que predice si pasará el conflicto.
        public bool PrediccionConflicto(FlightPlan otroVuelo, double distSeguridad)
        {
            if (PuntoConflicto(otroVuelo, distSeguridad) != null)
                return true;
            else
                return false;
        }

        // Método para intentar cambiar la velocidad (bajándola) y evitar chocar con otro vuelo (otroVuelo)
        public bool ResolverConflicto(FlightPlan otroVuelo, double distanciaSeguridad)
        {
            double velocidadOriginal = this.velocidad;
            double nuevaVelocidad = velocidadOriginal; // Velocidad de corrección (empezamos a probar con la original).

            // Frenamos la velocidad hasta que no haya conflicto:
            while (nuevaVelocidad > velocidadOriginal * 0.5) // Máximo la reduciremos al 50%.
            {
                nuevaVelocidad -= 0.5;
                this.velocidad = nuevaVelocidad;

                // Probamos si con esta velocidad ya NO hay conflicto en el futuro
                if (!this.PrediccionConflicto(otroVuelo, distanciaSeguridad))
                {
                    return true;
                }
            }
            // Si frenar no funciona, probamos a acelerar:
            nuevaVelocidad = velocidadOriginal;
            while (nuevaVelocidad < velocidadOriginal * 1.5)
            {
                nuevaVelocidad += 0.5;
                this.velocidad = nuevaVelocidad;

                if (!this.PrediccionConflicto(otroVuelo, distanciaSeguridad))
                {
                    return true;
                }
            }

            // Si ninguna estrategia funciona, volvemos a la original
            this.velocidad = velocidadOriginal;
            return false;
        }


        // Para que nos formatee los datos para guardar
        public string DarDatosGuardado()
        {
            string datosBasicos = $"{id} {initialPosition.GetX()} {initialPosition.GetY()} " +
                $"{currentPosition.GetX()} {currentPosition.GetY()} " +
                $"{finalPosition.GetX()} {finalPosition.GetY()} {velocidad} {aerolinia}";

            List<double> listaVelocidades = historialVelocidades.ToList();
            listaVelocidades.Reverse(); //ahora va del más antiguo al más reciente
            string textoVelocidades = string.Join(";", listaVelocidades);

            List<Position> listaPosPreliminar = historialPosiciones.ToList();
            listaPosPreliminar.Reverse();
            List<string> listaPosiciones = new List<string>();

            foreach (Position p in listaPosPreliminar)
            {
                listaPosiciones.Add($"{p.GetX()},{p.GetY()}");
            }

            string textoPosiciones = string.Join(";", listaPosiciones);

            string devolver = $"{datosBasicos}|{textoVelocidades}|{textoPosiciones}";

            return devolver;
        }

        // Metodo para conseguir email de la base de datos
        public string GetEmail()
        {
            string email = "No disponible";
            string dataSource = "Data Source=LoginVuelos.db";

            try
            {
                using (SQLiteConnection cnx = new SQLiteConnection(dataSource))
                {
                    // Concatenamos directamente la aerolínea en el string SQL
                    string sql = "SELECT Email FROM misCompañias WHERE Compañia = '" + this.aerolinia + "'";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Si encontró la aerolínea, extraemos el valor de la primera fila
                    if (dt.Rows.Count > 0)
                    {
                        email = dt.Rows[0]["Email"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el email: " + ex.Message);
            }

            return email;
        }

        // Metodo para conseguir el telefono
        public string GetTelefono()
        {
            string telefono = "No disponible";
            string dataSource = "Data Source=LoginVuelos.db";

            try
            {
                using (SQLiteConnection cnx = new SQLiteConnection(dataSource))
                {
                    // Concatenamos directamente la aerolínea en el string SQL
                    string sql = "SELECT Telefono FROM misCompañias WHERE Compañia = '" + this.aerolinia + "'";

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, cnx);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Si encontró la aerolínea, extraemos el valor de la primera fila
                    if (dt.Rows.Count > 0)
                    {
                        telefono = dt.Rows[0]["Telefono"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener el teléfono: " + ex.Message);
            }

            return telefono;
        }

        // Método para comprobar errores (se podría eliminar al final):

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            // Hemos hecho que la velocidad y la posición sean floats con dos decimales
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            // Hacemos que en el caso de que nuestro método nos devuelva true, escriba el mensaje siguiente: "El vuelo ha llegado a su destino"
            if (this.HaLlegado())
                Console.WriteLine("El vuelo ha llegado a su destino");
            // En el caso de que nuestro método nos devuelva false, hacemos que escriba el siguiente mensaje: "El vuelo todavía no ha llegado a su destino"
            else
                Console.WriteLine("El vuelo todavía no ha llegado a su destino");
            Console.WriteLine("******************************");
        }
    }
}
