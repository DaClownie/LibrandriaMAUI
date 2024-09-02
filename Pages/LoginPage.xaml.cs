using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}