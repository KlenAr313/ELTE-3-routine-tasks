using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LameChess.ViewModel
{
    public class PlayFieldViewModel : ViewModelBase
    {
        public int Row { get; set; }
        public int Column { get; set; }
        private int num;
        public int Num
        {
            get
            {
                return num;
            }

            set
            {
                if(num != value)
                {
                    num = value;
                    switch (num)
                    {
                        case 0: Text = string.Empty; break;
                        case 1: case 5: Text = "1"; break;
                        case 2: case 6: Text = "2"; break;
                        case 3: case 7: Text = "3"; break;
                        case 4: case 8: Text = "4"; break;
                        default: break;
                    }
                }
            }
        }
        public Tuple<int, int> XY
        {
            get { return new(Row, Column); }
        }

        public string Text { get; set; } = string.Empty;

        public DelegateCommand? StepCommand { get; set; }
    }
}
