using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}