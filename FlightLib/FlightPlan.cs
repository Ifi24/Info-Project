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

        // Constructor:
        public FlightPlan(string id, double xi, double yi, double cx, double cy, double xf, double yf, double v)
        {
            this.id = id;
            this.initialPosition = new Position(xi, yi);
            this.currentPosition = new Position(cx, cy);
            this.finalPosition = new Position(xf, yf);
            this.velocidad = v;
        }

        // Métodos:
        // Gets y Sets:
        public string GetId()
        {
            return id;
        }
        public void SetId(string id)
        {
            this.id = id;
        }

        public Position GetInitialPosition()
        {
            return initialPosition;
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        public Position GetCurrentPosition()
        {
            return currentPosition;
        }
        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        public Position GetFinalPosition()
        {
            return finalPosition;
        }
        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        public double GetVelocidad()
        {
            return velocidad;
        }
        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }

        public double GetVelocidadX()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetX() - this.currentPosition.GetX()) / distTotal * this.velocidad;
        }
        public double GetVelocidadY()
        {
            double distTotal = this.currentPosition.Distancia(this.finalPosition);
            if (distTotal == 0)
                return 0;
            return (this.finalPosition.GetY() - this.currentPosition.GetY()) / distTotal * this.velocidad;
        }

        // Método que mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro.
        public void Mover(double tiempo)
        {
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

        // Método que nos dice si un vuelo ha llegado a su destino o no.
        public bool HaLlegado()
        {
            bool destino = false;
            if (currentPosition.Distancia(finalPosition) < 0.1) //Corregido por pequeños errores
                destino = true;
            return destino;
        }

        // Método que devuelve al avión a su posición inicial.
        public void Reseteo()
        {
            currentPosition = initialPosition;
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
        // Método que nos da las coordenadas del punto de conflicto.
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

        // FASE 11: Método para intentar cambiar la velocidad (bajándola) y evitar chocar con otro vuelo (otroVuelo)
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
