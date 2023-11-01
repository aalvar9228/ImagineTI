using Imagine.Api.Impl.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Imagine.Modules.Movies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieCard : ContentView
    {
        public MovieCard()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MovieProperty =
            BindableProperty.Create(nameof(Movie), typeof(Movie), typeof(MovieCard), propertyChanged: OnMovieChanged);

        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }

        private static void OnMovieChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(newValue is Movie movie && bindable is MovieCard control)
            {
                control.coverImage.Source = ImageSource.FromResource("Imagine.Resources.Images.movie_placeholder.jpeg");
            }
        }
    }
}