using ESCOMpras.Models;

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
            string correo = Correo.Text;
            string password = Password.Text;
            Cliente cliente = await internetEscompras.LogIn(correo, password);
            //Cliente cliente = await internetEscompras.GetCliente(38);
            if (cliente != null)
            {
                await DisplayAlert("Bienvenido!", $"Bienvenido a ESCOMpras {cliente.Nombre}!", "Iniciemos!");
                await SecureStorage.Default.SetAsync("Logged", "True");
                await this.Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("", "Correo o contraseña incorrectos.", "OK");
        }
    }
}