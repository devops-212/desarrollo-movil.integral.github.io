using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;
using System.Collections.ObjectModel;

namespace EcoDive_Integradora.Views
{
    public partial class ListProductsPage : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();
        private ObservableCollection<Producto> _productos;

        public ListProductsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var lista = await _firebaseHelper.GetAllProductos();
            _productos = new ObservableCollection<Producto>(lista);
            ProductosCollection.ItemsSource = _productos;
        }

        private async void OnEditClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Producto producto)
            {
               // await Shell.Current.GoToAsync($"{nameof(EditProductPage)}?productoId={producto.Id}");
                // O si no usas Shell:
                 await Navigation.PushAsync(new EditProductPage { ProductoId = producto.Id });
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Producto producto)
            {
                bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar a {producto.Nombre}?", "Sí", "No");
                if (confirm)
                {
                    await _firebaseHelper.DeleteProducto(producto.Id);
                    _productos.Remove(producto);
                    await DisplayAlert("Eliminado", "El contacto ha sido eliminado.", "OK");
                }
            }
        }
    }
}
