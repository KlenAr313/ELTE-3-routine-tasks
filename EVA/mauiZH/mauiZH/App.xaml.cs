using mauiZH.Model.Model;
using mauiZH.Model.Persistence;
using mauiZH.ViewModel;

namespace mauiZH
{
    public partial class App : Application
    {
        private const string SuspendedGameSavePath = "SuspendedGame";

        private readonly AppShell appShell;
        private readonly IDataAccess dataAccess;
        private readonly GameModel gameModel;
        private readonly IStore store;
        private readonly MainViewModel mainViewModel;

        public App()
        {
            InitializeComponent();

            store = new Store();
            dataAccess = new DataAccess(FileSystem.AppDataDirectory);

            gameModel = new GameModel(2, 2, dataAccess);
            mainViewModel = new MainViewModel(gameModel);

            appShell = new AppShell(store, dataAccess, gameModel, mainViewModel)
            {
                BindingContext = mainViewModel
            };

            MainPage = appShell;
        }

        protected override Window CreateWindow(IActivationState activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) =>
            {
                gameModel.NewGame(4, 4);
            };

            window.Activated += (s, e) =>
            {
                if (!File.Exists(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)))
                {
                    return;
                }

                Task.Run(() =>
                {
                    try
                    {
                        gameModel.LoadGame(SuspendedGameSavePath);
                    }
                    catch { }
                });
            };

            window.Deactivated += (s, e) =>
            {
                Task.Run(() =>
                {
                    try
                    {
                        gameModel.SaveGame(SuspendedGameSavePath);
                    }
                    catch { }
                });
            };

            return window;
        }
    }
}
