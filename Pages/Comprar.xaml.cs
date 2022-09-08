using test1.Models;

namespace test1.Pages;

public partial class Comprar : ContentPage
{
    public IList<Producto> Pedido { get; private set; }
    public int total = 0;
    public Comprar()
	{
		InitializeComponent();

        Pedido = new List<Producto>();

        Pedido.Add(new Producto
        {
            Id = 4,
            Name = "Disco Duro",
            Info = "Vendo disco duro en quince pesos y una galleta\r\n:v/",
            Precio = 15,
            Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/300375836_363294596011775_8020817456898374639_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=l4F7hXhfMr4AX9P3Tw5&tn=vUJWUoujA9494jkx&_nc_ht=scontent.fmex31-1.fna&oh=00_AT9YtXcdAXb9DPft7bYYDnR1ReSLZMRb8xsQHCy12F9Fhg&oe=63092C7B"
        });

        Pedido.Add(new Producto
        {
            Id = 2,
            Name = "Cubrebocas ESCOM",
            Info = "Sale bandicta, volvieron los cubrebocas perrones. Tiren facha por solo $35, voy a dónde estén.",
            Precio = 35,
            Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/300965950_5297062457054189_9210136749168468353_n.jpg?_nc_cat=107&ccb=1-7&_nc_sid=5cd70e&_nc_ohc=O1ktXAeL30QAX89cvI5&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_gMIXo8uOWOHC486CFFmdVPE01y8QDKNe90zMaw33n8g&oe=6308F91E"
        });

        foreach (var item in Pedido)
            total += item.Precio;

        BindingContext = this;
    }

    private async void FinalizarPedido_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PedidoFinalizado());
    }
}