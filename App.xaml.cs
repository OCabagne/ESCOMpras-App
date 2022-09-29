using MonkeyCache.FileStore;
namespace test1;
using ESCOMpras.Pages;
using test1.Pages;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		Barrel.ApplicationId = AppInfo.PackageName;
	}
}
