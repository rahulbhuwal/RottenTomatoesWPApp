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
        public string ratingTomato;
        public string RatingTomato
        {
            get
            {
                return ratingTomato;
            }
            set
            {
                if (value != ratingTomato)
                {
                    ratingTomato = value;
                    NotifyPropertyChanged("RatingTomato");
                }
            }
        }

        public int ratingPercentage;
        public int RatingPercentage
        {
            get
            {
                return ratingPercentage;
            }
            set
            {
                if (value != ratingPercentage)
                {
                    ratingPercentage = value;
                    NotifyPropertyChanged("RatingPercentage");
                }
            }
        }

        public string movieName;
        public string MovieName
        {
            get
            {
                return movieName;
            }
            set
            {
                if (value != movieName)
                {
                    movieName = value;
                    NotifyPropertyChanged("MovieName");
                }
            }
        }

        public string releaseDate;
        public string ReleaseDate
        {
            get
            {
                return releaseDate;
            }
            set
            {
                if (value != releaseDate)
                {
                    releaseDate = value;
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
