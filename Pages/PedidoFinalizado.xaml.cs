namespace test1.Pages;

public partial class PedidoFinalizado : ContentPage
{
    public int idOrden { get; set; }
	public PedidoFinalizado()
	{
		InitializeComponent();
	}

    public PedidoFinalizado(int Orden)
    {
        InitializeComponent();
        idOrden = Orden;
        BindingContext = this;
    }
}