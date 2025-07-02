using EcoDive_Integradora.Models;
using EcoDive_Integradora.Services;

namespace EcoDive_Integradora.Views
{
    public partial class ListTriviaPage : ContentPage
    {
        public ListTriviaPage()
        {
            InitializeComponent();
            CargarTrivia();
        }

        private async void CargarTrivia()
        {
            var respuestas = await FirebaseService.ObtenerTrivia();

            if (respuestas.Count == 0)
            {
                LoadingLabel.Text = "No hay respuestas registradas.";
                return;
            }

            LoadingLabel.IsVisible = false;

            foreach (var trivia in respuestas)
            {
                TriviaListLayout.Children.Add(new Label
                {
                    Text = $"👤 {trivia.Nombre}",
                    FontAttributes = FontAttributes.Bold,
                    TextColor = Colors.Teal
                });

                for (int i = 0; i < trivia.Respuestas.Count; i++)
                {
                    TriviaListLayout.Children.Add(new Label
                    {
                        Text = $"Pregunta {i + 1}: {trivia.Respuestas[i]}",
                        FontSize = 14
                    });
                }

                // Separador visual
                TriviaListLayout.Children.Add(new BoxView
                {
                    HeightRequest = 1,
                    Color = Colors.Gray,
                    Margin = new Thickness(0, 10)
                });
            }
        }
    }
}
