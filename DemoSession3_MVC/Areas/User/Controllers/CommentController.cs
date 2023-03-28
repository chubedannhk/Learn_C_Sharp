using Microsoft.AspNetCore.Mvc;

namespace DemoSession3_MVC.Areas.User.Controllers;
[Area("user")]
[Route("user/comment")]
public class CommentController : Controller
{
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        return View();
    }
}
