using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikayeyaziyoruz.Data;
using System.Threading;
using System.Globalization;

namespace hikayeyaziyoruz.Controllers
{


    public class LanguageController : Controller
    {
        public RedirectToRouteResult Change(String languageSelect)
        {
            if (languageSelect != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageSelect);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageSelect);
            }

            HttpCookie cookie = new HttpCookie("language");
            cookie.Value = languageSelect;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}