using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace RottenTomatoes
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadMovies();
                App.ViewModel.LoadDVD();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MoviesLanding.SelectedIndex != -1)
            {
                LandingPageViewModel movieModel = (LandingPageViewModel)MoviesLanding.SelectedItem;

                this.NavigationService.Navigate(new Uri("//Views/Movies.xaml?option=" + movieModel.LineOne, UriKind.Relative));
            }
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            MoviesLanding.SelectedIndex = -1;
            MoviesLanding.SelectedItem = null;
        }

        private void DVDLanding_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}