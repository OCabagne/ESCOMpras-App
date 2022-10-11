using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class Imagen : ContentPage
{
    public IList<Icon> Imagenes { get; private set; }
    public Imagen()
    {
        InitializeComponent();
        Imagenes = new List<Icon>();
        loadIcons();
    }

    private void loadIcons()
    {
        Imagenes.Add(new Icon()
        {
            Id = "01-Black",
            Name = "Dinosaurio",
            Url = "https://chasingdaisiesblog.com/wp-content/uploads/2020/10/a3ed944924f1e72a15dc797a698839a3.jpg"
        });
        Imagenes.Add(new Icon()
        {
            Id = "02-Purple",
            Name = "Gatito",
            Url = "https://wallpapers.com/images/featured/8k436w42fxqrt0xb.jpg"
        });
        Imagenes.Add(new Icon()
        {
            Id = "03-Blue",
            Name = "Cielo",
            Url = "https://i.pinimg.com/originals/e9/f5/10/e9f510a68cd5f8889ab16a76f464ff2b.png"
        });
        Imagenes.Add(new Icon()
        {
            Id = "04-Pink",
            Name = "Playa rosita",
            Url = "https://image.winudf.com/v2/image1/Y29tLkFlc3RoZXRpYy5HaXJseS53YWxscGFwZXJfc2NyZWVuXzFfMTYyNTk1MzAzMF8wMTY/screen-1.jpg?fakeurl=1&type=.webp"
        });
        Imagenes.Add(new Icon()
        {
            Id = "05-Purple",
            Name = "Pide un deseo",
            Url = "https://thevioletjournal.com/wp-content/uploads/2022/01/night-sky-dark-wallpaper.jpg"
        });
        Imagenes.Add(new Icon()
        {
            Id = "06-Green",
            Name = "Corazoncitos",
            Url = "https://data.whicdn.com/images/356677685/original.jpg"
        });
        Imagenes.Add(new Icon()
        {
            Id = "07-Red",
            Name = "Eso es un sol?",
            Url = "https://www.enjpg.com/img/2020/red-aesthetic-2.jpg"
        });
        Imagenes.Add(new Icon()
        {
            Id = "00-Default",
            Name = "Hola, Mundo.",
            Url = "https://flyinryanhawks.org/wp-content/uploads/2016/08/profile-placeholder.png"
        });

        BindingContext = this;
    }

    private async void Iconos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Icon icono = e.Item as Icon;
        if (icono != null)
        {
            await Navigation.PushAsync(new IconSelector(icono));
        }
    }
}