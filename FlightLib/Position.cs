using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    // Clase Position que representa un punto en el espacio bidimensional (coordenadas X e Y) y proporciona herramientas para cálculos geométricos básicos.
    public class Position 
    {
        // Atributos:
        double x; 
        double y;

        // Constructor que inicializa una nueva instancia de la posición con coordenadas específicas:
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Métodos:
        // Gets y Sets:

        // Obtiene la coordenada en el eje X.
        public double GetX()
        {
            return x; 
        }

        // Asigna un nuevo valor a la coordenada X.
        public void SetX(double x)
        {
            this.x = x;
        }

        // Obtiene la coordenada en el eje Y.
        public double GetY()
        {
            return y;
        }

        // Asigna un nuevo valor a la coordenada Y.
        public void SetY(double y)
        {
            this.y = y;
        }

        // Métodos de cálculo:

        // Método que calcula la distancia entre dos posiciones:
        public double Distancia(Position b)
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return resultado;
        }
    }
}
