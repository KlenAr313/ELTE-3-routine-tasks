using mauiZH.Model.Model;
using mauiZH.Model.Persistence;
using mauiZH.ViewModel;

namespace mauiZH
{
    public partial class AppShell : Shell
    {
        private IStore store;
        private IDataAccess dataAccess;
        private GameModel gameModel;
        private MainViewModel mainViewModel;

        public AppShell()
        {
            InitializeComponent();
        }

        public AppShell(IStore store, IDataAccess dataAccess, GameModel gameModel, MainViewModel mainViewModel)
        {
            this.store = store;
            this.dataAccess = dataAccess;
            this.gameModel = gameModel;
            this.mainViewModel = mainViewModel;
        }
    }
}
