using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.ComponentModel;

namespace RottenTomatoes
{
    public class MovieViewModel : INotifyPropertyChanged
    {
        public string RatingTomato
        {
            get;
            set
            {
                if (value != this.RatingTomato)
                {
                    this.RatingTomato = value;
                    NotifyPropertyChanged("RatingTomato");
                }
            }
        }

        public int RatingPercentage
        {
            get;
            set
            {
                if (value != this.RatingPercentage)
                {
                    this.RatingPercentage = value;
                    NotifyPropertyChanged("RatingPercentage");
                }
            }
        }

        public string MovieName
        {
            get;
            set
            {
                if (value != this.MovieName)
                {
                    this.MovieName = value;
                    NotifyPropertyChanged("MovieName");
                }
            }
        }

        public string ReleaseDate
        {
            get;
            set
            {
                if (value != this.ReleaseDate)
                {
                    this.ReleaseDate = value;
                    NotifyPropertyChanged("ReleaseDate");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
