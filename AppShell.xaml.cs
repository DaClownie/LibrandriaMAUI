﻿using LibrandriaMAUI.Pages;

namespace LibrandriaMAUI
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			
			//Pages
			Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
			Routing.RegisterRoute(nameof(LoadingPage), typeof(LoadingPage));
			Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
			Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
			
			Routing.RegisterRoute(nameof(TermsPage), typeof(TermsPage));
			Routing.RegisterRoute($"/{nameof(TermsPage)}/{nameof(AddTermPage)}", 
				typeof(AddTermPage));
			Routing.RegisterRoute($"/{nameof(TermsPage)}/{nameof(EditTermPage)}", 
				typeof(EditTermPage));
			
			Routing.RegisterRoute(nameof(CoursesPage), typeof(CoursesPage));
			
			Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
			Routing.RegisterRoute(nameof(ReportsPage), typeof(ReportsPage));
		}
	}
}
