using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class IconSelector : ContentPage
{
    Icon icono;
    public IconSelector()
    {
        InitializeComponent();
    }

    public IconSelector(Icon _icono)
    {
        InitializeComponent();
        icono = _icono;
        this.BindingContext = icono;
    }

    private async void guardarIcono_Clicked(object sender, EventArgs e)
    {
        try
        {
            await SecureStorage.Default.SetAsync("Icon", icono.Url.ToString());
            await DisplayAlert("", "Icono actualizado.", "Listo!");
            await Navigation.PopToRootAsync();
        }
        catch
        {
            await DisplayAlert("", "Ha ocurrido un error.", "Ok :(");
        }
    }
}