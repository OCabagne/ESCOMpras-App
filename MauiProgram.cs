using ESCOMpras.Pages;
using test1.Pages;

namespace test1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("fa-solid-900.ttf", "FAS");
			});

		Routing.RegisterRoute("Favoritos", typeof(Favoritos));
        Routing.RegisterRoute("pedidosAnteriores", typeof(PedidosAnteriores));
        Routing.RegisterRoute("Informacion", typeof(Info));
		Routing.RegisterRoute("Detalles", typeof(DetailsPage));
        Routing.RegisterRoute("Carrito", typeof(Carrito));
		Routing.RegisterRoute("Login", typeof(LogIn));

        return builder.Build();
	}
}
