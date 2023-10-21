using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class MinefieldEventArgs : EventArgs
    {
        private List<Mine> mines;
        private Submarine submarine;

        public List<Mine> Mines { 
            get 
            {
                return mines;
            } 
        }

        public Submarine Submarine { get { return submarine; } }

        public MinefieldEventArgs(List<Mine> mines, Submarine submarine) 
        {
            this.mines = mines;
            this.submarine = submarine;
        }
    }
}
