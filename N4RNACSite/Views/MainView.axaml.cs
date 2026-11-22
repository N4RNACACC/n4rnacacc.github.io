using Avalonia.Controls;

namespace N4RNACSite.Views;

/// <summary>The app's content: the main window shows it on the desktop, and the page itself in a browser.</summary>
public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        // The page shown follows MainViewModel.SelectedKey, which the page switch's SelectedValue is bound to.
    }
}