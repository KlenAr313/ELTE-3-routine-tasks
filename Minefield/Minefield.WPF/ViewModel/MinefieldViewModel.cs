using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minefield.WPF.ViewModel
{
    public class MinefieldViewModel : ViewModelBase
    {
        private MinefieldGameModel gameModel;

        private bool paused;

        private bool isGameOver;


        public DelegateCommand NewGameCommand { get; private set; }

        public DelegateCommand LoadGameCommand { get; private set; }

        public DelegateCommand SaveGameCommand { get; private set; }

        public DelegateCommand ExitCommand { get; private set; }


        public ObservableCollection<Mine> Mines { get; set; }

        public string GameTime { get { return TimeSpan.FromSeconds(gameModel.GameTime).ToString("g"); } }

        public bool Paused { get { return paused; } }



        public event EventHandler? NewGame;

        public event EventHandler? LoadGame;

        public event EventHandler? SaveGame;

        public event EventHandler? ExitGame;

        public event EventHandler? PauseGame;

        public event EventHandler? RestrumeGame;



        public MinefieldViewModel(MinefieldGameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.End += new EventHandler(Model_End);
            this.gameModel.Refresh += new EventHandler<MinefieldEventArgs>(Model_Refresh);
            this.gameModel.OneSecTick.Elapsed += Model_GameTime;

            NewGameCommand = new DelegateCommand(param => OnNewGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            ExitCommand = new DelegateCommand(param => OnExitGame());

            Mines = new ObservableCollection<Mine>();
            //Mines.Add(new Mine { X = 50, Y = 50 });

            paused = true;
            isGameOver = false;

        }

        public void NewModel(MinefieldGameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.End += new EventHandler(Model_End);
            this.gameModel.Refresh += new EventHandler<MinefieldEventArgs>(Model_Refresh);
            this.gameModel.OneSecTick.Elapsed += Model_GameTime;


            Mines = new ObservableCollection<Mine>();

            OnPropertyChanged(nameof(Mines));
            OnPropertyChanged(nameof(GameTime));
            OnPropertyChanged(nameof(Paused));
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Directions.Up = true; break;
                case Key.Down: Directions.Down = true; break;
                case Key.Left: Directions.Left = true; break;
                case Key.Right: Directions.Right = true; break;
                case Key.Escape:
                    if (!paused && !isGameOver)
                    {
                        gameModel.Pause();
                        paused = true;
                        PauseGame?.Invoke(this, EventArgs.Empty);
                    }
                    else if (paused && !isGameOver)
                    {
                        gameModel.Restrume();
                        paused = false;
                        RestrumeGame?.Invoke(this, EventArgs.Empty);
                    }
                    break;
            }

            OnPropertyChanged(nameof(Paused));
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Directions.Up = false; break;
                case Key.Down: Directions.Down = false; break;
                case Key.Left: Directions.Left = false; break;
                case Key.Right: Directions.Right = false; break;
            }
        }

        private void Model_End(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Model_Refresh(object? sender, MinefieldEventArgs e)
        {
            Mines = new ObservableCollection<Mine>();

            Mines.Add(new Mine { X = 500, Y = 50 });
            foreach (Mine item in e.Mines)
            {
                Mines.Add(new Mine { X= item.X, Y = item.Y});
            }

            OnPropertyChanged(nameof(Mines));
        }

        private void Model_GameTime(object? sender, EventArgs e)
        {
            OnPropertyChanged(nameof(GameTime));
        }

        private void OnNewGame()
        {
            NewGame?.Invoke(this, EventArgs.Empty);
            paused = false;
            isGameOver = false;
            OnPropertyChanged(nameof(Paused));
        }

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
            paused = false;
            isGameOver = false;
            OnPropertyChanged(nameof(Paused));
        }

        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
            //
        }

        private void OnExitGame()
        {
            ExitGame?.Invoke(this, EventArgs.Empty);
        }

    }
}
