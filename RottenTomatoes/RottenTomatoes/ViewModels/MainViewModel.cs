using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RottenTomatoes
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Movies = new ObservableCollection<LandingPageViewModel>();
            this.DVD = new ObservableCollection<LandingPageViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<LandingPageViewModel> Movies { get; private set; }

        public ObservableCollection<LandingPageViewModel> DVD { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";

        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadMovies()
        {
            // Sample data; replace with real data
            this.Movies.Add(new LandingPageViewModel() { LineOne = "Box Office", LineTwo = "Box Office Movies" });
            //this.Movies.Add(new LandingPageViewModel() { LineOne = "In Theatres", LineTwo = "Movies currently in theatres" });
            this.Movies.Add(new LandingPageViewModel() { LineOne = "Opening Movies", LineTwo = "Current opening movies" });
            this.Movies.Add(new LandingPageViewModel() { LineOne = "Coming Soon", LineTwo = "Upcoming movies" });

            this.IsDataLoaded = true;
        }

        public void LoadDVD()
        {
            this.DVD.Add(new LandingPageViewModel() { LineOne = "Top Rentals", LineTwo = "Current top dvd rentals" });
            this.DVD.Add(new LandingPageViewModel() { LineOne = "Release DVDs", LineTwo = "Current release DVDs" });
            this.DVD.Add(new LandingPageViewModel() { LineOne = "New Release", LineTwo = "New release DVDs" });
            this.DVD.Add(new LandingPageViewModel() { LineOne = "Upcoming DVDs", LineTwo = "Upcoming release DVDs" });
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