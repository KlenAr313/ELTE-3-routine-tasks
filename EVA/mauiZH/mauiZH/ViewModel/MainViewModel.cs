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

        public RowDefinitionCollection RowCount
        {
            get 
            { 
                return new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), rowCount).ToArray());  
            }
        }

        public ColumnDefinitionCollection ColumnCount
        {
            get 
            { 
                return new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), columnCount).ToArray());
            }
        }

        public int RowCountSet
        {
            get { return rowCount; }
            set 
            { 
                if(rowCount != value)
                {
                    rowCount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(RowCount));
                }
            }
        }

        public int ColumnCountSet
        {
            get { return columnCount; }
            set
            {
                if(columnCount != value)
                {
                    columnCount = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(ColumnCount));
                }
            }
        }

        public ObservableCollection<GridViewModel> Fields { get; private set; }

        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand SettingsCommand { get; private set; }
        public DelegateCommand LoadCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }

        public event EventHandler? Settings;
        public event EventHandler? LoadGame;
        public event EventHandler? SaveGame;

        public MainViewModel(GameModel gameModel)
        {
            rowCount = 5;
            columnCount = 5;
            this.gameModel = gameModel;
            this.gameModel.FieldChanged += FieldChanged;
            this.gameModel.GameCreated += OnGameCreated;
            Fields = new ObservableCollection<GridViewModel>();
            NewGameCommand = new DelegateCommand(param => NewGame());
            SaveCommand = new DelegateCommand(param => OnSaveGame());
            LoadCommand = new DelegateCommand(param => OnLoadGame());
            SettingsCommand = new DelegateCommand(param => OnSettings());
        }

        private void NewGame()
        {
            gameModel.NewGame(rowCount, columnCount);
        }

        private void OnSettings()
        {
            Settings?.Invoke(this, EventArgs.Empty);
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
            rowCount = e.X;
            columnCount = e.Y;
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
                        FieldChangeCommand = new DelegateCommand(param =>
                        {
                            if (param is Tuple<int, int> coords)
                            {
                                Clicked(coords.Item1, coords.Item2);
                            }
                        })
                    });
                }
            }
        }

        private void Clicked(int Row, int Column)
        {
            gameModel.Step(Row, Column);
        }

        private void FieldChanged(object? sender, FieldEventArgs e)
        {
            GridViewModel selectedField = Fields.Single(f => f.Row == e.X && f.Column == e.Y);
            selectedField.Num = e.Num;
        }
    }
}
