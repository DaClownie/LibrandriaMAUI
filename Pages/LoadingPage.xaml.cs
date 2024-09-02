namespace LibrandriaMAUI.Pages;

public partial class LoadingPage : ContentPage
{
    public LoadingPage()
    {
        InitializeComponent();
        Loaded += ContentPage_Loaded;
    }

    private static async void ContentPage_Loaded(object? sender, EventArgs e)
    {
        await Task.Delay(2000);
        await Shell.Current.GoToAsync(nameof(TermsPage));
    }
}