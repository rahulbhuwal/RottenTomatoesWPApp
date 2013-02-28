using Microsoft.Phone.Controls;
using Microsoft.Phone.Reactive;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;

namespace RottenTomatoes.Views
{
    public class MovieListView
    {
        public string RatingTomato { get; set; }
        public int RatingPercentage { get; set; }
        public string MovieName { get; set; }
    }

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
                Observable.FromEvent<DownloadStringCompletedEventArgs>(w, "DownloadStringCompleted").Subscribe(r =>
                {
                    var deserialized = JsonConvert.DeserializeObject<RottenTomatoMovies>(r.EventArgs.Result);
                    MovieList.ItemsSource = GetListOfMovie(deserialized);
                });

                w.DownloadStringAsync(new System.Uri("http://api.rottentomatoes.com/api/public/v1.0/lists/movies/box_office.json?limit=16&country=us&apikey=wuqjxu2v3r9wg492wqb86d84"));
            }
        }

        public List<MovieListView> GetListOfMovie(RottenTomatoMovies rottenTomatoMovies)
        {
            List<MovieListView> listView = new List<MovieListView>();
            foreach (Movie movie in rottenTomatoMovies.movies)
            {
                MovieListView listItem = new MovieListView();
                if (movie.ratings.critics_rating == "Certified Fresh")
                {
                    listItem.RatingTomato = "icons-v2.png";
                }
                //listItem.RatingTomato = movie.ratings.critics_rating;
                listItem.RatingPercentage = movie.ratings.critics_score;
                listItem.MovieName = movie.title;
                listView.Add(listItem);
            }

            return listView;
        }
    }
}