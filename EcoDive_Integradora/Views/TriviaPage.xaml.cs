using EcoDive_Integradora.Models;
using EcoDive_Integradora.Services;
using Newtonsoft.Json;
using System.Text;

namespace EcoDive_Integradora.Views
{ 
public partial class TriviaPage : ContentPage
{
    public TriviaPage()
    {
            InitializeComponent();
        }

        
        private async void OnEnviarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NombreEntry.Text))
        {
            await DisplayAlert("Error", "Por favor, ingresa tu nombre.", "OK");
            return;
        }
        var trivia = new TriviaModel
        {
            Nombre = NombreEntry.Text,
            Respuestas = new List<string>
            {
                Pregunta1Picker.SelectedItem?.ToString() ?? "",
                    Pregunta2Picker.SelectedItem?.ToString() ?? "",
                    Pregunta3Picker.SelectedItem?.ToString() ?? "",
                    Pregunta4Picker.SelectedItem?.ToString() ?? "",
                    Pregunta5Picker.SelectedItem?.ToString() ?? ""
                }
        };

        await FirebaseService.GuardarTrivia(trivia);
        await DisplayAlert("¡Gracias!", "Tus respuestas han sido guardadas.", "OK");
        NombreEntry.Text = "";
        Pregunta1Picker.SelectedIndex = -1;
        Pregunta2Picker.SelectedIndex = -1;
        Pregunta3Picker.SelectedIndex = -1;
        Pregunta4Picker.SelectedIndex = -1;
        Pregunta5Picker.SelectedIndex = -1;
    }
}
}