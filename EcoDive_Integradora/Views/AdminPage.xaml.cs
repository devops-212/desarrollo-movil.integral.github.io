using Microsoft.Maui.Controls;

namespace EcoDive_Integradora.Views
{
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void OnVerRespuestasClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListTriviaPage());
        }

       

        private async void OnVerListaContactosClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListProductsPage());
        }

    
    }
}
