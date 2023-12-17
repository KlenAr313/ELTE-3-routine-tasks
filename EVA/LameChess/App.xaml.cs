using LameChess.ViewModel;
using System.Configuration;
using System.Data;
using System.Windows;

namespace LameChess
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow view = null!;
        private LameChessViewModel viewModel = null!;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            view = new MainWindow();
            viewModel = new LameChessViewModel();
            view.DataContext = viewModel;
            view.Show();
        }
    }

}
