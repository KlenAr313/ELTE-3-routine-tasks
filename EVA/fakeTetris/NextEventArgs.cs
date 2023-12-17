using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeTetris
{
    public class NextEventArgs : EventArgs
    {
        public int Type { get; set; }

        public NextEventArgs(int type)
        {
            if (type <= 4 && type >= 1)
                Type = type;
            else
            {
                throw new ArgumentException("Wrong Type");
            }
        }
    }
}
