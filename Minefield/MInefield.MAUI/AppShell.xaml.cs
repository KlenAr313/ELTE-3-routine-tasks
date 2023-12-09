using Minefield.MAUI.ViewModel;
using Minefield.Model;
using Minefield.Persistence;

namespace Minefield.MAUI
{
    public partial class AppShell : Shell, IDisposable
    {
        private MinefieldGameModel gameModel = null!;
        private MinefieldViewModel viewModel = null!;
        private IDispatcherTimer frameTick = null!;

        public AppShell(MinefieldViewModel viewModel, MinefieldGameModel gameModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            this.gameModel = gameModel;
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
