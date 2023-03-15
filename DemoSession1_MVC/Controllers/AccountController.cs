using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoSession1_MVC.Controllers;
[Route("account")]
public class AccountController : Controller
{
    [Route("")]
    [Route("index")]
  //  [Route("~/")]
    public IActionResult Index()
    {
        var account = new Account()
        {
            userName = "admin",
            description = "sjflsdjflsdkjflsjflskjflakfjlfl nguyen hoang khai programing pro",
            // tu dong chon gioi tinh khi chay len
            Gender = "male",
            CertId = "1",
            Status = false,
            RoleId = 2,
            Id = 123,
            Dob = DateTime.Now
        };
        // chuyen du lieu tu certmodel len
        var certModel = new CertModel();
        ViewBag.certs = certModel.findAll();
        //=====

        var languageModel = new LanguageModel();
        ViewBag.language = languageModel.findAll();
         //===

        var roleModel = new RoleModel();
        ViewBag.role = roleModel.findAll();

        return View("Index",account);
    }
    [HttpPost]
    [Route("save")]
    // lay lai gia tri tu form
    public IActionResult Save(Account account, int[] LanguageId)
    {
        Debug.WriteLine($"Account Info \n UserName: {account.userName} \t Password: {account.password}");
        // ma hoa mat khau 
        var hash = BCrypt.Net.BCrypt.HashPassword(account.password);
        Debug.WriteLine($"Hash (mat khau ma hoa: {hash}");

        // vidu mot chuoi mat khau da dc ma hoa, de kiem tra mat khau co hop le hay khong
        var passwordDB = "$2b$10$6Ylc6EAKlDFZK0fefz1w3.zJKMWVhVtuB/va0Aku3fhL/KRPB3uFS";
        if (BCrypt.Net.BCrypt.Verify(account.password, passwordDB))
        {
            Debug.WriteLine("password hop le");
        }else Debug.WriteLine("Password khong hop le");

        Debug.WriteLine($"Description: {account.description}");

        Debug.WriteLine($"Details: {account.details}");

        Debug.WriteLine($"Gender: {account.Gender}");

        Debug.WriteLine($"Certificate: {account.CertId}");

        Debug.WriteLine($"Status: {account.Status}");

        account.LanguageId = LanguageId;
        if(account.LanguageId.Length > 0)
        {
            foreach (var item in LanguageId)
            {
                Debug.WriteLine($"Language: {item} \n");
            }
        }
       
        Debug.WriteLine($"Role Login: {account.RoleId}");

        // lay gia tri id nguoi truy cap
        Debug.WriteLine($"Id: {account.Id}");

        // address info
        Debug.WriteLine("Address Info");
        Debug.WriteLine($"Street: {account.Address.Street}");
        Debug.WriteLine($"Ward: {account.Address.Ward}");
        Debug.WriteLine($"District: {account.Address.District}");
        // lay ra ngay thang nam
        Debug.WriteLine($"Dob: {account.Dob.ToString("yyyy-MM-dd")}");
        // goi ve lai trang index/account
        return RedirectToAction("index", "account");
    }
}
