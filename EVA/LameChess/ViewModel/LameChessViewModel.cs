using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LameChess.ViewModel
{
    public class LameChessViewModel : ViewModelBase
    {
        public int RowCount { get; private set; } = 6;
        public int ColumnCount { get; private set; } = 6;

        public ObservableCollection<PlayFieldViewModel> Fields { get; private set; }

        public LameChessViewModel()
        {
            Fields = new ObservableCollection<PlayFieldViewModel>();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    Fields.Add(new PlayFieldViewModel
                    {
                        Row = i,
                        Column = j,
                        Num = 0,
                        StepCommand = new DelegateCommand(param =>
                        {
                            if (param is Tuple<int, int> pos)
                            {
                                StepGame(pos.Item1, pos.Item2);
                            }
                        })
                    });
                }
            }


            RefreshTable();
        }

        private void RefreshTable()
        {
            foreach (var item in Fields)
            {
                if (item.Row == 0 && item.Column == ColumnCount - 1) item.Num = 4;
                else if (item.Row == 0 && item.Column == ColumnCount - 2) item.Num = 3;
                else if (item.Row == 1 && item.Column == ColumnCount - 2) item.Num = 2;
                else if (item.Row == 1 && item.Column == ColumnCount - 1) item.Num = 1;
                else if (item.Row == RowCount - 2 && item.Column == 0) item.Num = 5;
                else if (item.Row == RowCount - 2 && item.Column == 1) item.Num = 6;
                else if (item.Row == RowCount - 1 && item.Column == 1) item.Num = 7;
                else if (item.Row == RowCount - 1 && item.Column == 0) item.Num = 8;
            }
        }

        private void StepGame(int item1, int item2)
        {
            throw new NotImplementedException();
        }
    }
}
