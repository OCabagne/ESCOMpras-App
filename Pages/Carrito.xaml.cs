using test1.Models;

namespace test1.Pages;

public partial class Carrito : ContentPage
{
    public IList<Producto> CarritoCompras { get; private set; }
    public int total = 0;
    public Carrito()
	{
		InitializeComponent();
        CarritoCompras = new List<Producto>();

        CarritoCompras.Add(new Producto
        {
            Id = 4,
            Name = "Disco Duro",
            Info = "Vendo disco duro en quince pesos y una galleta\r\n:v/",
            Precio = 15,
            Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/300375836_363294596011775_8020817456898374639_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=l4F7hXhfMr4AX9P3Tw5&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex31-1.fna&oh=00_AT9YtXcdAXb9DPft7bYYDnR1ReSLZMRb8xsQHCy12F9Fhg&oe=63092C7B"
        });

        foreach (var item in CarritoCompras)
            total += item.Precio;

        BindingContext = this;
    }

    public Carrito(Producto producto)
    {
        InitializeComponent();
        CarritoCompras.Add(producto);
        foreach (var item in CarritoCompras)
            total += item.Precio;

        BindingContext = this;
    }

    private async void ComprarYa_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Comprar());
    }
}