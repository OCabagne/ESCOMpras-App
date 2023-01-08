using ESCOMpras.Models;

namespace test1.Pages;

public partial class TiposPage : ContentPage
{
    public IList<Producto> Productos { get; private set; }
    public Tipo tipo { get; set; }
	public TiposPage()
	{
		InitializeComponent();
	}

    public TiposPage(Tipo _Tipo)
    {
        InitializeComponent();
        tipo = _Tipo;
        nombreTipo.Text = tipo.Nombre;
        loadProducts();
    }

    private async void loadProducts()
    {
        try
        {
            Productos = await internetEscompras.GetProductosTipo(tipo.Idtipo);
            foreach (var item in Productos)
            {
                if (item.Imagen == null)
                {
                    item.Imagen = "https://www.arraymedical.com/wp-content/uploads/2018/12/product-image-placeholder.jpg";
                }
            }
            BindingContext = this;
        }
        catch { }
    }

    private async void RefreshView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Producto publicacion = e.Item as Producto;
        if (publicacion != null)
        {
            await Navigation.PushAsync(new DetailsPage(publicacion));
        }
    }
}