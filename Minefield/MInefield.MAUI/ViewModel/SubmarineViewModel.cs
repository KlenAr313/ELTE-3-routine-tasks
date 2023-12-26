using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    public class SubmarineViewModel : ViewModelBase
    {
        private int x;

        public int X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private int y;

        public int Y
        {
            get { return y; }
            set 
            { 
                y = value; 
                OnPropertyChanged(nameof(Y));
            }
        }


    }
}
