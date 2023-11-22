﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Player character
    /// </summary>
    public class Submarine
    {
        private const int speed = 2;
        private int x = 250;
        private int y = 700;
        private int maxX;
        private int maxY;

        /// <summary>
        /// Horizontal position
        /// </summary>
        public int X { get { return x; } set { x = value; } }

        /// <summary>
        /// Vertical position
        /// </summary>
        public int Y { get { return y; } set { y = value; } }

        /// <summary>
        /// Maximum horizontal position
        /// </summary>
        public int MaxX { get { return maxX; } set { maxX = value; } }

        /// <summary>
        /// Maximum horizontal position
        /// </summary>
        public int MaxY { get { return maxY; } set { maxY = value; } }

        /// <summary>
        /// Constructor in case of new game
        /// </summary>
        /// <param name="maxX">Maximum horizontal position</param>
        /// <param name="maxY">Maximum vertical position</param>
        public Submarine(int maxX, int maxY)
        {
            this.maxX = maxX - 128;
            this.maxY = maxY - 190;
        }

        /// <summary>
        /// Default constructor in case of loading a saved game
        /// </summary>
        public Submarine() 
        { }

        /// <summary>
        /// Moving the submarine upwards
        /// </summary>
        public void MoveUp()
        {
            if ( y > 20)
                y -= speed;
        }

        /// <summary>
        /// Moving the submarine downwards
        /// </summary>
        public void MoveDown()
        {
            if( y < maxY )
                y += speed;
        }

        /// <summary>
        /// Moving the submarine to the right
        /// </summary>
        public void MoveLeft()
        {
            if ( x > 5 )
                x -= speed;
        }


        /// <summary>
        /// Moving the submarine to the left
        /// </summary>
        public void MoveRight()
        {
            if ( x < maxX )
                x += speed;
        }
    }
}