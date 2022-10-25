using ESCOMpras.Models;

namespace test1.Pages;

public partial class SearchPage : ContentPage
{
    public IList<Producto> Productos { get; private set; }
    public IList<Tipo> Tipos { get; private set; }
    public SearchPage()
    {
        InitializeComponent();

        buscarProductos.IsVisible = false;
        tiposProductos.IsVisible = true;

        Productos = new List<Producto>();
        Tipos = new List<Tipo>();
        Tipos.Add(new Tipo
        {
            Idtipo = 1,
            Nombre = "Electrónica",
            Imagen = "https://upload.wikimedia.org/wikipedia/commons/9/96/Protoboard_circuito_multivibradores.jpg"
        });
        Tipos.Add(new Tipo
        {
            Idtipo = 2,
            Nombre = "Alimento",
            Imagen = "https://www.unotv.com/uploads/2022/08/lunch-saludable-102132.jpg"
        });
        Tipos.Add(new Tipo
        {
            Idtipo = 3,
            Nombre = "Papelería",
            Imagen = "https://economia.org/anexo/Papeleria.jpg"
        });

        tipos.ItemsSource = Tipos;
        //obtenerProductos();
    }

    private async void obtenerProductos()
    {
        string tipo = await SecureStorage.Default.GetAsync("tipo");
        if (tipo.Equals("Cliente"))
        {
            int idEscuela = Int32.Parse(await SecureStorage.Default.GetAsync("idEscuela"));
            Productos = await internetEscompras.GetProductos(idEscuela);    // id para ESCOM = 1
        }
        else if (tipo.Equals("Tienda"))
        {
            int idTienda = Int32.Parse(await SecureStorage.Default.GetAsync("idTienda"));
            Productos = await internetEscompras.GetProductosByTienda(idTienda);
        }

        if (Productos.Count == 0)
        {
            sinProductos.IsVisible = true;
            RecargarBtn.IsVisible = true;
            //conProductos.IsVisible = false;
        }
        else
        {
            sinProductos.IsVisible = false;
            RecargarBtn.IsVisible = false;
            //conProductos.IsVisible = true;

            foreach (var item in Productos)
            {
                //item.Imagen = "https://www.memecreator.org/static/images/memes/4845128.jpg";
                item.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
            }

            BindingContext = this;
        }
    }

    private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        Producto selectedItem = e.SelectedItem as Producto;
    }

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Producto publicacion = e.Item as Producto;
        if (publicacion != null)
        {
            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
    }

    private void RecargarBtn_Clicked(object sender, EventArgs e)
    {
        obtenerProductos();
    }

    private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            if (searchBar.Text != "")
            {
                Productos = await internetEscompras.SearchProducto(searchBar.Text);
                if (Productos.Count != 0)
                {
                    buscarProductos.IsVisible = true;
                    tiposProductos.IsVisible = false;
                    foreach (var item in Productos)
                    {
                        item.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
                    }
                    searchResults.ItemsSource = Productos;
                }
                else
                {
                    buscarProductos.IsVisible = false;
                    tiposProductos.IsVisible = true;
                }
            }
            else
            {
                buscarProductos.IsVisible = false;
                tiposProductos.IsVisible = true;
            }

        }
        catch { }
    }

    private async void tipos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Tipo _tipo = e.Item as Tipo;
        if(_tipo != null)
        {
            await Navigation.PushAsync(new TiposPage(_tipo));
        }
    }
}