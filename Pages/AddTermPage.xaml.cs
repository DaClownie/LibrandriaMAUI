using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class AddTermPage : ContentPage
{
    public AddTermPage(AddTermViewModel vm)
    {
        
        InitializeComponent();
        BindingContext = vm;
    }
}