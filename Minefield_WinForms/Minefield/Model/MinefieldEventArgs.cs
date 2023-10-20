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

        public List<Mine> Mines { 
            get 
            { 
                List<Mine> copy = new List<Mine>();
                mines.ForEach(m => copy.Add(new Mine(m)));
                return copy;
            } 
        }

        public MinefieldEventArgs(List<Mine> mines) 
        {
            this.mines = mines;
        }
    }
}
