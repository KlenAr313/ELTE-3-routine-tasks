using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public static class Directions
    {
        private static bool up = false;
        private static bool down = false;
        private static bool left = false;
        private static bool right = false;

        public static bool Up { get { return up; } set { up = value; } }
        public static bool Down { get { return down; } set { down = value; } }
        public static bool Left { get { return left; } set { left = value; } }
        public static bool Right { get { return right; } set {  right = value; } }

        public static void Reset()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
        }
    }
}
