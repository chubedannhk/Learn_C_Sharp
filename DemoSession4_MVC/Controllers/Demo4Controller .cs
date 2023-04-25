using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DemoSession4_MVC.Controllers;
[Route("demo4")]
public class Demo4Controller : Controller
{
    private IStringLocalizer<MyMessage> myMessage;
    public Demo4Controller(IStringLocalizer<MyMessage> _myMessage)
    {
        myMessage = _myMessage;
    }
    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.Now = DateTime.Now;
        ViewBag.Currency = 1234567;
        ViewBag.Number = 1234567890;
        ViewBag.Percent = 12.23;

        ViewBag.Msg = myMessage["Msg"];
        ViewBag.Msg2 = string.Format(myMessage["Msg2"], "banhbao");
        return View();
    }
}
