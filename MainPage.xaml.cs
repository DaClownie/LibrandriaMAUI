

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
			ShowRegister();
		}

		private void LoginButton_OnClicked(object? sender, EventArgs e)
		{
			_isRegistered = true;
			ShowLogin();
		}

		private async void SubmitButton_OnClicked(object? sender, EventArgs e)
		{
			if (_isRegistered)
			{
				await SQLFunctions.GetUserId(UsernameLoginEntry.Text, PasswordLoginEntry.Text);
				if (SQLFunctions.CurrentUser is not null)
				{
					await DisplayAlert("Success", $"User GUID: {SQLFunctions.CurrentUser}", "OK");
					ShowMain();
				}
				else
				{
					//TODO add a red text field to login xaml, change text string, make visible.
				}
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
			ShowMain();
		}

		private void ShowMain()
		{
			PickerStack.IsVisible = true;
			RegisterStack.IsVisible = false;
			LoginStack.IsVisible = false;
			ButtonStack.IsVisible = false;
		}

		private void ShowRegister()
		{
			PickerStack.IsVisible = false;
			RegisterStack.IsVisible = true;
			LoginStack.IsVisible = false;
			ButtonStack.IsVisible = true;
		}

		private void ShowLogin()
		{
			PickerStack.IsVisible = false;
			RegisterStack.IsVisible = false;
			LoginStack.IsVisible = true;
			ButtonStack.IsVisible = true;
		}
	}

}
