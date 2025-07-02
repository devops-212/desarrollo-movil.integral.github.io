namespace EcoDive_Integradora.Views
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage());
        }
        private async void OnSearchProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchProductPage());
        }
        private async void OnListProductClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListProductsPage());
        }
        private async void OnSalirClicked(object sender, EventArgs e)
        {
            // Si estás guardando sesión con Preferences, podrías limpiar aquí
            // Preferences.Clear();

            // Redirige a la página de login (ajusta según tu estructura)
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }

        private async void OnResponderTriviaClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TriviaPage());
        }

        private async void OnVerRespuestasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTriviaPage());
        }
    }


}
