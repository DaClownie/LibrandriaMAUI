using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Services;

namespace LibrandriaMAUI.ViewModel;

public partial class LoginViewModel(UserService userService) : BaseViewModel
{
    [ObservableProperty]
    string? _username;
    
    [ObservableProperty]
    string? _password;
    
    [RelayCommand]
    private static async Task TapBack()
    {
        await Shell.Current.GoToAsync("..");
    }

    [RelayCommand]
    private async Task TapSubmit()
    {
        if (!(string.IsNullOrEmpty(Username) || 
              string.IsNullOrEmpty(Password)))
        {
            //TODO change to UserService
            await userService.GetUser(Username, Password);
            if (userService.CurrentUser is not null)
            {
                await Shell.Current.GoToAsync(nameof(TermsPage));
            }
        }
    }
}