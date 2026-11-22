using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using N4RNACSite.Models;

namespace N4RNACSite.ViewModels;

/// <summary>The Projects page: the list and the "New project" action.</summary>
public sealed partial class ProjectsPageViewModel : ObservableObject
{
    /// <summary>The rows; an ObservableCollection, so the list shows rows added later without being reset.</summary>
    public ObservableCollection<Project> Projects { get; } = new(SampleProjects.All);

    [RelayCommand]
    private void AddProject() => Projects.Add(SampleProjects.CreateNew(Projects.Count + 1));
}