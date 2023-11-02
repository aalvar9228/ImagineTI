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
            BindableProperty.Create(nameof(Movie), typeof(Movie), typeof(MovieCard));

        public Movie Movie
        {
            get { return (Movie)GetValue(MovieProperty); }
            set { SetValue(MovieProperty, value); }
        }
    }
}