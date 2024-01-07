using Microsoft.Win32;
using System.Configuration;
using System.Data;
using System.Windows;
using wpfZH.Model.Model;
using wpfZH.Model.Persistence;
using wpfZH.ViewModel;

namespace wpfZH
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow view = null!;
        private MainViewModel viewModel = null!;
        private GameModel model = null!;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            model = new GameModel(0,0, new DataAccess());

            viewModel = new MainViewModel(model);
            viewModel.LoadGame += ViewModel_LoadGame;
            viewModel.SaveGame += ViewModel_SaveGame;


            view = new MainWindow();
            view.DataContext = viewModel;

            view.Show();
        }

        private void ViewModel_LoadGame(object? sender, System.EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Load game";
                openFileDialog.Filter = "Game (.json)|*.json";
                if (openFileDialog.ShowDialog() == true)
                {
                    model.LoadGame(openFileDialog.FileName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private  void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Save game";
                saveFileDialog.Filter = "Game (.json)|*.json";
                if (saveFileDialog.ShowDialog() == true)
                {
                    try
                    {
                        model.SaveGame(saveFileDialog.FileName);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Failed to save game!" + Environment.NewLine + "The path is incorrect or the directory is not writable.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Failed to save file!", "Game", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

}
