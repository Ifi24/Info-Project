using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class Position 
    {
        // Atributos:
        double x; 
        double y; 

        // Constructor:
        public Position(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        // Métodos:
        // Gets y Sets:
        public double GetX()
        {
            return x; 
        }
        public void SetX(double x)
        {
            this.x = x;
        }

        public double GetY()
        {
            return y;
        }
        public void SetY(double y)
        {
            this.y = y;
        }

        // Método que calcula la distancia entre dos posiciones:
        public double Distancia(Position b)
        {
            double resultado = Math.Sqrt((x - b.x) * (x - b.x) + (y - b.y) * (y - b.y));
            return resultado;
        }
    }
}
