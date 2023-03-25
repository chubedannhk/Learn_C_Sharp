using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.Controllers;
[Route("contact")]
public class ContactController : Controller
{
    [Route("index")]
    [Route("contact1")]
    public IActionResult Contact1()
    {
        return View("Contact1");
    }
    [Route("contact2")]
    public IActionResult Contact2()
    {
        return View("Contact2");
    }

}
