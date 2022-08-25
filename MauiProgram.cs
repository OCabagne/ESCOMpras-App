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
			});

		Routing.RegisterRoute("Favoritos", typeof(Favoritos));
        Routing.RegisterRoute("pedidosAnteriores", typeof(PedidosAnteriores));
        Routing.RegisterRoute("Informacion", typeof(Info));

        return builder.Build();
	}
}
