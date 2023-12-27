using Minefield.MAUI.Persistence;
using Minefield.MAUI.ViewModel;
using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.MAUI
{
    /// <summary>
    /// Class of App
    /// </summary>
    public partial class App : Application, IDisposable
    {
        private const string SuspendedGameSavePath = "SuspendedGame.json";

        private readonly AppShell shell;
        private MinefieldGameModel gameModel;
        private readonly IStore store;
        private readonly MinefieldViewModel viewModel;

        /// <summary>
        /// Constructor of App
        /// </summary>
        public App()
        {
            InitializeComponent();

            store = new MinefieldStore();

            gameModel = new MinefieldGameModel(0, 0);
            viewModel = new MinefieldViewModel(gameModel,0, 0);

            shell = new AppShell(viewModel, gameModel, store)
            {
                BindingContext = viewModel
            };

            MainPage = shell;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);
            window.MinimumHeight = 300;
            window.MinimumWidth = 300;

            window.Created += (s, e) =>
            {
                shell.CreateModel();
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
                        shell.LoadGame(new DataAccess(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)));
                    }
                    catch { }
                });
            };

            window.Deactivated += (s, e) =>
            {
                Task.Run(() =>
                {
                    shell.StopTimer();
                    gameModel.Pause();
                    gameModel.SaveGame(new DataAccess(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)));
                });
            };

            return window;
        }


        /// <summary>
        /// Implementation of Dispose
        /// </summary>
        public void Dispose()
        {
            shell.Dispose();
            gameModel.Dispose();
            viewModel.Dispose();
        }
    }
}
