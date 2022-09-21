using MonkeyCache.FileStore;
namespace test1;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Barrel.ApplicationId = AppInfo.PackageName;
		//MainPage = new AppShell();
	}
}
