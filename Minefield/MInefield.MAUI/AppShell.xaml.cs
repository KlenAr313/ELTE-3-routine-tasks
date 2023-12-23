using Minefield.MAUI.ViewModel;
using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.MAUI
{
    public partial class AppShell : Shell, IDisposable
    {
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
            frameTick.Tick += (_, _) => Frame();

            gameModel.End += GameModel_End;

            viewModel.NewGame += ViewModel_NewGame;
            viewModel.LoadGame += ViewModel_LoadGame;
            viewModel.SaveGame += ViewModel_SaveGame;
            viewModel.ExitGame += ViewModel_ExitGame;

            storedBrowserModel = new StoredGameBrowserModel(store);
            storedBrowserViewModel = new StoredGameBorwserViewModel(storedBrowserModel);
            storedBrowserViewModel.GameLoading += BrowserViewModel_GameLoading;
            storedBrowserViewModel.GameSaving += BrowserViewModel_GameSaving;

        }

        private void Frame()
        {
            gameModel.OnFrame();
        }

        internal void StartTimer()
        {
            throw new NotImplementedException();
        }

        internal void StopTimer()
        {
            throw new NotImplementedException();
        }
        


        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GameModel_End(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
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
                gameModel = new MinefieldGameModel((int)DeviceDisplay.Current.MainDisplayInfo.Width, (int)DeviceDisplay.Current.MainDisplayInfo.Height,
                    new DataAccess(Path.Combine(FileSystem.AppDataDirectory, e.Name)));
                viewModel.NewModel(gameModel);
                
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
        /// Implementation of Dispose
        /// </summary>
        public void Dispose()
        {
            gameModel.Dispose();
            viewModel.Dispose();
        }
    }
}
