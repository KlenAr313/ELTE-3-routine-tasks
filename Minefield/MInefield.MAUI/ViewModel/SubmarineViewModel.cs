﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    public class SubmarineViewModel : ViewModelBase
    {
        private int difX;
        private int difY;

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

        public SubmarineViewModel(int maxX, int maxY)
        {
            this.difX = (int)(maxX / 2 - 60);

            this.difY = (int)(maxY / 2 - 60);

        }
    }
}
