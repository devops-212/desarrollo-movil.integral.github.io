using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;

namespace EcoDive_Integradora.Views
{
    public partial class AddProductPage : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();

        public AddProductPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreEntry.Text) || string.IsNullOrWhiteSpace(ContactoEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (!decimal.TryParse(ContactoEntry.Text, out decimal contactoDecimal))
            {
                await DisplayAlert("Error", "El contacto debe ser numérico.", "OK");
                return;
            }

            var producto = new Producto
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = NombreEntry.Text,
                Contacto = contactoDecimal,
                Descripcion = DescripcionEntry.Text
            };

            await _firebaseHelper.AddProducto(producto);
            await DisplayAlert("Éxito", "Contacto agregado correctamente.", "OK");
            await Navigation.PopAsync();
        }
    }
}
