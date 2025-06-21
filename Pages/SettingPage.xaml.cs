using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace EcoDive_Integradora.Pages;

    public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Cerrar sesión", "¿Deseas salir de la app?", "Sí", "No");
        if (confirm)
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
