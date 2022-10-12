using ESCOMpras.Models;
using ESCOMpras.Pages;
using System.Runtime.CompilerServices;

namespace test1.Pages;

public partial class ProfilePage : ContentPage
{
    public ClienteVM cliente { get; private set; }
    public Tiendum Vendedor { get; private set; }

    private int Id;
    private string tipo;
    public ProfilePage()
    {
        InitializeComponent();

        Login();
    }

    private async void Login()
    {
        try
        {
            tipo = await SecureStorage.Default.GetAsync("tipo");
            if(tipo.Equals("Cliente"))
            {
                versionTienda.IsVisible = false;
                versionCliente.IsVisible = true;

                Id = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente"));
                Cliente Cliente = await internetEscompras.GetCliente(Id);
                cliente = new ClienteVM(Cliente.Idcliente, Cliente.Calificacion, Cliente.Nombre, Cliente.Apellidos, Cliente.Correo, Cliente.Password, Cliente.EscuelaIdescuela);
                cliente.Url = await SecureStorage.Default.GetAsync("Icon");

                EscuelaNombre.Text = await internetEscompras.GetNombreEscuela(cliente.EscuelaIdescuela);

                BindingContext = cliente;
            }
            else if(tipo.Equals("Tienda"))
            {
                versionTienda.IsVisible = true;
                versionCliente.IsVisible = false;
                Id = Int32.Parse(await SecureStorage.Default.GetAsync("idTienda"));
                Vendedor = await internetEscompras.GetTienda(Id);
                Vendedor.Imagen = await SecureStorage.Default.GetAsync("Icon");

                BindingContext = Vendedor;
            }

        }
        catch
        {
            await DisplayAlert("No iniciaste sesión!", "Inicia sesión para poder ver tus datos.", "Entendido");
            await Navigation.PushAsync(new LogIn());
            string logged = await SecureStorage.Default.GetAsync("Logged");
            if (logged.Equals("True"))
                Login();
        }
    }

    private void AnterioresBtn_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("pedidosAnteriores");
    }

    private async void Informacion_Clicked(object sender, EventArgs e)
    {
        if (tipo.Equals("Cliente"))
            await Navigation.PushAsync(new Info(cliente));

        else if (tipo.Equals("Tienda"))
            await Navigation.PushAsync(new Info(Vendedor));
        //Shell.Current.GoToAsync("Informacion");
    }

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        Login();
        refreshView.IsRefreshing = false;
    }

    private async void logOut_Clicked(object sender, EventArgs e)
    {
        await SecureStorage.Default.SetAsync("Logged", "False");
        await SecureStorage.Default.SetAsync("idEscuela", "1");
        await SecureStorage.Default.SetAsync("idCliente", "0");
        await SecureStorage.Default.SetAsync("tipo", "Cliente");

        await Navigation.PushAsync(new LogIn());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}