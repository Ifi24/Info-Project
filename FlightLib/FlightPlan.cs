using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlan
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
            //Calculamos la distancia recorrida en el tiempo dado
            double distancia = tiempo * this.velocidad / 60;

            //Calculamos las razones trigonométricas
            double hipotenusa = Math.Sqrt((finalPosition.GetX() - currentPosition.GetX()) * (finalPosition.GetX() - currentPosition.GetX()) + (finalPosition.GetY() - currentPosition.GetY()) * (finalPosition.GetY() - currentPosition.GetY()));
            double coseno = (finalPosition.GetX() - currentPosition.GetX()) / hipotenusa;
            double seno = (finalPosition.GetY() - currentPosition.GetY()) / hipotenusa;

            //Caculamos la nueva posición del vuelo
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
            if (currentPosition == finalPosition)
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
