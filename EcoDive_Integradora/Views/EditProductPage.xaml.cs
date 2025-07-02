using System;
using Microsoft.Maui.Controls;
using EcoDive_Integradora.Models;
using EcoDive_Integradora.Helpers;

namespace EcoDive_Integradora.Views
{
    [QueryProperty(nameof(ProductoId), "productoId")]
    public partial class EditProductPage : ContentPage
    {
        private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();
        public string ProductoId { get; set; }
        private Producto _producto;

        public EditProductPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                if (!string.IsNullOrEmpty(ProductoId))
                {
                    // Debug temporal
                    // await DisplayAlert("DEBUG", $"ProductoId: {ProductoId}", "OK");

                    _producto = await _firebaseHelper.GetProductoById(ProductoId);

                    if (_producto != null)
                    {
                        NombreEntry.Text = _producto.Nombre;
                        ContactoEntry.Text = _producto.Contacto.ToString();
                        DescripcionEntry.Text = _producto.Descripcion;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Producto no encontrado", "OK");
                        await Navigation.PopAsync();
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se recibió el ID del producto", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepción", $"Error al cargar el producto: {ex.Message}", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void OnUpdateProductoClicked(object sender, EventArgs e)
        {
            if (_producto == null)
            {
                await DisplayAlert("Error", "Producto no cargado correctamente", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(NombreEntry.Text) ||
                string.IsNullOrWhiteSpace(ContactoEntry.Text) ||
                string.IsNullOrWhiteSpace(DescripcionEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            if (!decimal.TryParse(ContactoEntry.Text, out decimal contactoDecimal))
            {
                await DisplayAlert("Error", "El campo 'Contacto' debe ser numérico", "OK");
                return;
            }

            try
            {
                _producto.Nombre = NombreEntry.Text;
                _producto.Contacto = contactoDecimal;
                _producto.Descripcion = DescripcionEntry.Text;

                await _firebaseHelper.UpdateProducto(_producto.Id, _producto);
                await DisplayAlert("Éxito", "Registro actualizado correctamente", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo actualizar el producto: {ex.Message}", "OK");
            }
        }
    }
}
