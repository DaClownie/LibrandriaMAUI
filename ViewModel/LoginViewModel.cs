using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Data;

namespace LibrandriaMAUI.ViewModel;

public partial class LoginViewModel : ObservableObject
{
    [ObservableProperty]
    string username;
    
    [ObservableProperty]
    string password;
    
    [RelayCommand]
    async Task TapBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    async Task TapSubmit()
    {
        await SQLFunctions.GetUserId(username, password);
        if (DataObjects.CurrentUser is not null)
        {
            await Shell.Current.GoToAsync(nameof(TermsPage));
        }
    }
}