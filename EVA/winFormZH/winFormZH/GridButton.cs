using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winFormZH
{
    public class GridButton: Button
    {
        private int x;
        private int y;

        public int X { get { return x; } }

        public int Y { get { return y; } }

        public GridButton(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
