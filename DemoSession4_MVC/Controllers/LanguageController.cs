using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("language")]
public class LanguageController : Controller
{
    [Route("change")]
    public IActionResult Change(string cultural)
    {
        //xxx
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName, 
            CookieRequestCultureProvider.MakeCookieValue(
            new RequestCulture(cultural)), 
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(7)}
            );

        return RedirectToAction("index", "demo4");
    }
}
