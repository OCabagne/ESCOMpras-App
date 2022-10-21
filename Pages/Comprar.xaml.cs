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
        Orden orden = new Orden
        {
            Fecha = DateTime.Now.ToUniversalTime(),
            Montototal = PedidoVM.Total,
            ClienteIdcliente = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente")),
            EscuelaIdescuela = idEscuela,
            TiendaIdtienda = PedidoVM.idTienda
        };
        
        //int idOrden = await internetEscompras.NuevaOrden(orden);
        int idOrden = await internetEscompras.NuevaOrden(orden);

        if (idOrden == 0)
        {
            await DisplayAlert("Orden", "Ha ocurrido un error.", "Ok");
        }
        else
        {
            try
            {
                Producto _producto = await internetEscompras.GetProducto(PedidoVM.idProducto);

                Compra compra = new Compra
                {
                    Cantidad = PedidoVM.Cantidad,
                    descripcionproducto = _producto.Descripcion,
                    nombreproducto = _producto.Nombre,
                    precioproducto = _producto.Precio,
                    promocion = _producto.Promocion,
                    unidad = _producto.Unidad,
                    ProductoIdproducto = _producto.Idproducto,
                    OrdenIdorden = idOrden
                };
                if (Detalles.Text == null)
                    compra.Detalles = "Entrada principal";
                else
                    compra.Detalles = Detalles.Text;
                if (await internetEscompras.NuevaCompra(compra))
                {
                    await Navigation.PushAsync(new PedidoFinalizado(idOrden));
                }
                else
                {
                    await DisplayAlert("Compra", "Ha ocurrido un error.", "Ok");
                    await internetEscompras.BorrarOrden(idOrden);
                }
            }
            catch
            {
                await DisplayAlert("", "Ha ocurrido un error.", "Ok");
            }
        }
    }
}