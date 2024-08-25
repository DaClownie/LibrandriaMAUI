﻿namespace LibrandriaMAUI
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			
			Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
			Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
			Routing.RegisterRoute(nameof(TermsPage), typeof(TermsPage));
		}
	}
}
