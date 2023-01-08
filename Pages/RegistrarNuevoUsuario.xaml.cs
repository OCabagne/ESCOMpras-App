using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class RegistrarNuevoUsuario : ContentPage
{
    private IList<Escuela> escuelas;
    private List<Tipo> tiposTienda;
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
        loadTipos();
    }

    private async void loadTipos()
    {
        try
        {
            tiposTienda = await internetEscompras.GetTiposProducto();
            List<string> tipos = new List<string>();
            foreach (var tipo in tiposTienda)
                tipos.Add(tipo.Nombre);

            selectTipo.ItemsSource = tipos;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No pudimos cargar los tipos de tienda.", "Ok");
        }
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
        if (selectEscuela.SelectedItem != null && Nombre.Text != null && Apellido.Text != null &&
            Correo.Text != null && Password.Text != null && ConfirmarPassword.Text != null && aceptoTerminos.IsChecked == true)
        {
            if (ConfirmarPassword.Text.Equals(Password.Text))
            {
                ClienteHelper cliente = new ClienteHelper
                {
                    Nombre = Nombre.Text,
                    Apellidos = Apellido.Text,
                    Password = Password.Text,
                    Correo = Correo.Text,
                    Calificacion = 5,
                    Activo = true,
                    EscuelaIdescuela = escuelas[selectEscuela.SelectedIndex].Idescuela
                };
                try
                {
                    if (await internetEscompras.SignUp(cliente) > 0)
                    {
                        await DisplayAlert("Bienvenido!", "Campos completos", "Excelente!");
                        await Navigation.PopToRootAsync();
                    }
                    else
                    {
                        throw new InvalidOperationException("Logfile cannot be read-only");
                    }
                }
                catch
                {
                    await DisplayAlert("Error", "Ha ocurrido un error. Volver a intentar.", "Ok");
                }
            }
            else
                await DisplayAlert("", "Las contraseñas no coinciden.", "Entendido");
        }
        else
        {
            await DisplayAlert("Error", "Favor de completar todos los campos.", "Ok");
        }
    }

    private async void RegistrarVendedor_Clicked(object sender, EventArgs e)
    {
        if (selectTipo.SelectedItem != null && NombreVendedor.Text != null &&
            CorreoVendedor.Text != null && PasswordVendedor.Text != null && Ubicacion.Text != null &&
            ConfirmarPasswordVendedor.Text != null && aceptoTerminosVendedor.IsChecked == true)
        {
            if (ConfirmarPasswordVendedor.Text.Equals(PasswordVendedor.Text))
            {
                TiendumHelper tienda = new TiendumHelper
                {
                    Nombre = NombreVendedor.Text,
                    Ubicacion = Ubicacion.Text,
                    Correo = CorreoVendedor.Text,
                    Password = PasswordVendedor.Text,
                    TipoIdtipo = tiposTienda[selectTipo.SelectedIndex].Idtipo
                };
                try
                {
                    await internetEscompras.SignUp(tienda);
                    await DisplayAlert("Bienvenido!", "Campos completos", "Comencemos!");
                    await Navigation.PopToRootAsync();
                }
                catch
                {
                    await DisplayAlert("Error", "Ha ocurrido un error. Volver a intentar.", "Ok");
                }
            }
            else
                await DisplayAlert("", "Las contraseñas no coinciden.", "Entendido");
        }
        else
        {
            await DisplayAlert("Error", "Favor de completar todos los campos.", "Ok");
        }
    }
}