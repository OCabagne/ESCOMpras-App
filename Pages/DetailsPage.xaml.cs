using ESCOMpras.Models;

namespace test1.Pages;

public partial class DetailsPage : ContentPage
{
    private Producto seleccion { get; set; }
	public DetailsPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
    public DetailsPage(Producto productoSeleccionado)
    {
        InitializeComponent();
        seleccion = productoSeleccionado;
        Load();
        this.BindingContext = seleccion;
    }

    private async void Load()
    {
        seleccion.nombreTienda = await internetEscompras.GetNombreTienda(seleccion.TiendaIdtienda);
    }

    private async void addToCart_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new Carrito());
        await Navigation.PushAsync(new Carrito(seleccion));
    }

    /*
    private async void buyNow_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Comprar());
    }
    */
}