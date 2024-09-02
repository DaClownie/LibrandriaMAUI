using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

[QueryProperty(nameof(UserId), "userId")]
public partial class AddTermPage : ContentPage
{
    public string UserId { get; set; }
    
    public AddTermPage(TermsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}