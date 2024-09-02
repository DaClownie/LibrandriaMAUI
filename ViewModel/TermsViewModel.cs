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
    private static UserService _userService;
    private static LibDbService _libDbService;
    public TermsViewModel(TermService termService, UserService userService, 
        LibDbService libDbService)
    {
        _termService = termService;
        _userService = userService;
        _libDbService = libDbService;
    }
    
    // Add or Edit Term Observable Properties
    [ObservableProperty] private string? _name;
    [ObservableProperty] private DateTime _startDate;
    [ObservableProperty] private DateTime _endDate;
    
    [ObservableProperty] private ObservableCollection<Term>? _terms;

    [RelayCommand]
    private async Task TapTerm(string termId)
    {
        await Shell.Current
            .GoToAsync($"{nameof(CoursesPage)}?TermId={termId}");
    }

    [RelayCommand]
    private async Task TapAdd()
    {
        await Shell.Current.GoToAsync(nameof(AddTermPage));
    }

    [RelayCommand]
    private async Task TapSave()
    {
        await _libDbService.AddTerm(Name, StartDate, EndDate, _userService.CurrentUser.IdText);
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task TapDelete(Term term)
    {
        bool answer = await Shell.Current.DisplayAlert(
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