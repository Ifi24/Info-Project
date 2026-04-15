using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan //Aquí tenemos todos nuestros métodos, atributos y constructores para un FlightPlan.
    {
        // Atributos:
        string id; 
        Position currentPosition; 
        Position finalPosition; 
        double velocidad;
        Position initialPosition;

        // Constructures:
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, double ipx, double ipy)
        {
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.initialPosition = new Position(ipx, ipy);
        }

        // Métodos:
        // Gets y Sets:
        public string GetId()
        {
            return id;
        }

        public Position GetCurrentPosition()
        {
            return currentPosition;
        }

        public Position GetFinalPosition()
        {
            return finalPosition;
        }

        public double GetVelocidad()
        {
            return velocidad;
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

        public Position GetInitialPosition()
        {
            return initialPosition;
        }

        public void SetId(string id)
        {
            this.id = id;
        }

        public void SetCurrentPosition(Position currentPosition)
        {
            this.currentPosition = currentPosition;
        }

        public void SetFinalPosition(Position finalPosition)
        {
            this.finalPosition = finalPosition;
        }

        public void SetVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }

        public void SetInitialPosition(Position initialPosition)
        {
            this.initialPosition = initialPosition;
        }

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro.
        {
            // Comprobamos que aún no hemos llegado.
            if (this.HasArrived())
            {
                currentPosition = finalPosition;
                return; //Sale del loop
            }

            // Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad; //Velocidad en m/s y tiempo en s

            //Calculamos las razones trigonométricas
            double hipotenusa = currentPosition.Distancia(finalPosition);
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Calculamos la nueva posición del vuelo
            double x = currentPosition.GetX() + distancia * coseno;
            double y = currentPosition.GetY() + distancia * seno;

            // Cambiamos el nombre porque la vamos a usar para saber si estamos todavía en el vuelo o si hemos llegado al final de este por lo que nos pararíamos
            // Hay que poner Position porque nextPosition no está declarada, antes no la poníamos porque la hemos declarado antes
            Position nextPosition = new Position(x, y);

            if (currentPosition.Distancia(nextPosition) < hipotenusa)
                currentPosition = nextPosition;
            else
                currentPosition = finalPosition;
        }

        // Método para saber si un vuelo ha llegado a su destino o no
        public bool HasArrived()
        {
            bool destino = false;
            if (currentPosition.Distancia(finalPosition) < 0.1) //Corregido por pequeños errores
                destino = true;
            return destino;
        }

        public void Restart()
        {
            currentPosition = initialPosition;
        }

        public double Distance(FlightPlan plan)
        {
            return this.currentPosition.Distancia(plan.currentPosition);
        }

        // Método que detecta el conflicto según la distancia de seguridad proporcionada
        public bool ConflictoDistancia(FlightPlan b, double distanciaSeguridad)
        {
            bool conflicto = false;
            if (this.currentPosition.Distancia(b.currentPosition) < distanciaSeguridad)
                conflicto = true;
            return conflicto;
        }

        //FASE 10: Método para predecir si habrá un conflicto a lo largo de toda la trayectoria
        public bool ConflictoTrayectoria(FlightPlan otroVuelo, double distanciaSeguridad, double tiempoCiclo)
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
                return this.ConflictoDistancia(otroVuelo, distanciaSeguridad);

            // Finalmente encontramos el tiempo:
            double tmin = a / b;
            // Predecimos posiciones:
            double tahora = Math.Max(0, Math.Min(tmin, tiempoCiclo));

            Position pos1Min = new Position(
            this.currentPosition.GetX() + this.GetVelocidadX() * tahora,
            this.currentPosition.GetY() + this.GetVelocidadY() * tahora);

            Position pos2Min = new Position(
            otroVuelo.currentPosition.GetX() + otroVuelo.GetVelocidadX() * tahora,
            otroVuelo.currentPosition.GetY() + otroVuelo.GetVelocidadY() * tahora);

            return pos1Min.Distancia(pos2Min) < distanciaSeguridad;
        }

        // FASE 11: Método para intentar cambiar la velocidad (bajándola) y evitar chocar con otro vuelo (otroVuelo)
        public bool ResolverConflicto(FlightPlan otroVuelo, double distanciaSeguridad, double tiempoCiclo)
        {
            double velocidadOriginal = this.velocidad; // La velocidad de nuestro avión
            double nuevaVelocidad = velocidadOriginal; // La velocidad que probaremos para arreglar el problema (la igualamos a la original porque empezaremos a probar desde esta velocidad) 

            // Estrategia: Intentar frenar un poco (hasta el 50% de la velocidad original)
            while (nuevaVelocidad > velocidadOriginal * 0.5) // Sigue intentándolo mientras la nueva velocidad no sea menor a la mitad de la original (hay que poner un límite porque un avión no puede pararse por seguridad pero no sé si 50% está bien o qué)).
            {
                nuevaVelocidad -= 0.5; // Bajamos la velocidad de 0.5 en 0.5 unidades (no sé si 0.5 está bien o es poco/mucho)
                this.velocidad = nuevaVelocidad;

                // Probamos si con esta velocidad ya NO hay conflicto en el futuro
                if (!this.ConflictoTrayectoria(otroVuelo, distanciaSeguridad, tiempoCiclo))
                {
                    return true; // Hemos encontrado una velocidad segura
                }
            }
            // Estrategia alternativa: Si frenar no funcionó, intentamos acelerar (hasta un 50% más)
            nuevaVelocidad = velocidadOriginal;
            while (nuevaVelocidad < velocidadOriginal * 1.5)
            {
                nuevaVelocidad += 0.5;
                this.velocidad = nuevaVelocidad;

                if (!this.ConflictoTrayectoria(otroVuelo, distanciaSeguridad, tiempoCiclo))
                {
                    return true;
                }
            }

            // Si ninguna de las dos funcionó, dejamos la velocidad como estaba (No sé si hay que hacer algo más aquí)
            this.velocidad = velocidadOriginal;
            return false;
        }

        public void EscribeConsola()
        // escribe en consola los datos del plan de vuelo
        {
            Console.WriteLine("******************************");
            Console.WriteLine("Datos del vuelo: ");
            Console.WriteLine("Identificador: {0}", id);
            // Hemos hecho que la velocidad y la posición sean floats con dos decimales
            Console.WriteLine("Velocidad: {0:F2}", velocidad);
            Console.WriteLine("Posición actual: ({0:F2},{1:F2})", currentPosition.GetX(), currentPosition.GetY());
            // Hacemos que en el caso de que nuestro método nos devuelva true, escriba el mensaje siguiente: "El vuelo ha llegado a su destino"
            if (this.HasArrived())
                Console.WriteLine("El vuelo ha llegado a su destino");
            // En el caso de que nuestro método nos devuelva false, hacemos que escriba el siguiente mensaje: "El vuelo todavía no ha llegado a su destino"
            else
                Console.WriteLine("El vuelo todavía no ha llegado a su destino");
            Console.WriteLine("******************************");
        }
    }
}
