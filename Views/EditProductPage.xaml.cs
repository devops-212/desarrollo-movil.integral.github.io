using MauiFirebaseApp.Models;
using Maui.FirebaseApp.Helpers;

namespace EcoDive_Integradora.Views;

public partial class EditProductPage : ContentPage
{
	public EditProductPage()
	{

		private FirebaseHelper FirebaseHelper = new FirebaseHelper();
	private Producto producto;

   public EditProductPage()
	{

			InitializeComponent();
		this producto = producto;
		//Aqui se cargaran datos ingresados

		NombreEntry.text = producto.Nombre;
		ContactoEntry.Text = producto.Contacto.ToString();
        DescripcionEntry.Text = producto.Descripcion;


    }

	private async vold OnUpdateProductClicked(object sender, EventArgs e)
	{
		producto.Nombre = NombreEntry.Text;
		producto.Descripcion = DescripcionEntry.Text;
		producto.Contacto = decimal.Parse(ContactoEntry.Text);

		await FirebaseHelper.UpdateProducto(producto.Id, producto);
		await DisplayAlert("Exito", "Registro Actualizado", "OK");
		await Navigation.PopAsync();
	}
}