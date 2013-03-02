using System;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RottenTomatoes
{
    public class BoxOfficeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieViewModel> Movies { get; private set; }

        public BoxOfficeViewModel()
        {
            this.Movies = new ObservableCollection<MovieViewModel>();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }
    }
}