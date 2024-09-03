using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Models;
using LibrandriaMAUI.Services;

namespace LibrandriaMAUI.ViewModel;

public partial class AddTermViewModel : BaseViewModel
{
    private static TermService _termService;
    private static UserService _userService;

    public AddTermViewModel(TermService termService, UserService userService)
    {
        _termService = termService;
        _userService = userService;
    }

    [ObservableProperty] private string? _name = string.Empty;
    [ObservableProperty] private DateTime _startDate = DateTime.Now;
    [ObservableProperty] private DateTime _endDate = DateTime.Now.AddMonths(6).AddDays(-1);

    [RelayCommand]
    private async Task TapSave()
    {
        //TODO add null check logic
        var term = new Term(Name, StartDate, EndDate,
            _userService.CurrentUser.IdText)
        {
            Name = Name,
            StartDate = StartDate,
            EndDate = EndDate
        };
        await _termService.AddTerm(term);
        await Shell.Current.GoToAsync("..");
    }
}