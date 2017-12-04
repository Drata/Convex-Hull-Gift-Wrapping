using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftWrapper
{
    public class Punto
    {
        private int x;
        private int y;

        public Punto(int coordX, int coordY)
        {
            this.x = coordX;
            this.y = coordY;
        }

        public int GetX()
        {
            return x;
        }

        public int GetY()
        {
            return y;
        }

        public void SetX(int coordX)
        {
            this.x = coordX;
        }

        public void SetY(int coordY)
        {
            this.y = coordY;
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")\n";
        }

        public override bool Equals(Object obj)
        {
            Punto p = (Punto) obj;

            if (x == p.GetX() && y == p.GetY()) {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        { 
            return base.GetHashCode();
        }
    }
}
