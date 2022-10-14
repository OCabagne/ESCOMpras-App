using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class AgregarProducto : ContentPage
{
    public AgregarProducto()
    {
        InitializeComponent();
    }

    private async void guardarProducto_Clicked(object sender, EventArgs e)
    {
        if (nombreProducto.Text == null || descripcionProducto.Text == null ||
            precioProducto.Text == null || cantidadProducto.Text == null)
        {
            await DisplayAlert("Campo vacío", "Por favor, no omitas ningún dato.", "Ok");
        }
        else
        {
            ProductoVM _producto = new ProductoVM {
                Cantidad = Int32.Parse(cantidadProducto.Text),
                Descripcion = descripcionProducto.Text,
                Nombre = nombreProducto.Text,
                Precio = Int32.Parse(precioProducto.Text),
                TiendaIdtienda = Int32.Parse(await SecureStorage.Default.GetAsync("idTienda"))
            };

            await internetEscompras.NuevoProducto(_producto);
            await DisplayAlert("", _producto.Nombre + " ha sido guardado!", "Entendido!");
            await Navigation.PopToRootAsync();
        }

    }
}