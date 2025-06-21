using Microsoft.Maui.Essentials;

namespace EcoDive_Integradora.Pages;


public partial class ReportePage : ContentPage
{
    public ReportePage()
    {
        InitializeComponent();
    }

    private async void OnTakePhotoClicked(object sender, EventArgs e)
    {
        var photo = await MediaPicker.CapturePhotoAsync();
        if (photo != null)
        {
            var stream = await photo.OpenReadAsync();
            PhotoPreview.Source = ImageSource.FromStream(() => stream);
        }
    }

    private async void OnGetLocationClicked(object sender, EventArgs e)
    {
        try
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if (location != null)
            {
                LocationLabel.Text = $"Lat: {location.Latitude}, Lon: {location.Longitude}";
            }
            else
            {
                LocationLabel.Text = "No se pudo obtener la ubicación.";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}
