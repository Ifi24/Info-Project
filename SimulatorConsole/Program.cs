using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightLib;

namespace SimulatorConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            FlightPlanList lista = new FlightPlanList();
            try 
            {
                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                string identificador = Console.ReadLine(); ;

                Console.WriteLine("Escribe la velocidad");
                double velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                string linea = Console.ReadLine();
                string[] trozos = linea.Split(' ');
                double ix = Convert.ToDouble(trozos[0]);
                double iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                double fx = Convert.ToDouble(trozos[0]);
                double fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_a = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);

                Console.WriteLine("Escribe el identificador");
                //   string nombre = Console.ReadLine();
                identificador = Console.ReadLine(); ;

                Console.WriteLine("Escribe la velocidad");
                velocidad = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Escribe las coordenadas de la posición inicial, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                ix = Convert.ToDouble(trozos[0]);
                iy = Convert.ToDouble(trozos[1]);

                Console.WriteLine("Escribe las coordenadas de la posición final, separadas por un blanco");
                linea = Console.ReadLine();
                trozos = linea.Split(' ');
                fx = Convert.ToDouble(trozos[0]);
                fy = Convert.ToDouble(trozos[1]);

                FlightPlan plan_b = new FlightPlan(identificador, ix, iy, fx, fy, velocidad);

                lista.AddFlightPlan(plan_a);
                lista.AddFlightPlan(plan_b);

                double distanciaSeguridad = 10;

                int i = 0; // Empezamos dándole a i un valor de inicio (0), que luego usaremos para saber si nos mantenemos en el bucle o lo terminamos
                int ciclos = 50; // Determinamos el número de ciclos que queremos

                while (i < ciclos) // Hasta que i no llegue al número de ciclos que queremos y hemos establecido, seguirá realizando el bucle
                {
                    lista.Mover(10);
                    lista.EscribeConsola();
                    if (plan_a.ConflictoDistancia(plan_b, distanciaSeguridad))
                        Console.WriteLine("Hay un conflicto con la distancia de seguridad.");
                    i++; // Mientras la i sea menor que el número de ciclos se le sumará 1 para pasar al siguiente ciclo
                }
                plan_a.EscribeConsola();
            }
            catch (FormatException) // Si hemos instroducido los datos de manera incorrecta, nos devolverá el mensaje: "Introduce los datos correctamente, por favor."
            {
                Console.WriteLine("Introduce los datos correctamente, por favor.");
            }


            Console.ReadLine();
        }
    }
}
