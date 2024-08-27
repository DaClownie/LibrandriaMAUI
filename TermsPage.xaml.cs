using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI;

public partial class TermsPage : ContentPage
{
    private readonly TermsViewModel _termsViewModel;
    public TermsPage(TermsViewModel vm)
    {
        InitializeComponent();
        _termsViewModel = vm;
        Loaded += ContentPage_Loaded;
        BindingContext = _termsViewModel;
    }

    private async void ContentPage_Loaded(object? sender, EventArgs e)
    {
        await _termsViewModel.OnLoaded();
    }
}