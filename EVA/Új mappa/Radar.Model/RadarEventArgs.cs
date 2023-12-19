using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.Model
{
    public class RadarEventArgs : EventArgs
    {
        private bool[,] target;

        public bool[,] Target
        {
            get { return target; } 
            private set { target = value; }
        }

        public RadarEventArgs(bool[,] value)
        {
            int n = value.GetLength(0);
            target = new bool[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    target[i, j] = value[i, j];
                }
            }
        }

    }
}
