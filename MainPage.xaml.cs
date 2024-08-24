

using LibrandriaMAUI.Data;

namespace LibrandriaMAUI
{
	public partial class MainPage : ContentPage
	{
		private bool _isRegistered;
		public MainPage()
		{
			InitializeComponent();
			ShowMain();
		}

		private void RegisterButton_OnClicked(object? sender, EventArgs e)
		{
			_isRegistered = false;
			PickerStack.IsVisible = false;
			RegisterStack.IsVisible = true;
			LoginStack.IsVisible = false;
			ButtonStack.IsVisible = true;
		}

		private void LoginButton_OnClicked(object? sender, EventArgs e)
		{
			_isRegistered = true;
			PickerStack.IsVisible = false;
			RegisterStack.IsVisible = false;
			LoginStack.IsVisible = true;
			ButtonStack.IsVisible = true;
		}

		private async void SubmitButton_OnClicked(object? sender, EventArgs e)
		{
			if (_isRegistered)
			{
				await SQLFunctions.GetUserId(UsernameLoginEntry.Text, PasswordLoginEntry.Text);
				await DisplayAlert("Success", $"User GUID: {SQLFunctions.CurrentUser}", "OK");
				ShowMain();
			}
			else
			{
				await SQLFunctions.AddNewUser(UsernameRegisterEntry.Text, PasswordRegisterEntry.Text, EmailRegisterEntry.Text);
				await DisplayAlert("Success", "Your account has been created", "OK");
				ShowMain();
			}
		}

		private void BackButton_OnClicked(object? sender, EventArgs e)
		{
			PickerStack.IsVisible = true;
			RegisterStack.IsVisible = false;
			LoginStack.IsVisible = false;
			ButtonStack.IsVisible = false;
		}

		private void ShowMain()
		{
			PickerStack.IsVisible = true;
			RegisterStack.IsVisible = false;
			LoginStack.IsVisible = false;
			ButtonStack.IsVisible = false;
		}
	}

}
