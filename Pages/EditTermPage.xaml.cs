using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages;

public partial class EditTermPage : ContentPage
{
    public EditTermPage(EditTermViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}