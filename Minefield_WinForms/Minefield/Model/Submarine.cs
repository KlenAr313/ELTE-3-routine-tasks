using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class Submarine
    {
        private const int speed = 2;
        private int x = 250;
        private int y = 700;
        private int maxX;
        private int maxY;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int MaxX { get { return maxX; } set { maxX = value; } }
        public int MaxY { get { return maxY; } set { maxY = value; } }

        public Submarine(int maxX, int maxY)
        {
            this.maxX = maxX - 128;
            this.maxY = maxY - 190;
        }

        public Submarine() 
        { }

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
