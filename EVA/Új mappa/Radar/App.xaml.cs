using Radar.Model;
using Radar.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Radar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private RadarModel model = null!;
        private MainWindow view = null!;
        private RadarViewModel viewModel = null!;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            model = new RadarModel(9);
            model.Bombed += Refresh;
            model.End += End;
            view = new MainWindow();
            viewModel = new RadarViewModel(model, 9);
            view.DataContext = viewModel;
            view.Show();
        }

        private void End(object? sender, RadarEventArgs e)
        {
            model = new RadarModel(9);
            model.Bombed += Refresh;
            model.End += End;
            viewModel.Dispose();
            viewModel = new RadarViewModel(model, 9);
            view.DataContext = null;
            view.DataContext = viewModel;
        }

        private void Refresh(object? sender, RadarEventArgs e)
        {
            //
        }
    }
}
