using ESCOMpras.Models;
namespace test1.Pages;

public partial class HomePage : ContentPage
{
    public IList<Producto> Productos { get; private set; }
    public Cliente Cliente { get; private set; }
	public HomePage()
	{
		InitializeComponent();

        Productos = new List<Producto>();
        Cliente = new Cliente();

        //LogIn("OCabagne@outlook.com", "1Contraseña");

        obtenerProductos(1);
        //obtenerProductos(Cliente.EscuelaIdescuela);
    }

    private async void LogIn(string correo, string password)    // temporal function. This is gonna be an independent page "LogIn"
    {
        try 
        {
            //cliente = await internetEscompras.LogIn(correo, password);
            Cliente = await internetEscompras.GetCliente(38);
        }
        catch (Exception e)
        {
            await DisplayAlert("Login", "Some errors ocurred", "OK");
        }
    }

    private void productosLocal()
    {
        Productos.Add(new Producto
        {
            Idproducto = 1,
            Nombre = "Cables",
            Descripcion = "Venta de cables para protoboard",
            Precio = 30,
            Imagen = "https://silicio.mx/media/catalog/product/cache/1/image/650x650/5e06319eda06f020e43594a9c230972d/p/r/pro12706o/Paquete-de-cables-puente-para-Protoboard---(200mm_100mm)-31.jpg"
        });

        Productos.Add(new Producto
        {
            Idproducto = 2,
            Nombre = "Termos",
            Descripcion = "Pues miren aquí para platicarles que voy a estar vendiendo estos productos por la escuela así que pues si ahí les interesa alguno comentenme o tirenme mensajito y nada, aprovechen que ahorita voy a estar teniendo promos jaja",
            Precio = 50,
            Imagen = "https://cf.shopee.com.mx/file/a14f4d05c07452558e3bf613d3797846"
        });

        Productos.Add(new Producto
        {
            Idproducto = 3,
            Nombre = "Muñecos Tejidos",
            Descripcion = "Aló, andamos vendiendo muñecos tejidos, con el diseño que les guste. Si quieren encargar manden dm:):)",
            Precio = 40,
            Imagen = "https://scontent.fmex28-1.fna.fbcdn.net/v/t39.30808-6/306076645_3652070031694446_7758624579404017598_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=NY5jUOaBJDsAX9fGWPo&_nc_ht=scontent.fmex28-1.fna&oh=00_AT-pW6-P5H3OyEW-a4-cZ9dihS-MBp9RUpHehZpcEaA-Mg&oe=631FB4CC"
        });

        Productos.Add(new Producto
        {
            Idproducto = 4,
            Nombre = "Stickers para laptop",
            Descripcion = "Banda, volvieron los stickers y llaveros. Estuve algo ocupado y apenas me desocupó. Stickers 5cu 3*10.  Llaveros 50cu 3*120.",
            Precio = 5,
            Imagen = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305343495_10229529123671625_6068792446806830454_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=Z77UyFl5pb0AX-QvVqE&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex27-1.fna&oh=00_AT8pean6fKNEAOxCU0ZFcWTLtZADiayG0yFh6Qir9U-dRg&oe=631F585F"
        });

        Productos.Add(new Producto
        {
            Idproducto = 5,
            Nombre = "Pan de muerto",
            Descripcion = "Holi bandaaa. Ya llegaron los panes de muerto rellenos.",
            Precio = 15,
            Imagen = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305450747_5280053232120847_7852904774655662240_n.jpg?stp=cp1_dst-jpg&_nc_cat=102&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=NfyVpxXNC8sAX8HMwyo&_nc_ht=scontent.fmex27-1.fna&oh=00_AT-4Bwf53ugAyEb8z9OaiXH3IDGPetah8trxAAm8HQYoXg&oe=631FA99B"
        });

        Productos.Add(new Producto
        {
            Idproducto = 6,
            Nombre = "Llaveros",
            Descripcion = "Voy a estar vendiendo estos lindos llaveros de madera con grabado.También se pueden personalizar.",
            Precio = 30,
            Imagen = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305617076_607513471085927_6765187087115279827_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=nC-1IuPHO5MAX9AyL9K&_nc_ht=scontent.fmex27-1.fna&oh=00_AT8FV0loWQ8taf8Gu8Wqx1LHw5MyEXMDl_9-cvLP_gcyYg&oe=6320214E"
        });

        BindingContext = this;
    }
    private async void obtenerProductos(int schoolId)
    {
        Productos = await internetEscompras.GetProductos();    // id para ESCOM = 1
        
        foreach (var item in Productos)
        {
            //item.Imagen = "https://www.memecreator.org/static/images/memes/4845128.jpg";
            item.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
        }
        
        BindingContext = this;
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Producto selectedItem = e.SelectedItem as Producto;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Producto publicacion = e.Item as Producto;
        if (publicacion != null)
        {
            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
    }

    async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        obtenerProductos(1);
        //obtenerProductos(Cliente.EscuelaIdescuela);
        RefreshView.IsRefreshing = false;
    }

    async Task GoToDetailsAsync(Producto producto)
    {
        if (producto is null)
            return;

        await Shell.Current.GoToAsync($"{nameof(DetailsPage)}", true, 
            new Dictionary<string, object>
            {
                {"Producto", producto }
            });
    }

    private void CarritoBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("Carrito");
    }
}