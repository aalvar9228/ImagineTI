using Imagine.Api.Impl.Interfaces;
using Prism.Navigation;
using System.Threading.Tasks;

namespace Imagine.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigationAware
    {
        private readonly IMovieApi _movieApi;

        public MainPageViewModel(INavigationService navigationService, IMovieApi movieApi)
            : base(navigationService)
        {
            Title = "Main Page";
            _movieApi = movieApi;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if(parameters.GetNavigationMode() == NavigationMode.New)
            {
                Task.Run(SearchAsync);
            }
        }

        private async Task SearchAsync()
        {
            var response = await _movieApi.SearchAsync();
            Title = $"Results: {response.Count}";
        }
    }
}
