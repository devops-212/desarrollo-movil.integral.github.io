using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;
using Microsoft.Maui.Controls;
using EcoDive_Integradora.Services;


namespace EcoDive_Integradora.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Ingresa correo y contraseña.", "OK");
            return;
        }

        var firebaseHelper = new FirebaseHelper();
        var user = await firebaseHelper.GetUser(email, password);

        if (user == null)
        {
            await DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
            return;
        }

        string? rol = user.Rol;

        if (rol == "admin")
        {
            await DisplayAlert("Bienvenido", $"Administrador\nCorreo: {user.Email}", "OK");
            Application.Current.MainPage = new AdminShell(user.Email);
        }
        else
        {
            await DisplayAlert("Bienvenido", $"Usuario\nCorreo: {user.Email}", "OK");
            Application.Current.MainPage = new AppShell(user.Email);
        }
    }

    private async void OnRegisterTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
    private async void OnForgotPasswordClicked(object sender, EventArgs e)
    {
        // await DisplayAlert("Recuperación", "Funcionalidad en construcción", "OK");
        // Aquí podrías redirigir a otra página o enviar un email, etc.Esto es en caso de que no se vaya a dejar el proyecto en prueba funcional para que no mande la recuperacion de contraseña

        string email = EmailEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Error", "Ingresa tu correo para recuperar tu contraseña.", "OK");
            return;
        }

        bool enviado = await FirebaseAuthService.ResetPassword(email);

        if (enviado)
            await DisplayAlert("Éxito", "Se ha enviado un correo para restablecer tu contraseña.", "OK");
        else
            await DisplayAlert("Error", "No se pudo enviar el correo de recuperación.", "OK");
    }

}


