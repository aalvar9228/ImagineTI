using Imagine.Api.Impl.Models;
using Imagine.Constants;
using Imagine.Shared;
using Prism.Navigation;

namespace Imagine.Modules.Movies.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase, INavigationAware
    {
        private Movie _movie;
        public Movie Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }

        public MovieDetailViewModel(INavigationService navigationService)
            : base(navigationService)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                Movie = parameters.GetValue<Movie>(NavigationParameterKeys.Movie);
            }
        }
    }
}
