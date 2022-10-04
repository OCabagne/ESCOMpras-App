using Android.App;
using Android.Content.PM;
using Android.OS;

namespace test1;

[Activity(Theme = "@style/Maui.ESCOMprasSplash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}
