using ESCOMpras.Models;

namespace test1.Pages;

public partial class Comprar : ContentPage
{
    public IList<Producto> Pedido { get; private set; }
    //public IList<PedidoVM> PedidoVM { get; private set; }
    public PedidoVM PedidoVM { get; private set; }
    private int idEscuela;
    public Comprar(Producto producto)
    {
        InitializeComponent();

        Pedido = new List<Producto>();
        Pedido.Add(producto);
        BindingContext = this;
    }

    public Comprar(PedidoVM producto)
    {
        InitializeComponent();

        //PedidoVM = new List<PedidoVM>();
        //PedidoVM.Add(producto);
        PedidoVM = producto;
        loadData();
        BindingContext = PedidoVM;
    }
    private async void loadData()
    {
        idEscuela = Int32.Parse(await SecureStorage.Default.GetAsync("idEscuela"));
        nombreEscuela.Text = await internetEscompras.GetNombreEscuela(idEscuela);
    }

    private async void FinalizarPedido_Clicked(object sender, EventArgs e)
    {
        // internet ESCOMpras para añadir un pedido nuevo
        Orden orden = new Orden
        {
            Fecha = DateTime.Now,
            Montototal = PedidoVM.Total,
            ClienteIdcliente = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente")),
            EscuelaIdescuela = idEscuela,
            TiendaIdtienda = PedidoVM.idTienda
        };

        int idOrden = internetEscompras.NuevaOrden(orden);  // revisar
        if (idOrden == 0)
        {
            await DisplayAlert("", "Ha ocurrido un error.", "Ok");
        }
        else
        {
            Compra compra = new Compra
            {
                Cantidad = PedidoVM.Cantidad,
                Detalles = null,
                ProductoIdproducto = PedidoVM.idProducto,
                OrdenIdorden = idOrden
            };

            await internetEscompras.NuevaCompra(compra);
            await Navigation.PushAsync(new PedidoFinalizado());
        }
    }
}