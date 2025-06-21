using MauiFirebaseApp.Models;
using Maui.FirebaseApp.Helpers;
using AppIntegradora10A.Helpers;

namespace EcoDive_Integradora.Views;

public partial class ListProductsPage : ContentPage
{

	FirebaseHelpers FirebaseHelpers = new FirebaseHelpers();
	public ListProductsPage()
	{

		InitializeComponent();
		LoadProducts();
	}

	private async void LoadProducts()
	{
		var productos = await FirebaseHelpers.GetAllProductos();
		ProductsListView.ItemsSource = productos;

	}
	private async void OnEditProductClicked(object sender, EventArgs e)
	{
		var button = sender as Button;
		var producto = button?.BindingContext as Producto;
		if (producto != null)
		{
			await Navigation.PushAsync(new EditProductPage(producto));
		}

	}

	private async void OnDeleteProductClicked(object sender , EventArgs e)
	{
        var button = sender as Button;
        var producto = button?.BindingContext as Producto;
		if (producto != null && ! string.IsNullOrEmpty(producto.Id))
		{
			await FirebaseHelpers.DeleteProducto(producto.Id);
            await DisplayAlert("Exito", "Registro Eliminado", "OK");
			LoadProducts();

        }
		else
			{
			await DisplayAlert("Error", "Nose pudo encontrar el producto para eliminar.", "Ok");
		}
    }

}