﻿using Minefield.MAUI.Persistence;
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
            viewModel = new MinefieldViewModel(gameModel);

            shell = new AppShell(viewModel, gameModel, store)
            {
                BindingContext = viewModel
            };

            MainPage = shell;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Window window = base.CreateWindow(activationState);

            window.Created += (s, e) =>
            {
                gameModel.StartGame();
                shell.StartTimer();
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
                        gameModel = new MinefieldGameModel((int)DeviceDisplay.Current.MainDisplayInfo.Width, (int)DeviceDisplay.Current.MainDisplayInfo.Height, new DataAccess(Path.Combine(FileSystem.AppDataDirectory, SuspendedGameSavePath)));

                        viewModel.NewModel(gameModel);

                        gameModel.StartGame();
                        shell.StartTimer();
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
