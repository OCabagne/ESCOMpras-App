using ESCOMpras.Models;
using ESCOMpras.Pages;

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
        string tipo = await SecureStorage.Default.GetAsync("tipo");
        if (tipo.Equals("Cliente"))
        {
            editarProducto.IsVisible = false;
        }
        else if (tipo.Equals("Tienda"))
        {
            addToCart.IsVisible = false;
            buyNow.IsVisible = false;
        }
    }

    private async void addToCart_Clicked(object sender, EventArgs e)
    {
        //await Navigation.PushAsync(new Carrito());
        await Navigation.PushAsync(new Carrito(seleccion));
    }

    private async void editarProducto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AgregarProducto(seleccion));
    }
    
    private async void buyNow_Clicked(object sender, EventArgs e)
    {
        PedidoVM pedido = new PedidoVM
        {
            NombreProducto = seleccion.Nombre,
            PrecioProducto = seleccion.Precio,
            Cantidad = 1,
            Total = seleccion.Precio,
            idTienda = seleccion.TiendaIdtienda,
            idProducto = seleccion.Idproducto,
            Horario = "16:00"
        };

        await Navigation.PushAsync(new Comprar(pedido));
    }
}