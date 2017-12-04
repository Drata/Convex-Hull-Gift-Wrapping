using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftWrapper
{
    class Vector
    {
        private int x;
        private int y;
        private double modulo;

        public Vector(Punto a, Punto b)
        {
            //Calculamos los componentes del vector.
            this.x = b.GetX() - a.GetX();
            this.y = b.GetY() - a.GetY();

            //Calculamos su módulo.
            modulo = Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0));
        }
        
        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }

        public double GetModulo()
        {
            return this.modulo;
        }

        public void SetX(int x)
        {
            this.x = x;
            //Calculamos el nuevo módulo.
            modulo = Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0));
        }
        
        public void SetY(int y)
        {
            this.y = y;
            //Calculamos el nuevo módulo.
            modulo = Math.Sqrt(Math.Pow(this.x, 2.0) + Math.Pow(this.y, 2.0));
        }

        public int ProductoEscalar(Vector v)
        {
            return (this.x * v.x) + (this.y * v.y);
        }

        public double AnguloTo(Vector v)
        {
            double coseno = this.ProductoEscalar(v) / (this.modulo * v.GetModulo());
            //Devolvemos el ángulo en grados.
            return Math.Acos(coseno) * (180/Math.PI);
        }
    }
}
