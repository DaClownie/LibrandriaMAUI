using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainViewModel vm)
		{
			InitializeComponent();
			BindingContext = vm;
		}
	}
}
