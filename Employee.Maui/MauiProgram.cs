using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Plugin.Maui.ScreenBrightness;

namespace Employee.Maui
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
                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                    fonts.AddFont("trebuc.ttf", "trebuc");
                    fonts.AddFont("Trebuchet-MS-Italic.ttf", "Trebuchet-MS-Italic");
                });

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();

            // Screen Brightness
            //builder.Services.AddSingleton(ScreenBrightness.Default);

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
