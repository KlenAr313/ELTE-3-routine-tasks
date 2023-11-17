using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Class of a mine
    /// </summary>
    public class Mine
    {
        private int x;
        private int y;
        private int speed;

        /// <summary>
        /// Horizontal position
        /// </summary>
        public int X { get { return x; } set { x = value; } }

        /// <summary>
        /// Vertical position
        /// </summary>
        public int Y { get { return y; } set { y = value; } }

        /// <summary>
        /// Speed of the mine
        /// </summary>
        public int Speed { get { return speed; } set { speed = value; } }

        /// <summary>
        /// Constructor in case of new game
        /// </summary>
        /// <param name="maxX">Maximum horizontal position</param>
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

        /// <summary>
        /// Default constructor in case of loading a saved game
        /// </summary>
        public Mine() { }

        /// <summary>
        /// Moving the mine downwards
        /// </summary>
        public void Move()
        {
            y += speed;
        }
    }
}
