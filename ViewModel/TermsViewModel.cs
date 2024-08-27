using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Models;
using LibrandriaMAUI.Services;

namespace LibrandriaMAUI.ViewModel;

public partial class TermsViewModel : BaseViewModel
{
    private static TermService _termService;
    public TermsViewModel(TermService termService)
    {
        _termService = termService;
    }

    [ObservableProperty] 
    private ObservableCollection<Term> _terms;

    [RelayCommand]
    private async Task TapTerm(string termId)
    {
        await Shell.Current
            .GoToAsync($"{nameof(CoursesPage)}?TermId={termId}");
    }

    [RelayCommand]
    private async Task TapAdd()
    {
        //TODO Possibly a flyout? Maybe another page?
    }

    [RelayCommand]
    private async Task TapDelete(Term term)
    {
        bool answer = await App.Current.MainPage.DisplayAlert(
            "Delete confirmation",
            "Are you sure you want to delete the term? This operation is not reversible",
            "OK", "Cancel");
        if (answer)
        {
            await _termService.DeleteTerm(term);
            Terms.Remove(term);
        }
        //TODO Handle Delete logic, need a confirmation popup, cascading deletes
        //of all courses/assessments. Keep instructors.
    }

    [RelayCommand]
    private async Task TapEdit(string termId)
    {
        //TODO Handle edit logic, possibly a flyout like Add? What's a flyout?
    }

    public async Task OnLoaded()
    {
        Terms = new ObservableCollection<Term>(
            await _termService.GetTermList());
    }
}