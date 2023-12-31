﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfZH.ViewModel
{
    public class GridViewModel: ViewModelBase
    {
        private int num;

        public int Num
        {
            get { return num; }
            set 
            { 
                if(num != value)
                {
                    num = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Row { get; set; }
        public int Column { get; set; }

        public DelegateCommand? FieldChangeCommand { get; set; }
    }
}
