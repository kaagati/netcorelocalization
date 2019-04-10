using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DrachmaLocalizationDemo
{
    public static class LocalizationExtension
    {
        private static List<CultureInfo> SupportedCultures = new List<CultureInfo>
        {
            new CultureInfo("en-AU"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ne-NP"),
            new CultureInfo("ja-JP")
        };

        public static IServiceCollection AddSelzLocalization(this IServiceCollection coll)
        {
            coll.AddLocalization((a) =>
            {
                a.ResourcesPath = "Cultures";
                
            });
            
            
            
            coll.TryAddSingleton<RequestLocalizationOptions>(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = SupportedCultures,
                SupportedUICultures = SupportedCultures,
            });
            return coll;
        }

        public static void UseSelzLocalization(this IApplicationBuilder app)
        {
            var fromDI = app.ApplicationServices.GetService<RequestLocalizationOptions>();
            
            //we can even customize this
            //fromDI.RequestCultureProviders = null;

            app.UseRequestLocalization(fromDI);

        }


    }
}