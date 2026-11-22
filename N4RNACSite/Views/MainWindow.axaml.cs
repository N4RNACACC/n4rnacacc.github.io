using Avalonia.Controls;
using N4RNACSite.Settings;

namespace N4RNACSite.Views;

/// <summary>The desktop window around <see cref="MainView"/>.</summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Opens where it was last closed, at the same size, and remembers the placement when it closes.
        AppSettings.Current.TrackWindow(this);
    }
}