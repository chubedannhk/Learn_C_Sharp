using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("question")]
public class QuestionController : Controller
{
    //[Route("~/")]
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

    [HttpPost]
    [Route("save")]
    // lay lai gia tri tu form
    public IActionResult Save()
    {
        var QuestionModel = new QuestionModel();
        var questions = QuestionModel.findAll();
        int score = 0;
        foreach (var question in questions)
        {
            var answerId = int.Parse(HttpContext.Request.Form["question_"+question.Id].ToString());
            if(QuestionModel.isCorrect(question.Id, answerId))
            {
                score++;
            }
        }
        ViewBag.score = score;
        return View("result");
    }
}
