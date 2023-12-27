using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Stored game modell
    /// </summary>
    public class StoredGameViewModel : ViewModelBase
    {
        private string name = string.Empty;
        private DateTime modified;

        /// <summary>
        /// Name property
        /// </summary>
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

        /// <summary>
        /// Date time property
        /// </summary>
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

        /// <summary>
        /// Load command
        /// </summary>
        public DelegateCommand? LoadGameCommand { get; set; }

        /// <summary>
        /// Save command
        /// </summary>
        public DelegateCommand? SaveGameCommand { get; set; }
    }
}
