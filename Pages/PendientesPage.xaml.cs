using ESCOMpras.Models;
namespace ESCOMpras.Pages;

public partial class PendientesPage : ContentPage
{
	private PedidoPendiente seleccion { get; set; }
	public PendientesPage()
	{
		InitializeComponent();
	}

	public PendientesPage(PedidoPendiente publicacion)
	{
        InitializeComponent();
		seleccion = publicacion;
		this.BindingContext = seleccion;
    }

	private void reportarProblema_Clicked(object sender, EventArgs e)
	{

    }
}