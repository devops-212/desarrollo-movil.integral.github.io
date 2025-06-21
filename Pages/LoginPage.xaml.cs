using Microsoft.Maui.Controls;



namespace EcoDive_Integradora.Pages;


public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string usuario = UsernameEntry.Text;
        string contrasena = PasswordEntry.Text;

        if (usuario == "admin" && contrasena == "1234")
        {
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            // Aquí podrías hacer navegación a otra página:
            // await Shell.Current.GoToAsync("//InfoPage");
        }
        else
        {
            await DisplayAlert("Error", "Credenciales incorrectas", "OK");
        }
    }
}
