using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using CargaDescarga.OpenStreetMap;
using CargaDescarga.Pois;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;

namespace CargaDescarga
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
                });


            builder.Services
     .AddBlazorise(options =>
     {
         options.Immediate = true;
     })
     .AddBootstrap5Providers()
     .AddFontAwesomeIcons();

            builder.Services.AddMauiBlazorWebView();            
            builder.Services.AddFluentUIComponents();
            builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
            builder.Services.AddHttpClient<OpenStreetMapService>(client =>
            {
                client.BaseAddress = new Uri("https://nominatim.openstreetmap.org/");
            });
            builder.Services.AddHttpClient<PoiService>(client =>
            {
                client.BaseAddress = new Uri("https://sycapps.net/api/");
            });

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
