using ESCOMpras.Models;
using ESCOMpras.Pages;
namespace test1.Pages;

public partial class PedidosAnteriores : ContentPage
{
    public IList<PedidoPendiente> PedidosPendientes { get; private set; }
    public IList<Producto> Productos { get; private set; }
    public IList<Producto> Pendientes { get; private set; }
    private IList<Orden> Ordenes { get; set; }
    //private IList<Compra> Compras { get; set; }

    private int idCliente;
    public PedidosAnteriores()
    {
        InitializeComponent();

        getProductos(idCliente);

    }

    private async void getProductos(int idCliente)
    {
        sinPedidos.IsVisible = false;
        Ordenes = new List<Orden>();

        idCliente = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente"));
        Ordenes = await internetEscompras.GetOrdenes(idCliente);

        if (Ordenes.Count != 0)
        {
            Productos = new List<Producto>();
            PedidosPendientes = new List<PedidoPendiente>();
            PedidoPendiente item;

            foreach (var orden in Ordenes)
            {
                Compra obj = await internetEscompras.GetCompra(orden.Idorden);
                //Compras.Add(obj);

                Producto obj2 = await internetEscompras.GetProducto(obj.ProductoIdproducto);
                obj2.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
                Productos.Add(obj2);

                item = new PedidoPendiente(obj.ProductoIdproducto, idCliente, orden.EscuelaIdescuela, orden.TiendaIdtienda, orden.Idorden, obj.Cantidad, obj.Detalles, orden.Fecha, orden.Montototal);
                PedidosPendientes.Add(item);
            }

            BindingContext = this;
        }
        else
        {
            sinPedidos.IsVisible = true;
        }
    }

    private void getProductosLocal()
    {
        Productos.Add(new Producto
        {
            Idproducto = 2,
            Nombre = "Cubrebocas ESCOM",
            Descripcion = "Sale bandicta, volvieron los cubrebocas perrones. Tiren facha por solo $35, voy a dónde estén.",
            Precio = 35,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/300965950_5297062457054189_9210136749168468353_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=O1ktXAeL30QAX89cvI5&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_gMIXo8uOWOHC486CFFmdVPE01y8QDKNe90zMaw33n8g&oe=6308F91E"
        });

        Productos.Add(new Producto
        {
            Idproducto = 3,
            Nombre = "Cheesecake",
            Descripcion = "Que onda papis delicioso Cheesecake con frambuesa a $40 la rebanadota",
            Precio = 40,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/299205838_5342416545806462_4458316384765062868_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=GUuSqXwS0xAAX-G4rV3&_nc_ht=scontent.fmex31-1.fna&oh=00_AT9AVOYlieYhxKshQ6WysML7PWANuAxMSE2FEC5jbzVGYA&oe=6308F832"
        });

        Productos.Add(new Producto
        {
            Idproducto = 5,
            Nombre = "Pan de muerto",
            Descripcion = "Holi bandaaa. Ya llegaron los panes de muerto rellenos.",
            Precio = 15,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/301112414_5240589622733875_5002197853494165997_n.jpg?stp=cp1_dst-jpg&_nc_cat=104&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=BK4ppB8rGdMAX-LHOQu&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_ACqoU7xT6XXPb193tsf3Zcb4wAHuskvhWyKQylFBn3w&oe=6309EB9B"
        });

        Pendientes = new List<Producto>();

        Pendientes.Add(new Producto
        {
            Idproducto = 6,
            Nombre = "Llaveros",
            Descripcion = "Voy a estar vendiendo estos lindos llaveros de madera con grabado.También se pueden personalizar.",
            Precio = 30,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/299935994_3249092988663752_2287381679253637715_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=xG5Ix5Ob-d4AX_VSaSo&_nc_ht=scontent.fmex31-1.fna&oh=00_AT-Dh-Ib-1YYYvXEph_2JAUNTjEH41BRw5ghhlzy_SsQAg&oe=63086F39"
        });

        BindingContext = this;
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
        
        /*
        Producto publicacion = e.Item as Producto;
        if (publicacion != null)
        {
            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
        */
    }

    /*
    async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(3000);
        RefreshView.IsRefreshing = false;
    }
    */
}