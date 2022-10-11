using ESCOMpras.Models;
using ESCOMpras.Pages;

namespace test1.Pages;

public partial class ProfilePage : ContentPage
{
    public ClienteVM cliente { get; private set; }
    private int idCliente;
    public ProfilePage()
    {
        InitializeComponent();

        Login();
    }

    private async void Login()
    {
        try
        {
            idCliente = Int32.Parse(await SecureStorage.Default.GetAsync("idCliente"));
            Cliente Cliente = await internetEscompras.GetCliente(idCliente);
            cliente = new ClienteVM(Cliente.Idcliente, Cliente.Calificacion, Cliente.Nombre, Cliente.Apellidos, Cliente.Correo, Cliente.Password, Cliente.EscuelaIdescuela);
            cliente.Url = await SecureStorage.Default.GetAsync("Icon");

            EscuelaNombre.Text = await internetEscompras.GetNombreEscuela(cliente.EscuelaIdescuela);

            BindingContext = cliente;
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
        await Navigation.PushAsync(new Info(cliente));
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
}