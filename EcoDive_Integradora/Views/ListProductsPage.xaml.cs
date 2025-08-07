using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace EcoDive_Integradora.Views
{
    public partial class ListProductsPage : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();
        private ObservableCollection<Producto> _mensajesFormulario;

        public ListProductsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var lista = await _firebaseHelper.GetMensajesFormulario();
            _mensajesFormulario = new ObservableCollection<Producto>(lista);
            ProductosCollection.ItemsSource = _mensajesFormulario;
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Producto producto)
            {
                await Navigation.PushAsync(new EditProductPage { ProductoId = producto.Id });
            }
        }

        private async void OnEditStatusClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.BindingContext is Interno interno)
                {
                    await Navigation.PushAsync(new EditStatusPage(interno));
                }
                else if (button.BindingContext is Producto producto)
                {
                    await Navigation.PushAsync(new EditStatusPage(producto));
                }
                else
                {
                    await DisplayAlert("Aviso", "Tipo de dato no reconocido.", "OK");
                }
            }
        }


        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Producto producto)
            {
                bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar este mensaje?", "Sí", "No");
                if (confirm)
                {
                    await _firebaseHelper.DeleteProducto(producto.Id);
                    _mensajesFormulario.Remove(producto);
                    await DisplayAlert("Eliminado", "El mensaje ha sido eliminado.", "OK");
                }
            }
        }
    }
}
