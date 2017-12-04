using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Punto> convexHull;
            Poligono pol = new Poligono();
            Random rnd = new Random();

            //Generamos 10 puntos aleatorios y los introducimos en el polígono.
            for (int i = 0; i < 10; i++)
            {
                int x = rnd.Next(-10, 10);
                int y = rnd.Next(-10, 10);
                Punto punto = new Punto(x, y);

                try
                {
                    pol.AddPunto(punto);
                }
                catch
                {
                    //Si no puede introducir el punto genera otro.
                    i--;
                }
            }

            Console.WriteLine("Puntos del polígono:");
            Console.WriteLine(pol);

            //Calculamos la envolvente convexa llamando (GiftWrapper).
            try
            {
                convexHull = pol.GetConvexHull();

                //Imprimimos el resultado.
                Console.WriteLine("\nEnvolvente convexa:");
                foreach (Punto p1 in convexHull)
                {
                    Console.WriteLine(p1);
                }
            }
            catch (PolygonException pe)
            {
                Console.WriteLine(pe.ToString());
            }
        }
    }
}
