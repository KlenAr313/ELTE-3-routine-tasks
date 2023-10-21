using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public static class Directions
    {
        public static bool Up = false;
        public static bool Down = false;
        public static bool Left = false;
        public static bool Right = false;

        public static void Reset()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
        }
    }
}
