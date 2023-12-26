using Minefield.MAUI.Persistence;
using Minefield.MAUI.ViewModel;
using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.MAUI
{
    public partial class App : Application, IDisposable
    {
        private const string SuspendedGameSavePath = "SuspendedGame";

        private readonly AppShell shell;
        private MinefieldGameModel gameModel;
        private readonly IStore store;
        private readonly MinefieldViewModel viewModel;

        public App()
        {
            InitializeComponent();

            store = new MinefieldStore();

            gameModel = new MinefieldGameModel((int)DeviceDisplay.Current.MainDisplayInfo.Width, (int)DeviceDisplay.Current.MainDisplayInfo.Height);
            viewModel = new MinefieldViewModel(gameModel, (int)DeviceDisplay.Current.MainDisplayInfo.Width, (int)DeviceDisplay.Current.MainDisplayInfo.Height);

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
            window.MinimumHeight = 300;

            window.Created += (s, e) =>
            { };

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
                    gameModel.SaveGame(new DataAccess(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)));
                    gameModel.Dispose();
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
