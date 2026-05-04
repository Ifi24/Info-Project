using System;
using System.Collections.Generic;
using System.Linq;
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
        // Parámetros: id (string), coordenadas iniciales; xi, yi (double), actuales; cx, cy (double), finales; xf, yf (double), velocidad; v (double) y aerolínea; aerolinia (string).
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
        // Parámetros: ninguno.
        // Devuelve: id (string).
        public string GetId()
        {
            return id;
        }

        // Asigna un nuevo identificador al vuelo.
        // Parámetros: id (string).
        // Devuelve: nada.
        public void SetId(string id)
        {
            this.id = id;
        }

        // Obtiene la posición inicial de origen del vuelo.
        // Parámetros: ninguno.
        // Devuelve: objeto Position con las coordenadas de origen.
        public Position GetInitialPosition()
        {
            return initialPosition;
        }

        // Establece una nueva posición inicial para el vuelo.
        // Parámetros: initialPosition (Position).
        // Devuelve: nada.
        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        // Obtiene la posición actual en la que se encuentra el avión.
        // Parámetros: ninguno.
        // Devuelve: objeto Position con las coordenadas actuales.
        public Position GetCurrentPosition()
        {
            return currentPosition;
        }

        // Actualiza la posición actual del avión manualmente.
        // Parámetros: currentPosition (Position).
        // Devuelve: nada.
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        // Obtiene la posición de destino final del vuelo.
        // Parámetros: ninguno.
        // Devuelve: objeto Position con las coordenadas de destino.
        public Position GetFinalPosition()
        {
            return finalPosition;
        }

        // Establece una nueva posición final de destino.
        // Parámetros: finalPosition (Position).
        // Devuelve: nada.
        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        // Obtiene el valor de la velocidad escalar del avión.
        // Parámetros: ninguno.
        // Devuelve: velocidad (double).
        public double GetVelocidad()
        {
            return velocidad;
        }

        // Asigna una nueva velocidad al plan de vuelo.
        // Parámetros: velocidad (double).
        // Devuelve: nada.
        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }

        // Calcula la componente X de la velocidad actual.
        // Parámetros: ninguno.
        // Devuelve: velocidad en el eje X (double).
        public double GetVelocidadX()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetX() - this.currentPosition.GetX()) / distTotal * this.velocidad;
        }

        // Calcula la componente Y de la velocidad actual.
        // Parámetros: ninguno.
        // Devuelve: velocidad en el eje Y (double).
        public double GetVelocidadY()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetY() - this.currentPosition.GetY()) / distTotal * this.velocidad;
        }

        // Asigna el nombre de la aerolínea a la que pertenece el avión.
        // Parámetros: aerolinia (string).
        // Devuelve: nada.
        public void SetAerolinia(string aerolinia)
        {
            this.aerolinia = aerolinia;
        }

        // Obtiene el nombre de la aerolínea propietaria del vuelo.
        // Parámetros: ninguno.
        // Devuelve: nombre de la aerolínea (string).
        public string GetAerolinia()
        {
            return aerolinia;
        }

        // Sobrescribe el historial de posiciones.
        // Parámetros: historial (Stack de Position).
        // Devuelve: nada.
        public void SetHistorialPosiciones(Stack<Position> historial)
        {
            this.historialPosiciones = historial;
        }

        // Sobrescribe el historial de velocidades.
        // Parámetros: historial (Stack de double).
        // Devuelve: nada.
        public void SetHistorialVelocidades(Stack<double> historial)
        {
            this.historialVelocidades = historial;
        }

        //Métodos de movimiento

        // Método que mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro.
        // Parámetros: tiempo (double) transcurrido en la simulación.
        // Devuelve: nada.
        public void Mover(double tiempo)
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

        // Método que mueve el vuelo hacia atrás en la posición correspondiente según el tiempo que se recibe de parámetro:
        // Parámetros: tiempo (double).
        // Devuelve: nada.
        public void MoverAtras(double tiempo)
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
        // Parámetros: ninguno.
        // Devuelve: true si ha llegado, false si no.
        public bool HaLlegado()
        {
            bool destino = false;
            if (currentPosition.Distancia(finalPosition) < 0.1) //Corregido por pequeños errores
                destino = true;
            return destino;
        }

        // Comprueba si el avión se encuentra todavía en su posición inicial (origen).
        // Parámetros: ninguno.
        // Devuelve: true si está en el origen (con margen de error de 0.1), false en caso contrario.
        public bool SigueEnOrigen()
        {
            bool origen = false;
            if (currentPosition.Distancia(initialPosition) < 0.1)
                origen = true;
            return origen;
        }

        // Método que devuelve al avión a su posición inicial.
        // Parámetros: ninguno.
        // Devuelve: nada.
        public void Reseteo()
        {
            currentPosition = initialPosition;

            historialPosiciones.Clear();
            historialVelocidades.Clear();
        }

        // Método que da la distancia que se ha movido el avion.
        // Parámetros: plan (FlightPlan) con el que se quiere comparar la distancia.
        // Devuelve: distancia entre ambos aviones (double).
        public double DistanciaViajada(FlightPlan plan)
        {
            return this.currentPosition.Distancia(plan.currentPosition);
        }

        // Método que detecta si hay un conflicto según la distancia de seguridad proporcionada
        // Parámetros: b (FlightPlan) a comparar, distanciaSeguridad (double) mínima permitida.
        // Devuelve: true si la distancia es menor a la de seguridad, false si es una zona segura.
        public bool Conflicto(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;
            return conflicto;
        }

        //FASE 10: Predice si habrá un conflicto a lo largo de toda la trayectoria.
        // Método que nos da las coordenadas del punto de conflicto.
        // Parámetros: otroVuelo (FlightPlan), distSeguridad (double).
        // Devuelve: objeto Position del conflicto o null si no hay colisión.
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
        // Parámetros: otroVuelo (FlightPlan) a comparar, distSeguridad (double) de separación mínima.
        // Devuelve: true si se detecta una colisión futura, false si las trayectorias son seguras.
        public bool PrediccionConflicto(FlightPlan otroVuelo, double distSeguridad)
        {
            if (PuntoConflicto(otroVuelo, distSeguridad) != null)
                return true;
            else
                return false;
        }

        // FASE 11: Método para intentar cambiar la velocidad (bajándola) y evitar chocar con otro vuelo (otroVuelo)
        // Parámetros: otroVuelo (FlightPlan), distanciaSeguridad (double).
        // Devuelve: true si se encontró una velocidad segura, false si no.
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
        // Parámetros: ninguno.
        // Devuelve: string con datos básicos e historiales separados por '|'.
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


















        // Método para comprobar errores (se podría eliminar al final):
        // Parámetros: Ninguno.
        // Devuelve: Nada.
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
