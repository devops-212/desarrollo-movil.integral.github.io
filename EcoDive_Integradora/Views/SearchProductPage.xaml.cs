using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;

namespace EcoDive_Integradora.Views
{
    public partial class SearchProductPage : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();
        private List<Producto> productos;

        public SearchProductPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            productos = await _firebaseHelper.GetAllProductos();
            ProductosCollection.ItemsSource = productos;
        }

        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
        {
            var texto = e.NewTextValue.ToLower();
            var filtrado = productos.Where(p => p.Nombre.ToLower().Contains(texto)).ToList();
            ProductosCollection.ItemsSource = filtrado;
        }
    }
}
