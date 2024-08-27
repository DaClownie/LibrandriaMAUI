using LibrandriaMAUI.Context;
using LibrandriaMAUI.Services;
using LibrandriaMAUI.ViewModel;
using Microsoft.Extensions.Logging;

namespace LibrandriaMAUI
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
			// DB Service
			builder.Services.AddSingleton<LibrandriaDbContext>();

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainViewModel>();
			builder.Services.AddSingleton<UserService>();
			
			builder.Services.AddTransient<RegisterPage>();
			builder.Services.AddTransient<RegisterViewModel>();
			
			builder.Services.AddTransient<LoginPage>();
			builder.Services.AddTransient<LoginViewModel>();

			builder.Services.AddTransient<TermsPage>();
			builder.Services.AddTransient<TermsViewModel>();
			builder.Services.AddSingleton<TermService>();
			
			builder.Services.AddTransient<CoursesPage>();
			builder.Services.AddTransient<CoursesViewModel>();
			

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
