using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mauiZH.Model.Model;

namespace mauiZH.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private GameModel gameModel;
        private int rowCount;
        private int columnCount;

        public int RowCount
        {
            get { return rowCount; }
            set
            {
                if (rowCount != value)
                {
                    rowCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public int ColumnCount
        {
            get { return columnCount; }
            set
            {
                if (columnCount != value)
                {
                    columnCount = value;
                    OnPropertyChanged();
                }
            }
        }

        public ObservableCollection<GridViewModel> Fields { get; private set; }

        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand LoadCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        public event EventHandler? LoadGame;
        public event EventHandler? SaveGame;

        public MainViewModel(GameModel gameModel)
        {
            RowCount = 5;
            ColumnCount = 5;
            this.gameModel = gameModel;
            this.gameModel.FieldChanged += FieldChanged;
            this.gameModel.GameCreated += OnGameCreated;
            Fields = new ObservableCollection<GridViewModel>();
            NewGameCommand = new DelegateCommand(param => NewGame());
            SaveCommand = new DelegateCommand(param => OnSaveGame());
            LoadCommand = new DelegateCommand(param => OnLoadGame());
        }

        private void NewGame()
        {
            gameModel.NewGame(RowCount, ColumnCount);
        }

        private void OnSaveGame()
        {
            SaveGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadGame()
        {
            LoadGame?.Invoke(this, EventArgs.Empty);
        }

        private void OnGameCreated(object? sender, CreatedEventArgs e)
        {
            int[,] table = e.Table;
            RowCount = e.X;
            ColumnCount = e.Y;
            Fields.Clear();
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    Fields.Add(new GridViewModel
                    {
                        Num = table[i,j],
                        Row = i,
                        Column = j,
                        FieldChangeCommand = new DelegateCommand(field =>
                        {
                            if (field is GridViewModel viewModel)
                            {
                                Clicked(viewModel);
                            }
                        })
                    });
                }
            }
        }

        private void Clicked(GridViewModel selectedField)
        {
            gameModel.Step(selectedField.Row, selectedField.Column);
        }

        private void FieldChanged(object? sender, FieldEventArgs e)
        {
            GridViewModel selectedField = Fields.Single(f => f.Row == e.X && f.Column == e.Y);
            selectedField.Num = e.Num;
        }
    }
}
