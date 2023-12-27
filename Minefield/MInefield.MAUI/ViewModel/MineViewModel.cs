using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Mine's view model
    /// </summary>
    public class MineViewModel: ViewModelBase
    {
        private static int difX = 0;
        private static int difY = 0;

        private int x;

        /// <summary>
        /// Vertical Position
        /// </summary>
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

        /// <summary>
        /// Horizontal position
        /// </summary>
        public int Y
        {
            get { return y; }
            set
            {
                y = value - difY;
                OnPropertyChanged(nameof(Y));
            }
        }

        /// <summary>
        /// Sets the difference based on the size of the playground
        /// </summary>
        /// <param name="maxX">Horizontal size of the playground</param>
        /// <param name="maxY">Vertical size of the playground</param>
        public static void SetDifference(int maxX, int maxY)
        {
            difX = (int)(maxX / 2 - 25);

            difY = (int)(maxY / 2 - 25);
        }
    }
}
