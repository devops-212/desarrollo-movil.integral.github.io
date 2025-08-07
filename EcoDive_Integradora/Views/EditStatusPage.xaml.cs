using EcoDive_Integradora.Helpers;
using EcoDive_Integradora.Models;


namespace EcoDive_Integradora.Views;

public partial class EditStatusPage : ContentPage
{
    private Producto _producto;
    private Interno _interno;
    private bool esProducto;

    private readonly FirebaseHelper _firebaseHelper = new FirebaseHelper();

    public EditStatusPage(Producto producto)
    {
        InitializeComponent();
        _producto = producto;
        esProducto = true;

        CategoriaPicker.SelectedItem = _producto.Categoria;
        SubcategoriaPicker.SelectedItem = _producto.Subcategoria;
        EstadoPicker.SelectedItem = _producto.Estado;
    }

    public EditStatusPage(Interno interno)
    {
        InitializeComponent();
        _interno = interno;
        esProducto = false;

        CategoriaPicker.SelectedItem = _interno.Categoria;
        SubcategoriaPicker.SelectedItem = _interno.Subcategoria;
        EstadoPicker.SelectedItem = _interno.Estado;
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        if (esProducto)
        {
            _producto.Categoria = CategoriaPicker.SelectedItem?.ToString() ?? "";
            _producto.Subcategoria = SubcategoriaPicker.SelectedItem?.ToString() ?? "";
            _producto.Estado = EstadoPicker.SelectedItem?.ToString() ?? "";

            await _firebaseHelper.UpdateProducto(_producto.Id, _producto);
        }
        else
        {
            _interno.Categoria = CategoriaPicker.SelectedItem?.ToString() ?? "";
            _interno.Subcategoria = SubcategoriaPicker.SelectedItem?.ToString() ?? "";
            _interno.Estado = EstadoPicker.SelectedItem?.ToString() ?? "";

            await _firebaseHelper.UpdateInterno(_interno.Id, _interno);
        }

        await DisplayAlert("Actualizado", "El estado ha sido actualizado", "OK");
        await Navigation.PopAsync();
    }
}
