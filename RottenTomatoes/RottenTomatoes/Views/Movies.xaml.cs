using Microsoft.Phone.Controls;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using System;
using RottenTomatoes.JSONSerializer;
using RottenTomatoes.JSONSerializer.KnownMovies;
using RottenTomatoes.JSONSerializer.UpcomingMovies;

namespace RottenTomatoes.Views
{
    public partial class Movies : PhoneApplicationPage
    {
        public Movies()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string option = this.NavigationContext.QueryString["option"];
            var w = new WebClient();

            if (option == "Box Office")
            {
                LoadBoxOfficeMovies();
            }
            else if (option == "Opening Movies")
            {
                LoadOpeningMovies();
            }
            else if(option == "Coming Soon")
            {
                LoadComingSoonMovies();
            }
            
        }

        public void LoadBoxOfficeMovies()
        {
            MoviesPivot.SelectedIndex = 0;
            var w = new WebClient();
            Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
            {
                var deserialized = JsonConvert.DeserializeObject<RottenTomatoMovies>(r.EventArgs.Result);
                MovieList.ItemsSource = GetListOfMovies(deserialized);
                
            });
            w.DownloadStringAsync(new System.Uri("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?limit=16&country=us&apikey=wuqjxu2v3r9wg492wqb86d84"));
        }

        public void LoadOpeningMovies()
        {
            MoviesPivot.SelectedIndex = 1;
            var w = new WebClient();
            Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
            {
                var deserialized = JsonConvert.DeserializeObject<RottenTomatoMovies>(r.EventArgs.Result);
                UpcomingMovieList.ItemsSource = GetListOfMovies(deserialized);
                
            });
            w.DownloadStringAsync(new System.Uri("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/opening.json?limit=16&country=us&apikey=wuqjxu2v3r9wg492wqb86d84"));
        }

        public void LoadComingSoonMovies()
        {
            MoviesPivot.SelectedIndex = 2;
            var w = new WebClient();
            Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
            {
                var deserialized = JsonConvert.DeserializeObject<ComingSoonMovies>(r.EventArgs.Result);
                ComingSoonMovieList.ItemsSource = GetListOfMovies(deserialized);
                
            });
            w.DownloadStringAsync(new System.Uri("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/upcoming.json?page_limit=16&page=1&country=us&apikey=wuqjxu2v3r9wg492wqb86d84"));
        }

        public List<MovieListView> GetListOfMovies(RottenTomatoMovies rottenTomatoMovies)
        {
            List<MovieListView> listView = new List<MovieListView>();
            foreach (RottenTomatoes.JSONSerializer.KnownMovies.Movie movie in rottenTomatoMovies.movies)
            {
                MovieListView listItem = new MovieListView();
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

        public List<MovieListView> GetListOfMovies(ComingSoonMovies rottenTomatoMovies)
        {
            List<MovieListView> listView = new List<MovieListView>();
            foreach (RottenTomatoes.JSONSerializer.UpcomingMovies.Movie movie in rottenTomatoMovies.movies)
            {
                MovieListView listItem = new MovieListView();
                if (movie.ratings.critics_rating != null)
                {
                    if (movie.ratings.critics_rating == "Certified Fresh" || movie.ratings.critics_rating == "Fresh")
                    {
                        listItem.RatingTomato = "/RottenTomatoes;component/Images/CertifiedFresh.png";
                    }
                    else
                    {
                        listItem.RatingTomato = "/RottenTomatoes;component/Images/Rotten.png";
                    }
                }
                else
                {
                    listItem.RatingTomato = "/RottenTomatoes;component/Images/UnkonownRating.png";
                }

                listItem.RatingPercentage = movie.ratings.critics_score;
                listItem.MovieName = movie.title;
                listItem.ReleaseDate = movie.release_dates.theater;
                listView.Add(listItem);
            }

            return listView;
        }

        private void MoviesPivot_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (MoviesPivot.SelectedIndex == 0)
            {
                LoadBoxOfficeMovies();
            }
            else if (MoviesPivot.SelectedIndex == 1)
            {
                LoadOpeningMovies();
            }
            else if (MoviesPivot.SelectedIndex == 2)
            {
                LoadComingSoonMovies();
            }
        }

        private void MovieList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

    }

    public class MovieListView
    {
        public string RatingTomato { get; set; }
        public int RatingPercentage { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
    }

}