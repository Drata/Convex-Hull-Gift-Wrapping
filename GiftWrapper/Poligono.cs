using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace GiftWrapper
{
    //Excepción custom de la clase polígono.
    class PolygonException : Exception
    {
        public PolygonException(string message) : base(message) {}

    }

    class Poligono
    {
        private List<Punto> puntos;

        public Poligono()
        {
            puntos = new List<Punto>();
        }

        //Constructor para debuggera. No debe llamarse porque no comprueba puntos duplicados.
        public Poligono(List<Punto> puntos)
        {
            this.puntos = new List<Punto>(puntos);
        }

        public void AddPunto(Punto p) {
            //Comprobamos si el punto se encuentra en la lista, si es así lanzamos una excepción.
            foreach (Punto p2 in puntos) {
                if (p2.Equals(p)) {
                    PolygonException dpe = new PolygonException("Se ha intentado añadir un punto duplicado.\n");
                    throw dpe;
                }
            }

            puntos.Add(p);
        }

        public List<Punto> GetPuntos()
        {
            return puntos;
        }

        public void SetPuntos(List<Punto> puntos)
        {
            this.puntos = new List<Punto>(puntos);
        }

        public int GetPuntoBajo()
        {

            Punto punto = this.puntos[0];
            int puntoBajo = 0;


            for (int i = 0; i < puntos.Count(); i++) {
                //Si el punto tiene una Y más pequeña lo asignamos como punto bajo.
                if (puntos[i].GetY() < punto.GetY()) {
                    punto = puntos[i];
                    puntoBajo = i;
                } else if (puntos[i].GetY() == punto.GetY()) {
                    //Si hay empate entre dos puntos se coge el de más a la izquierda.
                    if (puntos[i].GetX() < punto.GetX()) {
                        punto = puntos[i];
                        puntoBajo = i;
                    }
                }
            }
            
            return puntoBajo;
        }

        //Utilizamos esta función para que el método sea transparente al usuario.
        public List<Punto> GetConvexHull()
        {
            return GiftWrapper();
        }

        
        public List<Punto> GiftWrapper()
        {

            //Comprobamos si hay 3 o menos puntos en el polígono.
            if (puntos.Count < 3)
            {
                PolygonException pe = new PolygonException("El poligono debe de tener 3 puntos o más para calcular su envolvente convexa.\n");
                throw pe;
            }
            else if (puntos.Count == 3) {
                return puntos;
            }

            int i0 = GetPuntoBajo(); //Obtenemos el punto más bajo del polígono.
            int i = i0; //Asignamos el índice del punto más bajo como primer anclaje.
            int k = 0; //Índice del punto con el ángulo más pequeño.
            double angulo; 
            double anguloMin = 0.0;
            List<Punto> convexHull = new List<Punto>();
            Punto aux = new Punto(puntos[i0].GetX() + 1, puntos[i0].GetY()); //Este punto auxiliar sirve para crear el primer eje del algoritmo.
            Vector previousEdge = new Vector(puntos[i], aux); //Creamos el primer eje del algoritmo.
            Vector newEdge;

            //Añadimos el primer punto a la envolvente convexa.
            convexHull.Add(puntos[i0]);

            do {
                //Inicializamos el angulo.
                anguloMin = 361.0;
                //Recorremos los demás puntos del polígono.
                for (int j = 0; j < puntos.Count(); j++)
                {
                    if (j != i)
                    {
                        //Creamos el nuevo vector.
                        newEdge = new Vector(puntos[i], puntos[j]);

                        //Calculamos el angulo del anterior vector con el nuevo.
                        angulo = previousEdge.AnguloTo(newEdge);

                        //Comparamos el ángulo.
                        if ((angulo <= anguloMin))
                        {
                            anguloMin = angulo;
                            k = j;
                        }
                    }
                    
                }

                //Añadimos el punto nuevo a la convex Hull.
                convexHull.Add(puntos[k]);

                //Actualizamos el eje anterior.
                previousEdge = new Vector(puntos[i], puntos[k]);

                //Actualizamos el índice del punto anterior.
                i = k;
            } while (i != i0);

            return convexHull;
        }

        public override string ToString()
        {
            string str = "";

            foreach (Punto puntoPoligono in puntos) {
                str += puntoPoligono.ToString() + "\n";
            }

            return str;
        }
    }    
}
