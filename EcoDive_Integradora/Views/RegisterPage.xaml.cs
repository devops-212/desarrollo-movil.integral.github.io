using EcoDive_Integradora.Services;

namespace EcoDive_Integradora.Views;

public partial class RegisterPage : ContentPage
{
    private const string FirebaseApiKey = "AIzaSyCf0ZvRcTZSjXa0f-ywnl4ZSJ0nbvdyEB0";

    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = PasswordEntry.Text;
        string confirm = ConfirmPasswordEntry.Text;

        if (password != confirm)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
            return;
        }

        var result = await FirebaseAuthService.Register(email, password);
        if (result != null)
        {
            await DisplayAlert("Cuenta creada", $"Bienvenido: {result.Email}", "OK");
            await Navigation.PopAsync(); // Regresa al login
        }
        else
        {
            await DisplayAlert("Error", "No se pudo registrar el usuario", "OK");
        }
    }


    private async void OnLoginTapped(object sender, EventArgs e)
    {
        await Navigation.PopAsync(); // Regresa al login
    }
}
