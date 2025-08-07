using Microsoft.Maui.Controls;
using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;
using System.Threading.Tasks;

namespace EcoDive_Integradora.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // ✅ Obtener el correo sin duplicar variable
            string email = "";

            if (Application.Current.MainPage is AppShell appShell)
            {
                email = appShell.UsuarioCorreo ?? "Correo no disponible";
            }
            else if (Application.Current.MainPage is AdminShell adminShell)
            {
                email = adminShell.AdminCorreo ?? "Correo no disponible";
            }

          
        }
    }
}
