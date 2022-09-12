using Android.Webkit;
using PostgresDBFirst.Models;
using test1.Models;

namespace test1.Pages;

public partial class ProfilePage : ContentPage
{
	//public Usuario User { get; private set; } 
	public Cliente usuario { get; private set; }
	public ProfilePage()
	{
		InitializeComponent();

		usuario = getUser();
        this.BindingContext = usuario;

        /*
        User = new Usuario 
		{ 
			Id = 1, 
			Nombre = "Oscar Cabagné", 
			Escuela = "ESCOM",
			Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/259971623_6626299194110531_4205802413890419082_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=NSbgGJJRoQgAX8TsReT&_nc_ht=scontent.fmex31-1.fna&oh=00_AT-mb9xItwpDpClS9FBqfOsF2355YH-X2Uvu9rDsCT1lDw&oe=630DB638"
        };

        this.BindingContext = User;
		*/
    }

	public async Cliente getUser()
	{
        usuario = new Cliente();
        await usuario.LogIn();
		usuario.Imagen = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/259971623_6626299194110531_4205802413890419082_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=NSbgGJJRoQgAX8TsReT&_nc_ht=scontent.fmex31-1.fna&oh=00_AT-mb9xItwpDpClS9FBqfOsF2355YH-X2Uvu9rDsCT1lDw&oe=630DB638";

        return usuario;
    }

	private void FavoritosBtn_Clicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("Favoritos");
	}

	private void AnterioresBtn_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("pedidosAnteriores");
    }

	private void Informacion_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync("Informacion");
    }
}