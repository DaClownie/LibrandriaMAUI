using LibrandriaMAUI.ViewModel;

namespace LibrandriaMAUI
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
