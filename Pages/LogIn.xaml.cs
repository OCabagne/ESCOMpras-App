using ESCOMpras.Models;
using test1.Pages;
namespace ESCOMpras.Pages;

public partial class LogIn : ContentPage
{
    public LogIn()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Correo.Text = "OCabagne@outlook.com";
            //Password.Text = "1Contraseña";

            string correo = Correo.Text;
            string password = Password.Text;

            try
            {
                Cliente cliente = await internetEscompras.LogIn(correo, password);

                if (cliente != null)
                {
                    await DisplayAlert("Bienvenido!", $"Bienvenido a ESCOMpras {cliente.Nombre}!", "Iniciemos!");

                    await SecureStorage.Default.SetAsync("Logged", "True");
                    await SecureStorage.Default.SetAsync("idEscuela", cliente.EscuelaIdescuela.ToString());
                    await SecureStorage.Default.SetAsync("idCliente", cliente.Idcliente.ToString());
                    await SecureStorage.Default.SetAsync("tipo", "Cliente");

                    await Navigation.PopAsync();
                    //await Navigation.PushModalAsync(new HomePage());
                }
            }
            catch
            {
                Tiendum tienda = await internetEscompras.LogInTienda(correo, password);
                
                if(tienda != null)
                {
                    await DisplayAlert("Vendedor!", $"Bienvenido a ESCOMpras {tienda.Nombre}!", "Iniciemos!");

                    await SecureStorage.Default.SetAsync("Logged", "True");
                    await SecureStorage.Default.SetAsync("idTienda", tienda.Idtienda.ToString());
                    await SecureStorage.Default.SetAsync("tipo", "Tienda");

                    await Navigation.PopAsync();
                    //await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("", ex.Message, "OK");
        }
    }

    private async void crearCuentaBtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CrearCuenta());
    }
}