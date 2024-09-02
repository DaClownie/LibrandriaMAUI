using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage(RegisterViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}