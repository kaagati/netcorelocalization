using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DrachmaLocalizationDemo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;

namespace DrachmaLocalizationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly RequestLocalizationOptions _options;
        
        public HomeController(IStringLocalizer<HomeController> localizer,
            RequestLocalizationOptions options)
        {
            _localizer = localizer;
            _options = options;
            
        }

        public IActionResult Index()
        {
            
            var model = new CultureModel();
            model.SupportedUICultures = new List<CultureInfo>(this._options.SupportedUICultures);
            var localizedString = this._localizer["Greetings"];
            ViewBag.Grettings = localizedString;
            return View(model);
        }

        public IActionResult Privacy()
            {
                return View();
            }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class CultureModel
    {
        public IReadOnlyList<CultureInfo> SupportedUICultures { get; set; }
        
    }

    //public class SelzCultureProvider : RequestCultureProvider
    //{
    //    public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
    //    {
    //        if(httpContext==null)
    //            throw new ArgumentNullException(nameof(httpContext));
    //        httpContext.Request.QueryString.
    //    }
    //}


}
