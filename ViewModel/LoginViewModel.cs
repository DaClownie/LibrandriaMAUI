using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Services;
using LibrandriaMAUI.Pages;

namespace LibrandriaMAUI.ViewModel;

public partial class LoginViewModel(UserService userService) : BaseViewModel
{
    [ObservableProperty]
    private string? _username;
    
    [ObservableProperty]
    private string? _password;
    
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
            await userService.GetUser(Username, Password);
            await Shell.Current.GoToAsync(nameof(LoadingPage));
        }
    }
}