using mauiZH.Model;
using mauiZH.Model.Model;
using mauiZH.Model.Persistence;
using mauiZH.View;
using mauiZH.ViewModel;

namespace mauiZH
{
    public partial class AppShell : Shell
    {
        private IDataAccess dataAccess;
        private readonly IStore store;
        private readonly GameModel gameModel;
        private readonly MainViewModel mainViewModel;

        private readonly StoredGameBrowserModel storedGameBrowserModel;
        private readonly StoredGameBrowserViewModel storedGameBrowserViewModel;

        public AppShell(IStore store, IDataAccess dataAccess, GameModel gameModel, MainViewModel mainViewModel)
        {
            InitializeComponent();

            this.store = store;
            this.dataAccess = dataAccess;
            this.gameModel = gameModel;
            this.mainViewModel = mainViewModel;

            mainViewModel.Settings += MainViewModel_Settings;
            mainViewModel.LoadGame += MainViewModel_LoadGame;
            mainViewModel.SaveGame += MainViewModel_SaveGame;

            storedGameBrowserModel = new StoredGameBrowserModel(store);
            storedGameBrowserViewModel = new StoredGameBrowserViewModel(storedGameBrowserModel);
            storedGameBrowserViewModel.GameLoading += StoredGameBrowserViewModel_GameLoading;
            storedGameBrowserViewModel.GameSaving += StoredGameBrowserViewModel_GameSaving;
        }

        private async void MainViewModel_Settings(object sender, EventArgs e)
        {
            SettingsPage settings = new SettingsPage();
            settings.BindingContext = mainViewModel;
            await Navigation.PushAsync(settings);
        }

        private async void MainViewModel_LoadGame(object sender, EventArgs e)
        {
            await storedGameBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new LoadGamePage
            {
                BindingContext = storedGameBrowserViewModel
            });
        }
        
        private async void MainViewModel_SaveGame(object sender, EventArgs e)
        {
            await storedGameBrowserModel.UpdateAsync();
            await Navigation.PushAsync(new SaveGamePage
            {
                BindingContext = storedGameBrowserViewModel
            });
        }

        private async void StoredGameBrowserViewModel_GameLoading(object sender, StoredGameEventArgs e)
        {
            await Navigation.PopAsync();

            try
            {
                gameModel.LoadGame(e.Name);

                await Navigation.PopAsync();
                await DisplayAlert("Game", "Success", "Ok");
            }
            catch
            {
                await DisplayAlert("Game", "Error", "Ok");
            }
        }

        private async void StoredGameBrowserViewModel_GameSaving(object sender, StoredGameEventArgs e)
        {
            await Navigation.PopAsync();

            try
            {
                gameModel.SaveGame(e.Name);
                await DisplayAlert("Game", "Success", "Ok");
            }
            catch
            {
                await DisplayAlert("Game", "Error", "Ok");
            }
        }
    }
}
