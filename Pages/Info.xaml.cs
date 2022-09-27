using ESCOMpras.Models;

namespace test1.Pages;

public partial class Info : ContentPage
{
    ClienteVM Cliente;
    private IList<Escuela> escuelas;
    public Info()
    {
        InitializeComponent();
    }

    public Info(ClienteVM cliente)
    {
        InitializeComponent();
        Cliente = cliente;
        BindingContext = Cliente;
        obtenerEscuelas();
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

    private void SaveChanges_Clicked(object sender, EventArgs e)
    {
        bool flag;
        try
        {
            flag = true;
            if (Nombre.Text != string.Empty) Cliente.Nombre = Nombre.Text;
            if (Apellido.Text != string.Empty) Cliente.Apellidos = Apellido.Text;
            if (Correo.Text != string.Empty) Cliente.Correo = Correo.Text;
            if (Password.Text != null)
            {
                if (Password.Text.Equals(ConfirmarPassword.Text))
                {
                    Cliente.Password = Password.Text;
                    flag = true;
                }
                else
                {
                    flag = false;
                    DisplayAlert("", "Las contraseñas no coinciden.", "Ok");
                }
            }
            if (!selectEscuela.SelectedItem.Equals(Cliente.nombreEscuela))
            {
                Cliente.EscuelaIdescuela = escuelas[selectEscuela.SelectedIndex].Idescuela;
            }

            if (flag)
            {
                internetEscompras.UpdateCliente(Cliente);
                DisplayAlert("", "Datos actualizados correctamente.", "Ok");
                this.Navigation.PopAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            DisplayAlert("Error", ex.Message, "Ok");
        }
    }
}