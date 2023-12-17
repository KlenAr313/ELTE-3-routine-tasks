using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeTetris
{
    public class PlaceEventArgs: EventArgs
    {
        public int Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public PlaceEventArgs(int type, int x, int y)
        {
            Type = type;
            X = x;
            Y = y;
        }
    }
}
