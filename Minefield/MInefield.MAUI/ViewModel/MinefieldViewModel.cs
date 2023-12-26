using Minefield.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
using System.Windows.Input;

namespace Minefield.MAUI.ViewModel
{
    /// <summary>
    /// Class of MinefieldViewModel
    /// </summary>
    public class MinefieldViewModel : ViewModelBase, IDisposable
    {
        private MinefieldGameModel gameModel;

        private bool paused;

        private bool isGameOver;

        /// <summary>
        /// New game command query to start game
        /// </summary>
        public DelegateCommand NewGameCommand { get; private set; }

        /// <summary>
        /// Load game command query to start saved game
        /// </summary>
        public DelegateCommand LoadGameCommand { get; private set; }

        /// <summary>
        /// Save game command query to save current game
        /// </summary>
        public DelegateCommand SaveGameCommand { get; private set; }

        /// <summary>
        /// Exit command query to exit from game
        /// </summary>
        public DelegateCommand PauseCommand { get; private set; }

        public DelegateCommand MoveCommand { get; private set; }

        /// <summary>
        /// Collection of mines query
        /// </summary>
        public ObservableCollection<Mine> Mines { get; set; }

        /// <summary>
        /// Collection of submarine query
        /// </summary>
        public SubmarineViewModel SubmarineVM { get; set; }

        /// <summary>
        /// Game time query
        /// </summary>
        public string GameTime { get { return TimeSpan.FromSeconds(gameModel.GameTime).ToString("g"); } }

        /// <summary>
        /// Paused status query
        /// </summary>
        public bool Paused { get { return paused; } set { paused = value; } }


        /// <summary>
        /// New game event
        /// </summary>
        public event EventHandler? NewGame;

        /// <summary>
        /// Load game event
        /// </summary>
        public event EventHandler? LoadGame;

        /// <summary>
        /// Save game event
        /// </summary>
        public event EventHandler? SaveGame;

        /// <summary>
        /// Pause game event
        /// </summary>
        public event EventHandler? PauseGame;

        /// <summary>
        /// Restrume game event
        /// </summary>
        public event EventHandler? RestrumeGame;


        /// <summary>
        /// Constructor of Minefield ViewModel
        /// </summary>
        /// <param name="gameModel">Class of game model</param>
        public MinefieldViewModel(MinefieldGameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.End += new EventHandler(Model_End);
            this.gameModel.Refresh += new EventHandler<MinefieldEventArgs>(Model_Refresh);
            this.gameModel.OneSecTick.Elapsed += Model_GameTime;

            NewGameCommand = new DelegateCommand(param => OnNewGame());
            LoadGameCommand = new DelegateCommand(param => OnLoadGame());
            SaveGameCommand = new DelegateCommand(param => OnSaveGame());
            PauseCommand = new DelegateCommand(param => OnPauseGame());
            MoveCommand = new DelegateCommand(param =>
            {
                if (param is string direction)
                    Movement(direction);
            });

            Mines = new ObservableCollection<Mine>();
            SubmarineVM = new SubmarineViewModel();

            paused = true;
            isGameOver = false;

        }

        /// <summary>
        /// Recieving new model in case of new and loaded game
        /// </summary>
        /// <param name="gameModel">Class of game model</param>
        public void NewModel(MinefieldGameModel gameModel)
        {
            this.gameModel = gameModel;
            this.gameModel.End += new EventHandler(Model_End);
            this.gameModel.Refresh += new EventHandler<MinefieldEventArgs>(Model_Refresh);
            this.gameModel.OneSecTick.Elapsed += Model_GameTime;


            Mines = new ObservableCollection<Mine>();
            SubmarineVM = new SubmarineViewModel();

            gameModel.OnFrame();

            OnPropertyChanged(nameof(SubmarineVM));
            OnPropertyChanged(nameof(Mines));
            OnPropertyChanged(nameof(GameTime));
            OnPropertyChanged(nameof(Paused));
        }

        private void Movement(string direction)
        {
            switch (direction)
            {
                case "Up":
                    Directions.Up = true;
                    Directions.Down = false;
                    break;
                case "Down":
                    Directions.Down = true;
                    Directions.Up = false;
                    break;
                case "Right":
                    Directions.Right = true;
                    Directions.Left = false;
                    break;
                case "Left":
                    Directions.Left = true;
                    Directions.Right = false;
                    break;
                case "Stop":
                    Directions.Reset();
                    break;
                default: break;
            }
        }

        /// <summary>
        /// Event hendler to receive keyboard input start
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEvent argument</param>
        /*public void KeyDown(object sender, KeyEventArgs e)
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

        /// <summary>
        /// Event hendler to receive keyboard input end
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">KeyEvent argument</param>
        public void KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up: Directions.Up = false; break;
                case Key.Down: Directions.Down = false; break;
                case Key.Left: Directions.Left = false; break;
                case Key.Right: Directions.Right = false; break;
            }
        }*/

        private void Model_End(object? sender, EventArgs e)
        {
            isGameOver = true;
        }

        private void Model_Refresh(object? sender, MinefieldEventArgs e)
        {
            Mines = new ObservableCollection<Mine>();

            foreach (Mine item in e.Mines)
            {
                Mines.Add(new Mine { X= item.X, Y = item.Y});
            }

            SubmarineVM.X = e.Submarine.X;
            SubmarineVM.Y = e.Submarine.Y;

            OnPropertyChanged(nameof(SubmarineVM));
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
        }

        private void OnPauseGame()
        {
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
        }

        /// <summary>
        /// Implementation of Dispose
        /// </summary>
        public void Dispose()
        {
            gameModel.Dispose();
        }
    }
}
