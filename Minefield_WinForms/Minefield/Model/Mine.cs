using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class Mine
    {
        private readonly int x; 
        private int y;
        private int speed;

        public int X { get { return x; } }

        public int Y { get { return y; } }


        public Mine(int maxX)
        {
            Random r = new Random();
            x = r.Next(5, maxX-55);
            switch (r.Next(1, 4))
            {
                case 1: speed = 2; break;
                case 2: speed = 3; break;
                case 3: speed = 4; break;
            }
        }

        public Mine(Mine that)
        {
            x = that.x;
            y = that.y;
            speed = that.speed;
        }

        public void Move()
        {
            y += speed;
        }
    }
}
