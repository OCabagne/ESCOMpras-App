using ESCOMpras.Models;

namespace ESCOMpras.Pages;

public partial class AgregarProducto : ContentPage
{
    private Producto _prod { get; set; }
    public AgregarProducto()
    {
        InitializeComponent();
        editarProducto.IsVisible = false;
        guardarProducto.IsVisible = true;
    }

    public AgregarProducto(Producto _producto)
    {
        InitializeComponent();
        _prod = _producto;
        nombreProducto.Text = _producto.Nombre;
        descripcionProducto.Text = _producto.Descripcion;
        precioProducto.Text = _producto.Precio.ToString();
        cantidadProducto.Text = _producto.Cantidad.ToString();
        promocion.Text = _producto.Promocion;
        guardarProducto.IsVisible = false;
        idProducto.Text = _prod.Idproducto.ToString();
        BindingContext = _prod;
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
            ProductoVM _producto = new ProductoVM
            {
                Cantidad = Int32.Parse(cantidadProducto.Text),
                Descripcion = descripcionProducto.Text,
                Nombre = nombreProducto.Text,
                Precio = Int32.Parse(precioProducto.Text),
                Promocion = promocion.Text,
                TiendaIdtienda = Int32.Parse(await SecureStorage.Default.GetAsync("idTienda"))
            };

            await internetEscompras.NuevoProducto(_producto);
            await DisplayAlert("", _producto.Nombre + " ha sido guardado!", "Entendido!");
            await Navigation.PopToRootAsync();
        }

    }

    private async void editarProducto_Clicked(object sender, EventArgs e)
    {
        if (nombreProducto.Text == null || descripcionProducto.Text == null ||
            precioProducto.Text == null || cantidadProducto.Text == null)
        {
            await DisplayAlert("", "Por favor, no omitas ningún dato importante.", "Ok");
        }
        else
        {
            if (promocion.Text != null)
                _prod.Promocion = promocion.Text;

            _prod.Nombre = nombreProducto.Text;
            _prod.Descripcion = descripcionProducto.Text;
            _prod.Precio = Int32.Parse(precioProducto.Text);
            _prod.Cantidad = Int32.Parse(cantidadProducto.Text);
            /*
                Producto _producto = new Producto
                {
                    Idproducto = _prod.Idproducto,
                    Cantidad = Int32.Parse(cantidadProducto.Text),
                    Descripcion = descripcionProducto.Text,
                    Nombre = nombreProducto.Text,
                    Precio = Int32.Parse(precioProducto.Text),
                    Promocion = _prod.Promocion,
                    Unidad = _prod.Promocion,
                    TiendaIdtienda = _prod.Promocion
                };
            */
            internetEscompras.UpdateProducto(_prod);
            await DisplayAlert("", "Datos actualizados correctamente.", "Ok");
            await Navigation.PopAsync();
        }
    }
}