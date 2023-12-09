using Minefield.MAUI.ViewModel;
using Minefield.Model;

namespace Minefield.MAUI
{
    public partial class App : Application, IDisposable
    {
        private MinefieldGameModel gameModel = null!;
        private MinefieldViewModel viewModel = null!;
        private IDispatcherTimer frameTick = null!;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell(viewModel, gameModel);
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
