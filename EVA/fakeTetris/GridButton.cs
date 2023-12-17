using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakeTetris
{
    internal class GridButton : Button
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public GridButton(int x, int y) { X = x; Y = y; }
    }
}
