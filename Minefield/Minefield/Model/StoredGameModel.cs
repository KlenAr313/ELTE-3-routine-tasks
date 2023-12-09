using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    public class StoredGameModel
    {
        public string Name { get; set; } = string.Empty; 
        public DateTime Modified {  get; set; }

        public StoredGameModel(string name, DateTime modified)
        {
            Name = name;
            Modified = modified;
        }
    }
}
