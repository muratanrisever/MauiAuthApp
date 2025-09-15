using Microsoft.Extensions.Logging;
using MauiAuthApp.Views;
using MauiAuthApp.ViewModels;
using MauiAuthApp.Services;

namespace MauiAuthApp;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		
		// Dependency Injection (Bağımlılıkların Enjeksiyonu)
        // Servisleri kaydediyoruz. Singleton, uygulama boyunca tek bir örnek oluşturur.
		builder.Services.AddSingleton<IUserService, UserService>();

        // View'leri ve ViewModel'leri kaydediyoruz.
        // Transient, her istendiğinde yeni bir örnek oluşturur.
		builder.Services.AddTransient<LoginViewModel>();
		builder.Services.AddTransient<RegisterViewModel>();
		
		builder.Services.AddTransient<LoginPage>();
		builder.Services.AddTransient<RegisterPage>();
		builder.Services.AddTransient<HomePage>();


		return builder.Build();
	}
}