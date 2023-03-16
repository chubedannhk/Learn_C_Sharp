using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession1_MVC.Controllers;
[Route("question")]
public class QuestionController : Controller
{
    [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        var question = new Question()
        {
           
        };

        var QuestionModel = new QuestionModel();
        ViewBag.question = QuestionModel.findAll();

        return View("Index",question);
    }
}
