using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightLib
{
    public class FlightPlanList
    {
        List<FlightPlan> listaVuelos = new List<FlightPlan>();

        // Métodos:
        public int GetNumAviones()
        {
            return listaVuelos.Count;
        }
        public void AddFlightPlan(FlightPlan p)
        {
            listaVuelos.Add(p);
        }
        public FlightPlan GetFlightPlan(int i)
        {
            if (i < 0 || i >= listaVuelos.Count)
                return null; 
            else
                return listaVuelos[i];
        }
        public void Mover(double tiempo) //Avisa para activar movimiento
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.Mover(tiempo);
            }
        }
        public void EscribeConsola()
        {
            foreach (FlightPlan vuelo in listaVuelos)
            {
                vuelo.EscribeConsola();
            }
        }
    }
}
