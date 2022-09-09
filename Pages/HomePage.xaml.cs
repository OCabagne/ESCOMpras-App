using test1.Models;

namespace test1.Pages;

public partial class HomePage : ContentPage
{
	public IList<Producto> Productos { get; private set; }
	public HomePage()
	{
		InitializeComponent();

		Productos = new List<Producto>();

		Productos.Add(new Producto
		{
			Id = 1,
			Name = "Cables",
			Info = "Venta de cables para protoboard",
            Precio = 30,
            Url = "https://silicio.mx/media/catalog/product/cache/1/image/650x650/5e06319eda06f020e43594a9c230972d/p/r/pro12706o/Paquete-de-cables-puente-para-Protoboard---(200mm_100mm)-31.jpg"
        });

        Productos.Add(new Producto
        {
            Id = 2,
            Name = "Termos",
            Info = "Pues miren aqu� para platicarles que voy a estar vendiendo estos productos por la escuela as� que pues si ah� les interesa alguno comentenme o tirenme mensajito y nada, aprovechen que ahorita voy a estar teniendo promos jaja",
            Precio = 50,
            Url = "https://scontent.fmex28-1.fna.fbcdn.net/v/t39.30808-6/305043816_3345207999092244_5677156160535556282_n.jpg?_nc_cat=102&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=mgaOTkrYLisAX9-avxM&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex28-1.fna&oh=00_AT-Ft_eOPx6upX07BjfMM1Wdh4xBg0HxWJQxVEJzFM5EHw&oe=631F82C5"
        });

        Productos.Add(new Producto
        {
            Id = 3,
            Name = "Mu�ecos Tejidos",
            Info = "Al�, andamos vendiendo mu�ecos tejidos, con el dise�o que les guste. Si quieren encargar manden dm:):)",
            Precio = 40,
            Url = "https://scontent.fmex28-1.fna.fbcdn.net/v/t39.30808-6/306076645_3652070031694446_7758624579404017598_n.jpg?_nc_cat=106&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=NY5jUOaBJDsAX9fGWPo&_nc_ht=scontent.fmex28-1.fna&oh=00_AT-pW6-P5H3OyEW-a4-cZ9dihS-MBp9RUpHehZpcEaA-Mg&oe=631FB4CC"
        });

        Productos.Add(new Producto
        {
            Id = 4,
            Name = "Stickers para laptop",
            Info = "Banda, volvieron los stickers y llaveros. Estuve algo ocupado y apenas me desocup�. Stickers 5cu 3*10.  Llaveros 50cu 3*120.",
            Precio = 5,
            Url = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305343495_10229529123671625_6068792446806830454_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=Z77UyFl5pb0AX-QvVqE&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex27-1.fna&oh=00_AT8pean6fKNEAOxCU0ZFcWTLtZADiayG0yFh6Qir9U-dRg&oe=631F585F"
        });

        Productos.Add(new Producto
        {
            Id = 5,
            Name = "Pan de muerto",
            Info = "Holi bandaaa. Ya llegaron los panes de muerto rellenos.",
            Precio = 15,
            Url = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305450747_5280053232120847_7852904774655662240_n.jpg?stp=cp1_dst-jpg&_nc_cat=102&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=NfyVpxXNC8sAX8HMwyo&_nc_ht=scontent.fmex27-1.fna&oh=00_AT-4Bwf53ugAyEb8z9OaiXH3IDGPetah8trxAAm8HQYoXg&oe=631FA99B"
        });

        Productos.Add(new Producto
        {
            Id = 6,
            Name = "Llaveros",
            Info = "Voy a estar vendiendo estos lindos llaveros de madera con grabado.Tambi�n se pueden personalizar.",
            Precio = 30,
            Url = "https://scontent.fmex27-1.fna.fbcdn.net/v/t39.30808-6/305617076_607513471085927_6765187087115279827_n.jpg?_nc_cat=100&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=nC-1IuPHO5MAX9AyL9K&_nc_ht=scontent.fmex27-1.fna&oh=00_AT8FV0loWQ8taf8Gu8Wqx1LHw5MyEXMDl_9-cvLP_gcyYg&oe=6320214E"
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
            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
    }

    async void RefreshView_Refreshing(object sender, EventArgs e)
    {
        await Task.Delay(3000);
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