using test1.Models;

namespace test1.Pages;

public partial class DetailsPage : ContentPage
{
	public DetailsPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    public DetailsPage(Producto productoSeleccionado)
    {
        InitializeComponent();
        this.BindingContext = productoSeleccionado;
    }

    private async void addToCart_Clicked(object sender, EventArgs e)
    {
        // UPDATE DATABASE TABLE 'carrito' WITH THE CURRENT PRODUCT IN DETAIL VIEW
        await Navigation.PushAsync(new Carrito());
    }

    private async void buyNow_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Comprar());
    }
}