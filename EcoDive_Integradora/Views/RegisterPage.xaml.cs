using EcoDive_Integradora.Services;
using Microsoft.Maui.Controls;
using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;

namespace EcoDive_Integradora.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
        VerificarExistenciaDeAdmin(); // 👈 Llama al método para ocultar el botón si ya existe

        // Solo muestra el botón para crear admin si estás en pruebas
       // CreateAdminButton.IsVisible = true; // Puedes cambiar a false cuando subas a producción
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Error", "Por favor ingresa un correo y contraseña.", "OK");
            return;
        }

        var result = await FirebaseAuthService.Register(email, password);

        if (result != null)
        {
            var firebaseHelper = new FirebaseHelper();

            var nuevoUsuario = new User
            {
                Email = email,
                Password = password,
                Rol = "usuario"
            };

            await firebaseHelper.RegisterUser(nuevoUsuario);

            await DisplayAlert("Registro exitoso", "Ahora puedes iniciar sesión.", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar el usuario.", "OK");
        }
    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnCreateAdminClicked(object sender, EventArgs e)
    {
        var firebaseHelper = new FirebaseHelper();

        var admin = new User
        {
            Email = "admin@gmail.com",
            Password = "qwer1234",
            Rol = "admin"
        };

        await firebaseHelper.RegisterUser(admin);
        await DisplayAlert("Admin creado", "Ya puedes iniciar sesión como administrador", "OK");

        // Oculta el botón después de crear el admin (opcional)
        CreateAdminButton.IsVisible = false;
    }
    private async void VerificarExistenciaDeAdmin()
    {
        var firebaseHelper = new FirebaseHelper();
        bool existeAdmin = await firebaseHelper.ExisteUsuario("admin@gmail.com");

        CreateAdminButton.IsVisible = !existeAdmin; // Se oculta si ya existe
    }

}
