using CommunityToolkit.Maui;
using LibrandriaMAUI.Context;
using LibrandriaMAUI.Services;
using LibrandriaMAUI.ViewModel;
using LibrandriaMAUI.Pages;
using Microsoft.Extensions.Logging;
using MauiIcons.Material;

namespace LibrandriaMAUI
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.UseMaterialMauiIcons()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
			
			// DB Service
			builder.Services.AddSingleton<LibrandriaDbContext>();
			
			// Auth Service
			builder.Services.AddSingleton<UserService>();
			
			// Login
			builder.Services.AddTransient<LoginPage>();
			builder.Services.AddTransient<LoginViewModel>();
			
			// Loading
			builder.Services.AddTransient<LoadingPage>();
			
			// Main
			builder.Services.AddTransient<MainPage>();
			builder.Services.AddTransient<MainViewModel>();
			
			// Register
			builder.Services.AddTransient<RegisterPage>();
			builder.Services.AddTransient<RegisterViewModel>();
			
			// Terms
			builder.Services.AddSingleton<TermService>();
			
			builder.Services.AddSingleton<TermsPage>();
			builder.Services.AddSingleton<TermsViewModel>();
			
			builder.Services.AddTransient<AddTermPage>();
			builder.Services.AddTransient<AddTermViewModel>();
			
			builder.Services.AddTransient<EditTermPage>();
			builder.Services.AddTransient<EditTermViewModel>();
			
			builder.Services.AddSingleton<ReportsPage>();
			builder.Services.AddSingleton<ProfilePage>();
			
			
			builder.Services.AddTransient<CoursesPage>();
			builder.Services.AddTransient<CoursesViewModel>();
			

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
