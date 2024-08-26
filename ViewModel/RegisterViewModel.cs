using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LibrandriaMAUI.Data;

namespace LibrandriaMAUI.ViewModel;

public partial class RegisterViewModel : ObservableObject
{
    [ObservableProperty]
    private string username;
    [ObservableProperty]
    private string password;
    [ObservableProperty]
    private string email;
    
    [RelayCommand]
    async Task TapBack()
    {
        await Shell.Current.GoToAsync("..");
    }
    
    [RelayCommand]
    async Task TapSubmit()
    {
        await SQLFunctions.AddNewUser(username, password, email);
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }
}