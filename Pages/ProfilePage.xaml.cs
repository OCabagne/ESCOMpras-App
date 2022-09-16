using ESCOMpras.Models;
namespace test1.Pages;

public partial class ProfilePage : ContentPage
{
    public Cliente Cliente { get; private set; }
    public ProfilePage()
    {
        InitializeComponent();

        Login();

        /*
        User = new Usuario 
		{ 
			Id = 1, 
			Nombre = "Oscar Cabagn�", 
			Escuela = "ESCOM",
			Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/259971623_6626299194110531_4205802413890419082_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=3OShJ0NR2nEAX8-9dS7&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_LSY1pVCnQ9lRxhyy2KhQobvbhFH3wR-gHCsX6_nz3Fw&oe=632965B8"
        };

        this.BindingContext = User;
		*/
    }

    private async void Login()
    {
        Cliente = await internetEscompras.GetCliente(38);
        Cliente.Url = "https://scontent.fmex31-1.fna.fbcdn.net/v/t39.30808-6/259971623_6626299194110531_4205802413890419082_n.jpg?_nc_cat=105&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=3OShJ0NR2nEAX8-9dS7&_nc_ht=scontent.fmex31-1.fna&oh=00_AT_LSY1pVCnQ9lRxhyy2KhQobvbhFH3wR-gHCsX6_nz3Fw&oe=632965B8";
        BindingContext = Cliente;
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