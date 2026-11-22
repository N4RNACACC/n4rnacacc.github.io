using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using N4RNACSite.Settings;
using N4RNACSite.ViewModels;
using N4RNACSite.Views;

namespace N4RNACSite;

/// <summary>
/// The application. Arc needs nothing here: no base class, no App.axaml and no styles. UseArcApp() (AppSetup.cs)
/// registers the themes, and Arc's base theme styles the window and the Avalonia controls Arc's templates use.
/// </summary>
public class App : Application
{
    public override void OnFrameworkInitializationCompleted()
    {
        // Every theme change (the top bar's switch, the Settings page, your own ArcTheme.Apply calls) is saved.
        AppSettings.Current.TrackTheme();
        switch (ApplicationLifetime)
        {
            // A desktop window.
            case IClassicDesktopStyleApplicationLifetime desktop:
                desktop.MainWindow = new MainWindow { DataContext = CreateMainViewModel() };
                break;
            // A browser page or a phone screen: the content without a window.
            case ISingleViewApplicationLifetime singleView:
                singleView.MainView = new MainView { DataContext = CreateMainViewModel() };
                break;
        }

        base.OnFrameworkInitializationCompleted();
    }

    private static MainViewModel CreateMainViewModel() => new();
}