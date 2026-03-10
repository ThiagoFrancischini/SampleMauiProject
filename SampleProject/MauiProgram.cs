using Microsoft.Extensions.Logging;
using SampleProject.ViewModels;
using SampleProject.Views;

namespace SampleProject
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

            builder.Services.AddSingleton<Services.ITravelService, Services.TravelService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddViewModel>();
            builder.Services.AddTransient<EditViewModel>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<AddPage>();
            builder.Services.AddTransient<EditPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
