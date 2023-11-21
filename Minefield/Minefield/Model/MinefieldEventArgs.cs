using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Event argument for communicating changes with View
    /// </summary>
    public class MinefieldEventArgs : EventArgs
    {
        private readonly List<Mine> mines;
        private readonly Submarine submarine;

        /// <summary>
        /// List of active mines
        /// </summary>
        public List<Mine> Mines { 
            get 
            {
                return mines;
            } 
        }

        /// <summary>
        /// The player character
        /// </summary>
        public Submarine Submarine { get { return submarine; } }

        /// <summary>
        /// Constructor of Event argument
        /// </summary>
        /// <param name="mines">Active mines</param>
        /// <param name="submarine">Player character</param>
        public MinefieldEventArgs(List<Mine> mines, Submarine submarine) 
        {
            this.mines = mines;
            this.submarine = submarine;
        }
    }
}
