using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winFormZH.Model.Persistence
{
    public interface IDataAccess
    {
        GameData Load(String path);
        void Save(String path, GameData gameData);
    }
}
