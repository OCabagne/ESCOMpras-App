using ESCOMpras.Models;

namespace test1.Pages;

public partial class SearchPage : ContentPage
{
    public IList<Producto> Productos { get; private set; }
    public SearchPage()
	{
		InitializeComponent();
        Productos = new List<Producto>();

        Productos.Add(new Producto
        {
            Idproducto = 1,
            Nombre = "Llaveros",
            Descripcion = "Voy a estar vendiendo estos lindos llaveros de madera con grabado.También se pueden personalizar.",
            Precio = 30,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/299935994_3249092988663752_2287381679253637715_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=xG5Ix5Ob-d4AX_VSaSo&_nc_ht=scontent.fmex31-1.fna&oh=00_AT-Dh-Ib-1YYYvXEph_2JAUNTjEH41BRw5ghhlzy_SsQAg&oe=63086F39"
        });

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
            Idproducto = 4,
            Nombre = "Disco Duro",
            Descripcion = "Vendo disco duro en quince pesos y una galleta\r\n:v/",
            Precio = 15,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/300375836_363294596011775_8020817456898374639_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=l4F7hXhfMr4AX9P3Tw5&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex31-1.fna&oh=00_AT9YtXcdAXb9DPft7bYYDnR1ReSLZMRb8xsQHCy12F9Fhg&oe=63092C7B"
        });

        Productos.Add(new Producto
        {
            Idproducto = 5,
            Nombre = "Pan de muerto",
            Descripcion = "Holi bandaaa. Ya llegaron los panes de muerto rellenos.",
            Precio = 15,
            Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/301112414_5240589622733875_5002197853494165997_n.jpg?stp=cp1_dst-jpg&_nc_cat=104&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=BK4ppB8rGdMAX-LHOQu&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_ACqoU7xT6XXPb193tsf3Zcb4wAHuskvhWyKQylFBn3w&oe=6309EB9B"
        });

        Productos.Add(new Producto
        {
            Idproducto = 6,
            Nombre = "Cables",
            Descripcion = "Venta de cables para protoboard",
            Precio = 30,
            Imagen = "https://silicio.mx/media/catalog/product/cache/1/image/650x650/5e06319eda06f020e43594a9c230972d/p/r/pro12706o/Paquete-de-cables-puente-para-Protoboard---(200mm_100mm)-31.jpg"
        });

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
            /*
            var navParameter = new Dictionary<string, object> 
            {
                { "Product", publicacion }
            };
            */

            //await Shell.Current.GoToAsync($"Detalles", navParameter);

            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
    }
}