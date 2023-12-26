using Microsoft.Maui.Controls;
using Minefield.MAUI.View;
using Minefield.MAUI.ViewModel;
using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.MAUI
{
    public partial class AppShell : Shell, IDisposable
    {
        private int maxX;
        private int maxY;
        private MinefieldGameModel gameModel = null!;
        private MinefieldViewModel viewModel = null!;

        private IDispatcherTimer frameTick = null!;

        private readonly IStore store = null!;
        private readonly StoredGameBrowserModel storedBrowserModel = null!;
        private readonly StoredGameBorwserViewModel storedBrowserViewModel = null!;

        public AppShell(MinefieldViewModel viewModel, MinefieldGameModel gameModel, IStore store)
        {
            InitializeComponent();
            this.store = store;
            this.gameModel = gameModel;
            this.viewModel = viewModel;

            frameTick = Dispatcher.CreateTimer();
            frameTick.Interval = TimeSpan.FromMilliseconds(20);
            frameTick.Tick += (_, _) => MoveFrame();

            gameModel.End += GameModel_End;

            viewModel.NewGame += ViewModel_NewGame;
            viewModel.LoadGame += ViewModel_LoadGame;
            viewModel.SaveGame += ViewModel_SaveGame;
            viewModel.PauseGame += ViewModel_PauseGame;
            viewModel.RestrumeGame += ViewModel_RestrumeGame;

            storedBrowserModel = new StoredGameBrowserModel(store);
            storedBrowserViewModel = new StoredGameBorwserViewModel(storedBrowserModel);
            storedBrowserViewModel.GameLoading += BrowserViewModel_GameLoading;
            storedBrowserViewModel.GameSaving += BrowserViewModel_GameSaving;

        }

        private void MoveFrame()
        {
            gameModel.OnFrame();
        }

        internal void StartTimer()
        {
            frameTick.Start();
        }

        internal void StopTimer()
        {
            frameTick.Stop();
        }
        


        private async void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            await storedBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new SaveGamePage
            {
                BindingContext = storedBrowserViewModel
            });
        }

        private async void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            await storedBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new LoadGamePage
            {
                BindingContext = storedBrowserViewModel
            });
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            gameModel.Dispose();
            gameModel = new MinefieldGameModel((int)Window.Width, (int)Window.Height);
            gameModel.End += GameModel_End;

            viewModel.NewModel(gameModel, (int)Window.Width, (int)Window.Height);

            StartTimer();
            gameModel.StartGame();
        }

        private void ViewModel_PauseGame(object? sender, EventArgs e)
        {
            frameTick.Stop();
            gameModel.Pause();
        }

        private void ViewModel_RestrumeGame(object? sender, EventArgs e)
        {
            frameTick.Start();
            gameModel.Restrume();
        }


        private void GameModel_End(object? sender, EventArgs e)
        {
            StopTimer();

            DisplayAlert("Game Over", $"You have lost the game.\nYour Time: {viewModel.GameTime}", "OK");
        }



        private void BrowserViewModel_GameSaving(object? sender, StoredGameEventArgs e)
        {
            Navigation.PopAsync();
            StopTimer();

            try
            {
                gameModel.SaveGame(new DataAccess(Path.Combine(FileSystem.AppDataDirectory, e.Name)));
                DisplayAlert("Mindefield", "Successful save", "Ok");
            }
            catch
            {

                DisplayAlert("Mindefield", "Unsuccessful save", "Ok");
            }
        }

        private void BrowserViewModel_GameLoading(object? sender, StoredGameEventArgs e)
        {
            Navigation.PopAsync();

            try
            {
                gameModel.Dispose();
                gameModel = new MinefieldGameModel((int)Window.Width, (int)Window.Height,
                    new DataAccess(Path.Combine(FileSystem.AppDataDirectory, e.Name)));
                viewModel.NewModel(gameModel, (int)Window.Width, (int)Window.Height);
                
                Navigation.PopAsync();
                DisplayAlert("Mindefield", "Successful loading", "Ok");

                gameModel.StartGame();
                StartTimer();
            }
            catch
            {
                DisplayAlert("Mindefield", "Unsuccessful loading", "Ok");
            }
        }

        /// <summary>
        /// Load new game with specific data access
        /// </summary>
        /// <param name="dataAccess">Instance of the scpecific data acces</param>
        public void LoadGame(DataAccess dataAccess)
        {
            gameModel.Dispose();
            gameModel = new MinefieldGameModel((int)Window.Width, (int)Window.Height, dataAccess);
            gameModel.End += GameModel_End;

            viewModel.NewModel(gameModel, (int)Window.Width, (int)Window.Height);

            gameModel.StartGame();
            StartTimer();
        }


        /// <summary>
        /// Implementation of Dispose
        /// </summary>
        public void Dispose()
        {
            gameModel.Dispose();
            viewModel.Dispose();
        }
    }
}
