using ESCOMpras.Models;

namespace test1.Pages;

public partial class Carrito : ContentPage
{
    public IList<Producto> CarritoCompras { get; private set; }
    private Producto producto { get; set; }
    public Carrito()
    {
        InitializeComponent();
        CarritoCompras = new List<Producto>();

        BindingContext = this;
    }

    public Carrito(Producto _producto)
    {
        InitializeComponent();
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
        PedidoVM pedido = new PedidoVM();
        pedido.NombreProducto = producto.Nombre;
        pedido.PrecioProducto = producto.Precio;
        //pedido.Cantidad = pickerCantidad.SelectedItem;
        pedido.Cantidad = 2;
        pedido.Total = pedido.PrecioProducto * pedido.Cantidad;
        pedido.idTienda = producto.TiendaIdtienda;
        pedido.idProducto = producto.Idproducto;
        pedido.Horario = pickerHorario.SelectedItem.ToString();

        await Navigation.PushAsync(new Comprar(pedido));
    }
}