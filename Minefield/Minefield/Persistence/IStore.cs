using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Persistence
{

    public interface IStore
    {
        Task<IEnumerable<string>> GetFile();

        Task<DateTime> GetModifiedTime(string name);
    }
}
