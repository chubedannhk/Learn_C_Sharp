using DemoSession4_MVC.Helpers;
using DemoSession4_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("contact")]
public class ContactController : Controller
{
    private IConfiguration configuration;

    public ContactController(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View("index", new Contact());
    }
    [HttpPost]
    [Route("send")]
    public IActionResult Send(Contact contact)
    {
        var content = "Full Name: " + contact.FullName;
        content += "<br>Email: " + contact.Email;
        content += "<br>Phone: " + contact.Phone;
        content += "<br>Content: " + contact.Content;

        var mailHelper = new MailHelper(configuration);
        if (mailHelper.Send(contact.Email, "nguyenhoangkhai.010103@gmail.com", contact.Title, content)){
            return RedirectToAction("success");
        }
        else
        {
            TempData["msg"] = "Failed";
            return RedirectToAction("index");
        }
    }

    [Route("success")]
    public IActionResult Success()
    {
        return View("success");
    }
}
