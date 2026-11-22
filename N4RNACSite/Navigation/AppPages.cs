using Avalonia.Controls;
using N4RNACSite.Pages;
using N4RNACSite.ViewModels;

namespace N4RNACSite.Navigation;

/// <summary>One page of the app: a stable key (what the navigation selects by), the title the top bar shows and how to create the view.</summary>
public sealed record AppPage(string Key, string Title, Func<Control> Create);

/// <summary>
/// The pages of the app. The navigation (the sidebar in Views/MainView.axaml) names them by <see cref="AppPage.Key"/>;
/// to add a page, create its view in Pages/ (dotnet new tkcode-arc-page), add it here and add a row with the same key to
/// the navigation.
/// Each entry also pairs the view with its view model: written out here, not looked up by type name, so the app has no
/// reflection and can be trimmed.
/// </summary>
public static class AppPages
{
    public const string Home = "home";
    public const string Projects = "projects";
    public const string Settings = "settings";

    public static IReadOnlyList<AppPage> All { get; } =
    [
        new(Home, "首页", () => new HomePage()),
        new(Projects, "项目", () => new ProjectsPage { DataContext = new ProjectsPageViewModel() }),
    ];

    public static AppPage? Find(string? key)
    {
        foreach (var page in All)
        {
            if (page.Key == key)
            {
                return page;
            }
        }

        return null;
    }
}