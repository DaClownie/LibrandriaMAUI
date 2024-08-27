using CommunityToolkit.Mvvm.Input;

namespace LibrandriaMAUI.ViewModel;

public partial class MainViewModel : BaseViewModel
{
    [RelayCommand]
    async Task TapLogin()
    {
        await Shell.Current.GoToAsync(nameof(LoginPage));
    }

    [RelayCommand]
    async Task TapRegister()
    {
        await Shell.Current.GoToAsync(nameof(RegisterPage));
    }
}