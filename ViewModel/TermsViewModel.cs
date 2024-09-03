using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Models;
using LibrandriaMAUI.Services;
using LibrandriaMAUI.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LibrandriaMAUI.ViewModel;

public partial class TermsViewModel : BaseViewModel
{
    private static TermService _termService;
    public TermsViewModel(TermService termService)
    {
        _termService = termService;
    }
    
    // Add or Edit Term Observable Properties
    [ObservableProperty] private string? _name = string.Empty;
    [ObservableProperty] private DateTime _startDate = DateTime.Now;
    [ObservableProperty] private DateTime _endDate = DateTime.Now;
    
    [ObservableProperty] private ObservableCollection<Term>? _terms;

    [RelayCommand]
    private async Task TapTerm(string termId)
    {
        await Shell.Current
            .GoToAsync(nameof(CoursesPage));
    }

    [RelayCommand]
    private async Task TapAdd()
    {
        await Shell.Current.GoToAsync(nameof(AddTermPage));
    }

    [RelayCommand]
    private async Task TapDelete(Term term)
    {
        var answer = await Shell.Current.DisplayAlert(
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
    private async Task TapEdit(Term term)
    {
        _termService.CurrentTerm = term;
        await Shell.Current.GoToAsync(nameof(EditTermPage));
    }

    public async Task OnLoaded()
    {
        Terms = new ObservableCollection<Term>(
            await _termService.GetTermList());
    }
}