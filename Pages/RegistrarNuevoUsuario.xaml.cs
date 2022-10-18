using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class RegistrarNuevoUsuario : ContentPage
{
    private IList<Escuela> escuelas;
    public RegistrarNuevoUsuario()
	{
		InitializeComponent();
	}

    public RegistrarNuevoUsuario(Cliente _cliente)
    {
        InitializeComponent();
        BindingContext = _cliente;
        obtenerEscuelas();
        versionCliente.IsVisible = true;
        versionVendedor.IsVisible = false;
    }

    public RegistrarNuevoUsuario(Tiendum _vendedor)
    {
        InitializeComponent();
        BindingContext = _vendedor;
        versionVendedor.IsVisible = true;
        versionCliente.IsVisible = false;
    }
    private async void obtenerEscuelas()
    {
        escuelas = new List<Escuela>();
        escuelas = await internetEscompras.getEscuelas();
        var escuelasList = new List<string>();

        foreach (var esc in escuelas)
        {
            escuelasList.Add(esc.Nombre);
        }

        selectEscuela.ItemsSource = escuelasList;
    }

    private async void RegistrarCliente_Clicked(object sender, EventArgs e)
    {
        if(selectEscuela.SelectedItem != null && Nombre.Text != null && Apellido.Text != null &&
            Correo.Text != null && Password.Text != null && ConfirmarPassword.Text != null && ConfirmarPassword.Text.Equals(Password.Text)
            && aceptoTerminos.IsChecked == true)
        {
            await DisplayAlert("Bienvenido!", "Campos completos", "Excelentuqui!");
        }
        else
        {
            await DisplayAlert("Error", "Favor de completar todos los campos.", "Ok");
        }
    }

    private async void RegistrarVendedor_Clicked(object sender, EventArgs e)
    {
        if (selectTipo.SelectedItem != null && NombreVendedor.Text != null &&
            CorreoVendedor.Text != null && PasswordVendedor.Text != null && 
            ConfirmarPasswordVendedor.Text != null && ConfirmarPasswordVendedor.Text.Equals(PasswordVendedor.Text) 
            && aceptoTerminosVendedor.IsChecked == true)
        {
            await DisplayAlert("Bienvenido!", "Campos completos", "Comencemos!");
        }
        else
        {
            await DisplayAlert("Error", "Favor de completar todos los campos.", "Ok");
        }
    }
}