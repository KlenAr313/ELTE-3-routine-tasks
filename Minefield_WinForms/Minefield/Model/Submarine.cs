using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class Submarine
    {
        private int x = 250;
        private int y = 700;
        private const int speed = 2;
        private readonly int maxX;
        private readonly int maxY;

        public int X { get { return x; } }
        public int Y { get { return y; } }

        public Submarine(int maxX, int maxY)
        {
            this.maxX = maxX - 128;
            this.maxY = maxY - 190;
        }

        public void MoveUp()
        {
            if ( y > 20)
                y -= speed;
        }

        public void MoveDown()
        {
            if( y < maxY )
                y += speed;
        }

        public void MoveLeft()
        {
            if ( x > 5 )
                x -= speed;
        }

        public void MoveRight()
        {
            if ( x < maxX )
                x += speed;
        }
    }
}
