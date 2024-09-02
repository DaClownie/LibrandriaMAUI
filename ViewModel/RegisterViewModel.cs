using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Services;
using LibrandriaMAUI.Pages;

namespace LibrandriaMAUI.ViewModel;

public partial class RegisterViewModel(UserService userService) : BaseViewModel
{
    [ObservableProperty]
    string? _username;
    [ObservableProperty]
    string? _password;
    [ObservableProperty]
    string? _email;
    
    [RelayCommand]
    async Task TapBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    
    [RelayCommand]
    async Task TapSubmit()
    {
        if (!(string.IsNullOrEmpty(Username) ||
              string.IsNullOrEmpty(Password) || 
              string.IsNullOrEmpty(Email)))
        {
            await userService.AddUser(Username, Password, Email);
            await Shell.Current.GoToAsync(nameof(LoginPage));
        }
    }
}