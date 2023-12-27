using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Subarine's view model
    /// </summary>
    public class SubmarineViewModel : ViewModelBase
    {
        private int difX;
        private int difY;

        private int x;

        /// <summary>
        /// Horizoltal position
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
        /// Vertical position
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
        /// Constructor of the wiew model
        /// </summary>
        /// <param name="maxX">Horizontal size of the playground</param>
        /// <param name="maxY">Vertical size of the playground</param>
        public SubmarineViewModel(int maxX, int maxY)
        {
            this.difX = (int)(maxX / 2 - 60);

            this.difY = (int)(maxY / 2 - 60);

        }
    }
}
