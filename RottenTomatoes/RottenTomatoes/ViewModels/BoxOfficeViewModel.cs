using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using RottenTomatoes.JSONSerializer.KnownMovies;
using System.Collections.Generic;

namespace RottenTomatoes
{
    public class BoxOfficeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MovieViewModel> BoxOfficeMovies { get; private set; }
        public ObservableCollection<MovieViewModel> OpeningMovies { get; private set; }
        public ObservableCollection<MovieViewModel> ComingSoonMovies { get; private set; }

        public BoxOfficeViewModel()
        {
            this.BoxOfficeMovies = new ObservableCollection<MovieViewModel>();
            this.OpeningMovies = new ObservableCollection<MovieViewModel>();
            this.ComingSoonMovies = new ObservableCollection<MovieViewModel>();
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        public void LoadBoxOfficeMovies()
        {
            var w = new WebClient();
            Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
            {
                var deserialized = JsonConvert.DeserializeObject<RottenTomatoMovies>(r.EventArgs.Result);
                this.BoxOfficeMovies = GetListOfMovies(deserialized);

            });
            w.DownloadStringAsync(new System.Uri("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?limit=16&country=us&apikey=wuqjxu2v3r9wg492wqb86d84"));
            IsDataLoaded = true;
        }

        public void LoadOpeningMovies()
        {

            IsDataLoaded = true;
        }

        public void LoadComingSoonMovies()
        {

            IsDataLoaded = true;
        }

        public ObservableCollection<MovieViewModel> GetListOfMovies(RottenTomatoMovies rottenTomatoMovies)
        {
            ObservableCollection<MovieViewModel> listView = new ObservableCollection<MovieViewModel>();
            foreach (RottenTomatoes.JSONSerializer.KnownMovies.Movie movie in rottenTomatoMovies.movies)
            {
                MovieViewModel listItem = new MovieViewModel();
                if (movie.ratings.critics_rating == "Certified Fresh")
                {
                    listItem.RatingTomato = "/RottenTomatoes;component/Images/CertifiedFresh.png";
                }
                else
                {
                    listItem.RatingTomato = "/RottenTomatoes;component/Images/Rotten.png";
                }

                listItem.RatingPercentage = movie.ratings.critics_score;
                listItem.MovieName = movie.title;
                listItem.ReleaseDate = movie.release_dates.theater;
                listView.Add(listItem);
            }

            return listView;
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