using MauiFirebaseApp.Models;
using Maui.FirebaseApp.Helpers;

namespace EcoDive_Integradora.Views;

public partial class AddProductPage : ContentPage
{
	FirebaseHelpers firebaseHelpers = new FirebaseHelpers();
	public AddProductPage()
	{
		InitializeComponent();
	}

	private async void OnAddProductClicked (object sender, EventArgs e)
	{
		var producto = Producto
			{
			Nombre = NombreEntry.Text,
				Contacto =decimal.Parse (ContactoEntry.Text),
				Descripcion = DescripcionEntry.Text
				 
		};
		await firebaseHelpers.AddProducto(producto);
		await DisplayAlert("Exito", "Registro Guardado", "Ok");
		await Navigation.PopAsync();
	}
}