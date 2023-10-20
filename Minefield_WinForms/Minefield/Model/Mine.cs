﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class Mine
    {
        public readonly int x; 
        public int y;
        public int speed;

        public Mine(int maxX)
        {
            Random r = new Random();
            x = r.Next(5, maxX-5);
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