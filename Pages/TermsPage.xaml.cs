using LibrandriaMAUI.Services;
using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class TermsPage : ContentPage
{
    private readonly TermsViewModel _termsViewModel;
    private readonly UserService _userService;
    public TermsPage(TermsViewModel vm, UserService userService)
    {
        InitializeComponent();
        _userService = userService;
        _termsViewModel = vm;
        Loaded += ContentPage_Loaded;
        BindingContext = _termsViewModel;
    }

    private async void ContentPage_Loaded(object? sender, EventArgs e)
    {
        await _userService.GetUser("user", "pass");
        await _termsViewModel.OnLoaded();
    }
}