using CommunityToolkit.Mvvm.ComponentModel;
using N4RNACSite.Navigation;

namespace N4RNACSite.ViewModels;

/// <summary>
/// The main view: which page is shown. The navigation's selected key and the page host's Page are bound to it, so
/// navigating from code is setting <see cref="SelectedKey"/>.
/// </summary>
public sealed partial class MainViewModel : ObservableObject
{
    [ObservableProperty] private string? _selectedKey;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(Title))]
    private AppPage? _currentPage;

    public MainViewModel()
    {
        SelectedKey = AppPages.Home;
    }

    /// <summary>The shown page's title, for the top bar.</summary>
    public string? Title => CurrentPage?.Title;

    partial void OnSelectedKeyChanged(string? value)
    {
        // A key that names no page (a row without one) keeps the current page.
        if (AppPages.Find(value) is { } page)
        {
            CurrentPage = page;
        }
    }
}