using Minefield.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.Model
{
    /// <summary>
    /// Stored games browser's model
    /// </summary>
    public class StoredGameBrowserModel
    {
        private readonly IStore store;

        /// <summary>
        /// List of stored games
        /// </summary>
        public List<StoredGameModel> StoredGames { get; private set; }

        /// <summary>
        /// Event of store changing
        /// </summary>
        public event EventHandler? StoreChanged;

        /// <summary>
        /// Constructor of the model
        /// </summary>
        /// <param name="store">Interface of store</param>
        public StoredGameBrowserModel(IStore store)
        {
            this.store = store;

            StoredGames = new List<StoredGameModel>();
        }

        /// <summary>
        /// Update of stored games
        /// </summary>
        /// <returns></returns>
        public async Task UpdateAsync()
        {
            if(store == null) return;

            StoredGames.Clear();

            foreach (var name in await store.GetFile())
            {
                if (name == "Sus") continue;

                StoredGames.Add(new StoredGameModel(name, await store.GetModifiedTime(name)));
            }

            StoredGames = StoredGames.OrderByDescending(i => i.Modified).ToList();
        
            StoreChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
