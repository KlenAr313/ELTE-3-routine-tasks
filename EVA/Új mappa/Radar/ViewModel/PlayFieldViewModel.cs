using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.ViewModel
{
    public class PlayFieldViewModel : ViewModelBase
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public Tuple<int, int> XY
        {
            get { return new(Row, Column); }
        }

        private string IS;

        public string Is
        {
            get
            {
                return IS;
            }
            set
            {
                IS = value;
                OnPropertyChanged(nameof(IS));
            }
        }

        public DelegateCommand? StepCommand { get; set; }
    }
}
