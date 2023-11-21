using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Static class for containg the active directions of the player
    /// </summary>
    public static class Directions
    {
        private static bool up = false;
        private static bool down = false;
        private static bool left = false;
        private static bool right = false;

        /// <summary>
        /// Upward stat
        /// </summary>
        public static bool Up { get { return up; } set { up = value; } }

        /// <summary>
        /// Downward stat
        /// </summary>
        public static bool Down { get { return down; } set { down = value; } }

        /// <summary>
        /// Left stat
        /// </summary>
        public static bool Left { get { return left; } set { left = value; } }

        /// <summary>
        /// Right stat
        /// </summary>
        public static bool Right { get { return right; } set {  right = value; } }

        /// <summary>
        /// Reset every direction to false
        /// </summary>
        public static void Reset()
        {
            Up = false;
            Down = false;
            Left = false;
            Right = false;
        }
    }
}
