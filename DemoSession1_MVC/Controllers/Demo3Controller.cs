using DemoSession1_MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("demo3")]
public class Demo3Controller : Controller
{
    //=============================================================
    private IWebHostEnvironment WebHostEnvironment;

    public Demo3Controller(IWebHostEnvironment _webHostEnvironment)
    {
        WebHostEnvironment = _webHostEnvironment;
    }
    //=============================================================
    [Route("index")]
    [Route("")]
 //  [Route("~/")]
    public IActionResult Index()
    {
        // tao de phat sinh chuoi duy nhat
        var name = Guid.NewGuid().ToString().Replace("-","");
        Debug.WriteLine(name);
        //==============
        return View();
    }
    //
    [Route("searchByKeyword")]
    public IActionResult SearchByKeyword(string keyword)
    {
        Debug.WriteLine("keyword: " + keyword);
        return View("index");
    }
    // search by keyword 2
    [HttpPost]
    [Route("searchByKeyword2")]
    public IActionResult SearchByKeyword2()
    {
        var keyword = HttpContext.Request.Form["keyword"].ToString();
        Debug.WriteLine("keyword 2: " + keyword);
        return View("index");
    }
    //==========================================
    //
    [Route("searchByPrices")]
    public IActionResult SearchByPrices(double min, double max)
    {
        Debug.WriteLine("MIN: " + min);
        Debug.WriteLine("MAX: " + max);
        return View("index");
    }

    // login
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        Debug.WriteLine("UserName: " + username);
        Debug.WriteLine("PassWord: " + password);
        return View("index");
    }

    // update
    [HttpPost]
    [Route("update")]
    public IActionResult Update(string[] emails, int[] quantities)
    {
        Debug.WriteLine("emails: " + emails.Length);
        foreach (string email in emails)
        {
            Debug.WriteLine(email);
        }

        Debug.WriteLine("quantities: " + quantities.Length);
        foreach (var quant in quantities)
        {
            Debug.WriteLine(quant);
        }
        return View("index");
    }
    // update
    [HttpPost]
    [Route("upload")]
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
        var path = Path.Combine(WebHostEnvironment.WebRootPath,"upload",fileName);
        using (var fileStream = new FileStream(path,FileMode.Create))
        {
            file.CopyTo(fileStream);
        }
            return RedirectToAction("index", "demo3");
    }

    // update nhieu file
    [HttpPost]
    [Route("uploads")]
    // IFormFile giup lay thong tin file tu nguoi dung upload len
    public IActionResult Uploads(IFormFile[] files)
    {
        Debug.WriteLine("Files: " + files.Length);
        foreach (var file in files)
        {
            Debug.WriteLine("Name: " + file.FileName);
            Debug.WriteLine("Size(byte): " + file.Length);
            Debug.WriteLine("Tpye: " + file.ContentType);
            Debug.WriteLine("----------------------");
            // tao ten file moi
            var fileName = FileHelper.generateFileName(file.FileName);

            // tao bien chua duong dan
            // combine dung de tra ve chuoi duong dan
            var path = Path.Combine(WebHostEnvironment.WebRootPath, "upload", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
        }
        return RedirectToAction("index", "demo3");
    }
}
