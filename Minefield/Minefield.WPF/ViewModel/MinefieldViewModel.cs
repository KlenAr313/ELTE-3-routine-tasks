using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Minefield.WPF.ViewModel
{
    public class MinefieldViewModel : ViewModelBase
    {
        private MinefieldGameModel gameModel;

        private double gameTime;

        private bool paused;



        public DelegateCommand NewGameCommand { get; private set; }

        public DelegateCommand LoadGameCommand { get; private set; }

        public DelegateCommand SaveGameCommand { get; private set; }

        public DelegateCommand ExitCommand { get; private set; }



        public ObservableCollection<MineField> MineFields { get; set; }

        public string GameTime { get { return TimeSpan.FromSeconds(gameTime).ToString("g"); } }

        public bool Paused { get; private set; }



        public event EventHandler? NewGame;

        public event EventHandler? LoadGame;

        public event EventHandler? SaveGame;

        public event EventHandler? ExitGame;




        public MinefieldViewModel(MinefieldGameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.End += new EventHandler(Model_End);
            this.gameModel.Refresh += new EventHandler<MinefieldEventArgs>(Model_Refresh);

            NewGameCommand = new DelegateCommand(param => OnNewGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            ExitCommand = new DelegateCommand(param => OnExitGame());

            gameTime = 0;

            MineFields = new ObservableCollection<MineField>();
        }

        private void Model_End(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Model_Refresh(object? sender, MinefieldEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnNewGame()
        {
            throw new NotImplementedException();
        }

        private void OnLoadGame()
        {
            throw new NotImplementedException();
        }

        private void OnSaveGame()
        {
            throw new NotImplementedException();
        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }

    }
}
