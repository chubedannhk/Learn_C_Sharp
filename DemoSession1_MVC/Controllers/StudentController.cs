using DemoSession1_MVC.Helpers;
using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("student")]
public class StudentController : Controller
{
    private IWebHostEnvironment WebHostEnvironment;

    public StudentController(IWebHostEnvironment _webHostEnvironment)
    {
        WebHostEnvironment = _webHostEnvironment;
    }
    //=============================================================
    [Route("")]
    [Route("index")]
    [Route("~/")]
    public IActionResult Index()
    {
        return View();
    }


    // upload file csv
    [HttpPost]
    [Route("import")]
    // IFormFile giup lay thong tin file tu nguoi dung upload len
    public IActionResult Upload(IFormFile file)
    {
        Debug.WriteLine("Name: " + file.FileName);
        Debug.WriteLine("Size(byte): " + file.Length);
        Debug.WriteLine("Tpye: " + file.ContentType);
        // tao ten file moi
        var fileName = FileHelper.generateFileName(file.FileName);

        // tao bien chua duong dan
        // combine dung de tra ve chuoi duong dan
        var path = Path.Combine(WebHostEnvironment.WebRootPath, "upload", fileName);
        using (var fileStream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
        // doc file ra
        var lines = System.IO.File.ReadAllLines(path);
        foreach( var line in lines)
        {
            var result = line.Split(new char[] { ';' });
            var student = new Student
            {
                Id = result[0],
                Name = result[1],
                Age = int.Parse(result[2].Trim()),
                Score = double.Parse(result[3].Trim())
            };
            Debug.WriteLine($"Student: {student.Id}");
            Debug.WriteLine($"Student: {student.Name}");
            Debug.WriteLine($"Student: {student.Age}");
            Debug.WriteLine($"Student: {student.Score}");

        }
        return RedirectToAction("index", "student");
    }

}
