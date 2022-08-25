namespace test1.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
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