using MyTestMauiApp.Pages;

namespace MyTestMauiApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                 .UsePrism(prism =>
                 {
                     prism.RegisterTypes(containerRegistry =>
                     {
                         containerRegistry.Register<INavigationService, PageNavigationService>();
                         containerRegistry.RegisterForNavigation<Bug0002Page>();

                     })
                     .OnInitialized(container =>
                     {

                     })
                     .OnAppStart(async navigationService =>
                     {
                         var navResult = await navigationService.CreateBuilder()
                                     .AddSegment(nameof(NavigationPage))
                                     .AddSegment(nameof(Bug0002Page))
                                     .NavigateAsync();
                     });
                 })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            //builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
