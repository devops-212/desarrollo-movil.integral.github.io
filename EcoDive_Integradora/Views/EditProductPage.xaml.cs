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
                    _producto = await _firebaseHelper.GetProductoById(ProductoId);

                    if (_producto != null)
                    {
                        name.Text = _producto.name;
                        emailid.Text = _producto.email;
                        msgContent.Text = _producto.message;
                    }
                    else
                    {
                        await DisplayAlert("Error", "Mensaje no encontrado", "OK");
                        await Navigation.PopAsync();
                    }
                }
                else
                {
                    await DisplayAlert("Error", "No se recibió el ID del mensaje", "OK");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepción", $"Error al cargar el mensaje: {ex.Message}", "OK");
                await Navigation.PopAsync();
            }
        }

        private async void OnUpdateProductoClicked(object sender, EventArgs e)
        {
            if (_producto == null)
            {
                await DisplayAlert("Error", "Mensaje no cargado correctamente", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(name.Text) ||
                string.IsNullOrWhiteSpace(emailid.Text) ||
                string.IsNullOrWhiteSpace(msgContent.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            try
            {
                _producto.name = name.Text;
                _producto.email = emailid.Text;
                _producto.message = msgContent.Text;

                await _firebaseHelper.UpdateProducto(_producto.Id, _producto);
                await DisplayAlert("Éxito", "Mensaje actualizado correctamente", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"No se pudo actualizar el mensaje: {ex.Message}", "OK");
            }
        }
    }
}
