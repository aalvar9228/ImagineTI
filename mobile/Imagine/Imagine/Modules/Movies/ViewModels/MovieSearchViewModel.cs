using Imagine.Api.Impl.Interfaces;
using Imagine.Api.Impl.Models;
using Imagine.Interfaces;
using Imagine.Shared;
using Prism.Commands;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Imagine.Modules.Movies.ViewModels
{
    public class MovieSearchViewModel : ViewModelBase, INavigationAware
    {
        private readonly IMovieService _movieService;

        private ObservableCollection<Movie> _filteredMovies;
        public ObservableCollection<Movie> FilteredMovies
        {
            get => _filteredMovies;
            set => SetProperty(ref _filteredMovies, value);
        }

        public DelegateCommand<string> SearchCommand { get; set; }

        public MovieSearchViewModel(INavigationService navigationService, IMovieService movieService)
            : base(navigationService)
        {
            _movieService = movieService;
            SearchCommand = new DelegateCommand<string>(async (input) => await SearchAsync(input));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                Task.Run(async () => await SearchAsync(null));
            }
        }

        private async Task SearchAsync(string input)
        {
            try
            {
                var response = await _movieService.SearchAsync(input);
                FilteredMovies = new ObservableCollection<Movie>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error at {nameof(SearchAsync)}: {ex}");
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Understood");
            }
        }
    }
}
