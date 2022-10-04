using ESCOMpras.Cells;
using ESCOMpras.Models;
using test1.Cells;

namespace test1.Pages;

public partial class Carrito : ContentPage
{
    public IList<Producto> CarritoCompras { get; private set; }
    private Producto producto { get; set; }
    public Carrito()
    {
        InitializeComponent();

        ProductosCarrito.IsVisible = false;
        DetallesCarrito.IsVisible = false;
        ComprarYa.IsVisible = false;

        BindingContext = this;
    }

    public Carrito(Producto _producto)
    {
        InitializeComponent();
        sinPedidos.IsVisible = false;
        producto = new Producto();
        producto = _producto;
        CarritoCompras = new List<Producto> { producto };
        loadData();
        BindingContext = this;
    }

    private async void loadData()
    {
        int idEscuela = Int32.Parse(await SecureStorage.Default.GetAsync("idEscuela"));
        escuelaActual.Text = await internetEscompras.GetNombreEscuela(idEscuela);
    }

    private async void ComprarYa_Clicked(object sender, EventArgs e)
    {
        if (pickerHorario.SelectedItem == null)
        {
            await DisplayAlert("", "Por favor selecciona un horario.", "Ok");
        }
        else if(pickerCantidad.SelectedItem == null)
        {
            await DisplayAlert("", "Por favor selecciona una cantidad.", "Ok");
        }
        else
        {
            PedidoVM pedido = new PedidoVM();
            pedido.NombreProducto = producto.Nombre;
            pedido.PrecioProducto = producto.Precio;
            pedido.Cantidad = Int32.Parse(pickerCantidad.SelectedItem.ToString());
            //pedido.Cantidad = 2;
            pedido.Total = pedido.PrecioProducto * pedido.Cantidad;
            pedido.idTienda = producto.TiendaIdtienda;
            pedido.idProducto = producto.Idproducto;
            pedido.Horario = pickerHorario.SelectedItem.ToString();

            await Navigation.PushAsync(new Comprar(pedido));
        }
    }
}