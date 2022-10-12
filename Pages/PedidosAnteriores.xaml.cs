using ESCOMpras.Models;
using ESCOMpras.Pages;
namespace test1.Pages;

public partial class PedidosAnteriores : ContentPage
{
    public IList<PedidoPendiente> PedidosPendientes { get; private set; }
    public IList<Producto> Productos { get; private set; }
    private IList<OrdenVM> Ordenes { get; set; }

    private int Id;
    public PedidosAnteriores()
    {
        InitializeComponent();

        getProductos();

    }

    private async void getProductos()
    {
        sinPedidos.IsVisible = false;
        Ordenes = new List<OrdenVM>();
        string tipo = await SecureStorage.Default.GetAsync("tipo");

        if (tipo.Equals("Cliente"))
        {
            Id = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente"));
            Ordenes = await internetEscompras.GetOrdenes(Id);

            if (Ordenes.Count != 0)
            {
                Productos = new List<Producto>();
                PedidosPendientes = new List<PedidoPendiente>();
                PedidoPendiente item;

                foreach (var orden in Ordenes)
                {
                    try
                    {
                        Compra obj = await internetEscompras.GetCompra(orden.Idorden);
                        //Compras.Add(obj);

                        Producto obj2 = await internetEscompras.GetProducto(obj.ProductoIdproducto);
                        obj2.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
                        Productos.Add(obj2);

                        item = new PedidoPendiente(obj.ProductoIdproducto, Id, orden.EscuelaIdescuela, orden.TiendaIdtienda, orden.Idorden, obj.Cantidad, obj.Detalles, orden.Fecha, orden.Montototal, obj2);
                        PedidosPendientes.Add(item);
                        item = null;
                    }
                    catch { }
                }

                BindingContext = this;
            }
            else
            {
                sinPedidos.IsVisible = true;
            }
        }

        else if (tipo.Equals("Tienda"))
        {
            Id = Int32.Parse(await SecureStorage.Default.GetAsync("idTienda"));
            Ordenes = await internetEscompras.GetOrdenesTienda(Id);

            if (Ordenes.Count != 0)
            {
                Productos = new List<Producto>();
                PedidosPendientes = new List<PedidoPendiente>();
                PedidoPendiente item;

                foreach (var orden in Ordenes)
                {
                    try
                    {
                        Compra obj = await internetEscompras.GetCompra(orden.Idorden);
                        //Compras.Add(obj);

                        Producto obj2 = await internetEscompras.GetProducto(obj.ProductoIdproducto);
                        obj2.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
                        Productos.Add(obj2);

                        item = new PedidoPendiente(obj.ProductoIdproducto, orden.ClienteIdcliente, orden.EscuelaIdescuela, orden.TiendaIdtienda, orden.Idorden, obj.Cantidad, obj.Detalles, orden.Fecha, orden.Montototal, obj2);
                        PedidosPendientes.Add(item);
                        item = null;
                    }
                    catch
                    {
                    }
                }

                BindingContext = this;
            }
            else
            {
                sinPedidos.IsVisible = true;
            }
        }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Producto selectedItem = e.SelectedItem as Producto;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        PedidoPendiente publicacion = e.Item as PedidoPendiente;
        if (publicacion != null)
            await Navigation.PushAsync(new PendientesPage(publicacion));
    }

    /*
    async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(3000);
        RefreshView.IsRefreshing = false;
    }
    */
}