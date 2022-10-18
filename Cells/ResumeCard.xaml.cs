using ESCOMpras.Models;

namespace ESCOMpras.Cells;

public partial class ResumeCard : ContentView
{
	public ResumeCard()
	{
		InitializeComponent();
		Load();
	}

	private async void Load()
	{
        var tipo = await SecureStorage.Default.GetAsync("tipo");
		if(tipo.Equals("Cliente"))
		{
            vendedorInfo.IsVisible = true;
            vendedorNombre.IsVisible = true;
        }
		else if (tipo.Equals("Tienda"))
		{
            clienteInfo.IsVisible = true;
            clienteNombre.IsVisible = true;
        }
    }
}