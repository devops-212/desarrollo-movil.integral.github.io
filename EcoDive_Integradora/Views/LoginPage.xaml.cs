using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using EcoDive_Integradora.Services;
using Firebase.Auth;

namespace EcoDive_Integradora.Views
{
    public partial class LoginPage : ContentPage
    {
        private const string FirebaseApiKey = "AIzaSyCf0ZvRcTZSjXa0f-ywnl4ZSJ0nbvdyEB0"; // Usa tu API key real

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            var result = await FirebaseAuthService.Login(email, password);
            if (result != null)
            {
                await DisplayAlert("Bienvenido", $"Sesión iniciada  {result.Email}", "OK");
                Application.Current.MainPage = new NavigationPage(new AppShell());
            }
            else
            {
                await DisplayAlert("Error", "Correo o contraseña incorrectos", "OK");
            }
        }


        private async void OnRegisterTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void OnForgotPasswordClicked(object sender, EventArgs e)
        {
            string email = await DisplayPromptAsync("Recuperar contraseña", "Introduce tu correo:");

            if (!string.IsNullOrEmpty(email))
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseApiKey));
                await authProvider.SendPasswordResetEmailAsync(email);
                await DisplayAlert("Correo enviado", "Revisa tu bandeja para restablecer tu contraseña", "OK");
            }
        }
    }
}
