using ESCOMpras.Models;
namespace ESCOMpras.Pages;

public partial class PendientesPage : ContentPage
{
    private PedidoPendiente seleccion { get; set; }
    string tipo;
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

        LoadData();
        this.BindingContext = seleccion;
    }

    private async void LoadData()
    {
        // Load buttons for different Estados and by type of user.
        tipo = await SecureStorage.Default.GetAsync("tipo");

        if (tipo.Equals("Tienda"))
        {
            switch (seleccion.Estado)
            {
                case "SOLICITADO":
                    AceptarOrden.IsVisible = true;
                    RechazarOrden.IsVisible = true;
                    reportarProblema.IsVisible = false;
                    break;

                case "APROBADO":
                    EnviarOrden.IsVisible = true;
                    break;

                case "ENVIADO":
                    finalizarOrden.IsVisible = true;
                    IngresarClave.IsVisible = true;
                    break;

                case null:
                    AceptarOrden.IsVisible = true;
                    RechazarOrden.IsVisible = true;
                    reportarProblema.IsVisible = false;
                    break;
                default: // CANCELADO, RECHAZADO Y RECIBIDO
                    break;

            }
        }
        else if (tipo.Equals("Cliente"))
        {
            switch (seleccion.Estado)
            {
                case "SOLICITADO":
                    CancelarOrden.IsVisible = true;
                    break;

                case "APROBADO":
                    CancelarOrden.IsVisible = true;
                    break;

                case "ENVIADO":
                    finalizarOrden.IsVisible = true;
                    break;

                case null:
                    CancelarOrden.IsVisible = true;
                    break;

                default: // CANCELADO, RECHAZADO Y RECIBIDO 
                    break;
            }
        }
    }

    private void reportarProblema_Clicked(object sender, EventArgs e)
    {
        try
        {

        }
        catch { }
    }

    private async void finalizarOrden_Clicked(object sender, EventArgs e)
    {
        if (tipo.Equals("Cliente"))
        {
            // Generar Clave de Finalización
            try
            {
                if (await internetEscompras.GenerarClave(seleccion.Idorden))
                {
                    string clave = await internetEscompras.GetClave(seleccion.Idorden);
                    await DisplayAlert("", "Tu clave es: " + clave, "Aceptar");
                    await Navigation.PopToRootAsync();
                }
            }
            catch
            {
                await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
            }
        }
        else if (tipo.Equals("Tienda"))
        {
            // Confirmar Clave de Finalización
            try
            {
                if (await internetEscompras.ConfirmarClave(seleccion.Idorden, Clave.Text))
                {
                    internetEscompras.FinalizarOrden(seleccion.Idorden);
                    await DisplayAlert("", "Orden finalizada!", "Muy bien!");
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("", "Clave incorrecta.", "Entendido");
                }
            }
            catch
            {
                await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
            }
        }
    }

    private async void CancelarOrden_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("", "¿Estás seguro de cancelar tu pedido?", "Si Autorizo", "No"))
        {
            try
            {
                internetEscompras.CancelarOrden(seleccion.Idorden);
                await DisplayAlert("", "Tu orden ha sido cancelada.", "Entendido");
                await Navigation.PopToRootAsync();
            }
            catch
            {
                await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
            }
        }
    }

    private async void EnviarOrden_Clicked(object sender, EventArgs e)
    {
        try
        {
            internetEscompras.EnviarOrden(seleccion.Idorden);
            await DisplayAlert("", "Orden Enviada", "Muy bien!");
            await Navigation.PopToRootAsync();
        }
        catch
        {
            await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
        }
    }

    private async void AceptarOrden_Clicked(object sender, EventArgs e)
    {
        try
        {
            internetEscompras.AceptarOrden(seleccion.Idorden);
            await DisplayAlert("", "Orden Aceptada", "Muy bien!");
            await Navigation.PopToRootAsync();
        }
        catch
        {
            await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
        }
    }

    private async void RechazarOrden_Clicked(object sender, EventArgs e)
    {
        if (await DisplayAlert("", "¿Estás seguro de querer rechazar esta orden?", "Si", "No"))
        {
            try
            {
                internetEscompras.RechazarOrden(seleccion.Idorden);
                await DisplayAlert("", "Orden Rechazada", "Entendido");
                await Navigation.PopToRootAsync();
            }
            catch
            {
                await DisplayAlert("", "Ha ocurrido un error.", "Entendido");
            }
        }
    }
}