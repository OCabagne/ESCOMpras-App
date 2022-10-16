using ESCOMpras.Models;

namespace test1.Pages;

public partial class PedidoFinalizado : ContentPage
{
    public int idOrden { get; set; }
	public PedidoFinalizado()
	{
		InitializeComponent();
	}

    public PedidoFinalizado(int Orden)
    {
        InitializeComponent();
        idOrden = Orden;
        loadName();
        BindingContext = this;
    }

    private async void loadName()
    {
        int idCliente = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente"));
        nombreCliente.Text = await internetEscompras.GetNombreCliente(idCliente);
    }

    private async void regresarBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}