﻿using Microsoft.Win32;
using Minefield.Model;
using Minefield.Persistence;
using Minefield.WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Minefield.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, IDisposable
    {
        private MinefieldGameModel gameModel = null!;
        private MinefieldViewModel viewModel = null!;
        private MainWindow mainWindow = null!;
        private DispatcherTimer frameTick = null!;

        /// <summary>
        /// Constructor of the app
        /// </summary>
        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            mainWindow = new MainWindow();
            mainWindow.Closing += new System.ComponentModel.CancelEventHandler(View_Closing);

            gameModel = new MinefieldGameModel((int)mainWindow.Width,(int)mainWindow.Height);

            viewModel = new MinefieldViewModel(gameModel);
            viewModel.NewGame += new EventHandler(ViewModel_NewGame);
            viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);
            viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);
            viewModel.PauseGame += new EventHandler(ViewModel_PauseGame);
            viewModel.RestrumeGame += new EventHandler(ViewModel_RestrumeGame);

            mainWindow.DataContext = viewModel;
            mainWindow.KeyDown += viewModel.KeyDown;
            mainWindow.KeyUp += viewModel.KeyUp;
            mainWindow.Show();

            frameTick = new DispatcherTimer();
            frameTick.Interval = TimeSpan.FromMilliseconds(10);
            frameTick.Tick += Frame;
        }

        private void Frame(object? sender, EventArgs e)
        {
            gameModel.OnFrame();
        }

        private void View_Closing(object? sender, CancelEventArgs e)
        {
            bool rest = frameTick.IsEnabled;
            gameModel.Pause();
            frameTick.Stop();

            if (MessageBox.Show("Are you sure you want to exit?", "Minefield",  MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
            {
                e.Cancel = true;
                if(rest)
                {
                    gameModel.Restrume();
                    frameTick.Start();
                }
            }
        }

        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            mainWindow.Close();
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            gameModel.Dispose();
            gameModel = new MinefieldGameModel((int)mainWindow.Width, (int)mainWindow.Height);
            gameModel.End += new EventHandler(Model_GameOver);

            viewModel.NewModel(gameModel);

            frameTick.Start();
            gameModel.StartGame();
        }

        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load Minefield Game";
            openFileDialog.Filter = "JSON |*.json";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    DataAccess dataAcces = new(openFileDialog.FileName);
                    gameModel = new MinefieldGameModel((int)mainWindow.Width, (int)mainWindow.Height, dataAcces);
                    gameModel.End += new EventHandler(Model_GameOver);

                    viewModel.NewModel(gameModel);

                    MessageBox.Show("let's continue!", "Loaded", MessageBoxButton.OK, MessageBoxImage.Information);


                    frameTick.Start();
                    gameModel.StartGame();
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to load game!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Minefield Game";
            saveFileDialog.Filter = "JSON |*.json";
            if (saveFileDialog.ShowDialog() == true)
            {
                try 
                { 
                    DataAccess dataAcces = new(saveFileDialog.FileName);
                    gameModel.SaveGame(dataAcces); 
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to save game!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void ViewModel_PauseGame(object? sender, EventArgs e)
        {
            frameTick.Stop();
        }

        private void ViewModel_RestrumeGame(object? sender, EventArgs e)
        {
            frameTick.Start();
        }


        private void Model_GameOver(object? sender, EventArgs e)
        {
            frameTick.Stop();
            MessageBox.Show($"You have lost the game.\nYour Time: {viewModel.GameTime}",
                "Game Over", MessageBoxButton.OK, MessageBoxImage.Information );
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
