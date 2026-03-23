using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan //Aquí tenemos todos nuestros métodos, atributos y constructores básicos
    {
        // Atributos

        string id; // identificador
        Position currentPosition; // posicion actual
        Position finalPosition; // posicion final
        double velocidad;
        Position initialPosition;

        // Constructures
        public FlightPlan(string id, double cpx, double cpy, double fpx, double fpy, double velocidad, double ipx, double ipy)
        {
            this.id = id;
            this.currentPosition = new Position(cpx, cpy);
            this.finalPosition = new Position(fpx, fpy);
            this.velocidad = velocidad;
            this.initialPosition = new Position(ipx, ipy);
        }

        // Gets y Sets
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


        // Metodos

        public void Mover(double tiempo)
        // Mueve el vuelo a la posición correspondiente a viajar durante el tiempo que se recibe como parámetro
        {
            //Primero miramos si hemos llegado o no (para evitar errores de cálculo):
            if (this.HasArrived())
            {
                currentPosition = finalPosition;
                return; //Sale del loop
            }

            //Calculamos la distancia recorrida en el tiempo dado
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
            //Obtenemos las coordenadas de inicio de ambos vuelos
            double x1 = this.currentPosition.GetX();
            double y1 = this.currentPosition.GetY();
            double x2 = otroVuelo.currentPosition.GetX();
            double y2 = otroVuelo.currentPosition.GetY();

            double distTotal1 = this.currentPosition.Distancia(this.finalPosition);
            double distTotal2 = otroVuelo.currentPosition.Distancia(otroVuelo.finalPosition);

            double coseno1 = 0;
            double seno1 = 0;
            double coseno2 = 0;
            double seno2 = 0;

            if (distTotal1 > 0)
            {
                coseno1 = (this.finalPosition.GetX() - x1) / distTotal1;
                seno1 = (this.finalPosition.GetY() - y1) / distTotal1;
            }
            if (distTotal2 > 0)
            {
                coseno2 = (otroVuelo.finalPosition.GetX() - x2) / distTotal2;
                seno2 = (otroVuelo.finalPosition.GetY() - y2) / distTotal2;
            }
            //Calculamos el tiempo maximo de cada vuelo
            //Es un if-else resumido para evitar errores de división por 0 en caso de que la velocidad sea 0
            double tMax1 = (this.velocidad > 0) ? (distTotal1 / this.velocidad) : 0;
            double tMax2 = (otroVuelo.velocidad > 0) ? (distTotal2 / otroVuelo.velocidad) : 0;
            double tiempoMax = Math.Max(tMax1, tMax2);

            if (tiempoCiclo <= 0)
            {
                tiempoCiclo = 1.0; //Evitar errores de división por 0 o ciclos infinitos
            }

            for (double t = 0; t <= tiempoMax; t += tiempoCiclo)
            {
                double d1 = t * this.velocidad; //el desplaçament
                double sx1 = (d1 > distTotal1) ? this.finalPosition.GetX() : x1 + d1 * coseno1;
                double sy1 = (d1 > distTotal1) ? this.finalPosition.GetY() : y1 + d1 * seno1;

                double d2 = t * otroVuelo.velocidad;
                double sx2 = (d2 > distTotal2) ? otroVuelo.finalPosition.GetX() : x2 + d2 * coseno2;
                double sy2 = (d2 > distTotal2) ? otroVuelo.finalPosition.GetY() : y2 + d2 * seno2;
                //he acabat fent els if-else resumits per mandra jajaja

                double distActual = Math.Sqrt(Math.Pow(sx1 - sx2, 2) + Math.Pow(sy1 - sy2, 2));

                if (distActual < distanciaSeguridad)
                {
                    return true; // Conflicto detectado
                }
            }
            return false; // No se detectó ningún conflicto a lo largo de la trayectoria
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
