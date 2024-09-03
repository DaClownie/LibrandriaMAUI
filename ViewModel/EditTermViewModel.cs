using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Models;
using LibrandriaMAUI.Services;

namespace LibrandriaMAUI.ViewModel;

public partial class EditTermViewModel : BaseViewModel
{
    private static TermService _termService;

    public EditTermViewModel(TermService termService)
    {
        _termService = termService;
    }

    private static Term _term = _termService.CurrentTerm;
    [ObservableProperty] private string? _name = _term.Name;
    [ObservableProperty] private DateTime _startDate = _term.StartDate;
    [ObservableProperty] private DateTime _endDate = _term.EndDate;
    
    [RelayCommand]
    private async Task TapSave()
    {
        //TODO add null check logic
        _term.Name = Name;
        _term.StartDate = StartDate;
        _term.EndDate = EndDate;
        await _termService.EditTerm(_term);
        await Shell.Current.GoToAsync("..");
    }
}