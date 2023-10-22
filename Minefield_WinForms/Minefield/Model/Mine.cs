using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class Mine
    {
        private int x;
        private int y;
        private int speed;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int Speed { get { return speed; } set { speed = value; } }


        public Mine(int maxX)
        {
            y = 0;
            Random r = new Random();
            x = r.Next(5, maxX-55);
            switch (r.Next(1, 4))
            {
                case 1: speed = 2; break;
                case 2: speed = 3; break;
                case 3: speed = 4; break;
            }
        }

        public Mine() { }

        public void Move()
        {
            y += speed;
        }
    }
}
