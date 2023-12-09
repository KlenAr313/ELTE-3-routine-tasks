using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    public class StoredGameViewModel : ViewModelBase
    {
        private string name = string.Empty;
        private DateTime modified;

        public string Name {  
            get { return name; } 
            set 
            { 
                if (name != value) 
                { 
                    name = value; 
                    OnPropertyChanged(); 
                } 
            } 
        }

        public DateTime Modified
        {
            get { return modified; }
            set
            {
                if (modified != value)
                {
                    modified = value;
                    OnPropertyChanged();
                }
            }
        }

        public DelegateCommand? LoadGameCommand { get; set; }
        public DelegateCommand? SaveGameCommand { get; set; }
    }
}
