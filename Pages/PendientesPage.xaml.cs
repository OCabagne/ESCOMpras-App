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
        try
        {
            if (publicacion.Promocion.Equals(""))
            {
                promocionTexto.IsVisible = false;
                promocionValor.IsVisible = false;
            }
        }
        catch
        {
            promocionTexto.IsVisible = false;
            promocionValor.IsVisible = false;
        }
        seleccion = publicacion;
        this.BindingContext = seleccion;
    }

    private void reportarProblema_Clicked(object sender, EventArgs e)
    {

    }

    private void finalizarOrden_Clicked(object sender, EventArgs e)
    {

    }
}