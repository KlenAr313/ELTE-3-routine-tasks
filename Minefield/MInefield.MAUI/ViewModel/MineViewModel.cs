using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    public class MineViewModel: ViewModelBase
    {
        private static int difX = 0;
        private static int difY = 0;

        private int x;

        public int X
        {
            get { return x; }
            set
            {
                x = value - difX;
                OnPropertyChanged(nameof(X));
            }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set
            {
                y = value - difY;
                OnPropertyChanged(nameof(Y));
            }
        }

        public static void SetDifference(int maxX, int maxY)
        {
            difX = (int)(maxX / 2 - 25);

            difY = (int)(maxY / 2 - 25);
        }
    }
}
