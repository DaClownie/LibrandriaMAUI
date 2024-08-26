using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Data;
using LibrandriaMAUI.Models;

namespace LibrandriaMAUI.ViewModel;

public partial class TermsViewModel : ObservableObject
{
    public TermsViewModel()
    {
        Terms = new ObservableCollection<Term>();
    }
    
    [ObservableProperty]
    ObservableCollection<Term> terms;

    [RelayCommand]
    async Task TapTerm(string termId)
    {
        await Shell.Current
            .GoToAsync($"{nameof(CoursesPage)}?TermId={termId}");
    }

    [RelayCommand]
    async Task TapAdd()
    {
        //TODO Possibly a flyout? Maybe another page?
    }

    [RelayCommand]
    async Task TapDelete(string termId)
    {
        //TODO Handle Delete logic, need a confirmation popup, cascading deletes
        //of all courses/assessments. Keep instructors.
    }

    [RelayCommand]
    async Task TapEdit(string termId)
    {
        //TODO Handle edit logic, possibly a flyout like Add? What's a flyout?
    }
}