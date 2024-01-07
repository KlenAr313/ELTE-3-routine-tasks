using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mauiZH.Model.Persistence
{
    /// <summary>
    /// Játék tároló interfésze.
    /// </summary>
    public interface IStore
    {
        /// <summary>
        /// Fájlok lekérdezése.
        /// </summary>
        /// <returns>A fájlok listája.</returns>
        Task<IEnumerable<String>> GetFilesAsync();

        /// <summary>
        /// Módosítás idejének lekrédezése.
        /// </summary>
        /// <param name="name">A fájl neve.</param>
        /// <returns>Az utolsó módosítás ideje.</returns>
        Task<DateTime> GetModifiedTimeAsync(String name);
    }
}
