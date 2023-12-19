using Radar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar.ViewModel
{
    public class RadarViewModel : ViewModelBase, IDisposable
    {
        private RadarModel model;
        public int RowCount { get; private set; } = 3;
        public int ColumnCount { get; private set; } = 3;

        public ObservableCollection<PlayFieldViewModel> Fields { get; private set; }

        public RadarViewModel(RadarModel model, int n)
        {
            RowCount = n;
            ColumnCount = n;
            this.model = model;
            model.Bombed += Refres;
            Fields = new ObservableCollection<PlayFieldViewModel>();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    string b = string.Empty;
                    if (model.Target[i, j])
                    {
                        b = "B";
                    }
                    Fields.Add(new PlayFieldViewModel
                    {
                        Row = i,
                        Column = j,
                        Is = b,
                        StepCommand = new DelegateCommand(param =>
                        {
                            if (param is Tuple<int, int> pos)
                            {
                                Clicked(pos.Item1, pos.Item2);
                            }
                        })
                    });
                }
            }

        }

        private void Refres(object? sender, RadarEventArgs e)
        {
            foreach (PlayFieldViewModel field in Fields)
            {
                if (!e.Target[field.Row, field.Column])
                {
                    field.Is = string.Empty;
                }
            }
        }

        private void Clicked(int i, int j)
        {
            model.Bombing(i,j);
        }

        public void Dispose()
        {
            Fields.Clear();

        }
    }
}
