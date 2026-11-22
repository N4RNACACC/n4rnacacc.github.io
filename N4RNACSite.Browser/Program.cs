using Avalonia;
using Avalonia.Browser;
using N4RNACSite.Settings;

namespace N4RNACSite.Browser;

internal static class Program
{
    // "out" is the element of wwwroot/index.html the app draws into.
    private static Task Main(string[] args) => BuildAvaloniaApp().StartBrowserAppAsync("out");

    public static AppBuilder BuildAvaloniaApp()
    {
        // A page has no settings file: keep the preferences in the browser's local storage for this site.
        AppSettings.Store = new BrowserSettingsStore();
        return AppBuilder.Configure<App>()
            .WithCjkFont()
            .UseArcApp();
    }
}