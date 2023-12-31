﻿using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Stored gamebrowser's viewmodel
    /// </summary>
    public class StoredGameBorwserViewModel :ViewModelBase
    {
        private StoredGameBrowserModel model;

        /// <summary>
        /// Load event
        /// </summary>
        public event EventHandler<StoredGameEventArgs>? GameLoading;

        /// <summary>
        /// Save event
        /// </summary>
        public event EventHandler<StoredGameEventArgs>? GameSaving;

        /// <summary>
        /// New save command
        /// </summary>
        public DelegateCommand NewSaveCommand { get; set; }

        /// <summary>
        /// Collection of stored games
        /// </summary>
        public ObservableCollection<StoredGameViewModel> StoredGames { get; set; }

        /// <summary>
        /// Constructor of the viewmodel
        /// </summary>
        /// <param name="model">Model</param>
        public StoredGameBorwserViewModel(StoredGameBrowserModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            this.model = model;
            this.model.StoreChanged += new EventHandler(Model_StoreChanged);

            NewSaveCommand = new DelegateCommand(param =>
            {
                string? fileName = Path.GetFileNameWithoutExtension(param?.ToString()?.Trim());
                if (!String.IsNullOrEmpty(fileName))
                {
                    fileName += ".json";
                    OnGameSaving(fileName);
                }
            });
            StoredGames = new ObservableCollection<StoredGameViewModel>();
            UpdateStoredGames();
        }

        private void UpdateStoredGames()
        {
            StoredGames.Clear();

            model.StoredGames.ForEach(i =>
            {
                StoredGames.Add(new StoredGameViewModel
                {
                    Name = i.Name,
                    Modified = i.Modified,
                    LoadGameCommand = new DelegateCommand(param => OnGameLoading(param?.ToString() ?? string.Empty)),
                    SaveGameCommand = new DelegateCommand(param => OnGameSaving(param?.ToString() ?? string.Empty))
                });
            });
        }

        private void OnGameLoading(string fileName)
        {
            GameLoading?.Invoke(this, new StoredGameEventArgs { Name = fileName });
        }

        private void OnGameSaving(string fileName)
        {
            GameSaving?.Invoke(this, new StoredGameEventArgs { Name = fileName });
        }

        private void Model_StoreChanged(object? sender, EventArgs e)
        {
            UpdateStoredGames();
        }
    }
}
