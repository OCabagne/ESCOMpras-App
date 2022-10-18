using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class CrearCuenta : ContentPage
{
    public CrearCuenta()
    {
        InitializeComponent();
    }

    private async void registroCliente_Clicked(object sender, EventArgs e)
    {
        Cliente _cliente = new Cliente
        {
            Activo = true,
            Calificacion = 5,
            Nombre = "",
            EscuelaIdescuela = 1,
            Apellidos = "",
            Correo = "",
            Password = "",
            Url = await SecureStorage.Default.GetAsync("Icon")
        };

        await Navigation.PushAsync(new RegistrarNuevoUsuario(_cliente));
    }

    private async void registroVendedor_Clicked(object sender, EventArgs e)
    {
        Tiendum _vendedor = new Tiendum
        {
            Nombre = "",
            Ubicacion = "",
            TipoIdtipo = 1,
            Correo = "",
            Password = "",
            Imagen = await SecureStorage.Default.GetAsync("Icon")
        };

        await Navigation.PushAsync(new RegistrarNuevoUsuario(_vendedor));
    }
}