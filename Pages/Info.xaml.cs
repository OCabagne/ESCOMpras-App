using ESCOMpras.Models;

namespace test1.Pages;

public partial class Info : ContentPage
{
    ClienteVM Cliente;
	public Info()
	{
		InitializeComponent();
	}

    public Info(ClienteVM cliente)
    {
        InitializeComponent();
        Cliente = cliente;
        BindingContext = Cliente;
    }

    private void SaveChanges_Clicked(object sender, EventArgs e)
    {
        try
        {
            Cliente.Nombre = Nombre.Text;
            internetEscompras.UpdateCliente(Cliente);
            DisplayAlert("","Datos actualizados correctamente.","Ok");
            this.Navigation.PopAsync();
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex);
            DisplayAlert("Error", ex.Message, "Ok");
        }
    }
}