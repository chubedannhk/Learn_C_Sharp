using DemoSession1_MVC.Helpers;
using DemoSession4_MVC.Models;
using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("account")]
public class AccountController : Controller
{
    private AccountService accountService;
    public AccountController(AccountService _accountService)
    {
        accountService = _accountService;
    }
 //   [Route("~/")]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        if (accountService.Login(username, password))
        {
            HttpContext.Session.SetString("username", username);
           
            return RedirectToAction("welcome");
        }
        else
        {
            TempData["msg"] = "Login Failed";
            return RedirectToAction("login");
        }
    }


    [HttpGet]
    [Route("register")]
    public IActionResult Register()
    {
        var account = new Account();
        return View("register", account);
    }
    [HttpPost]
    [Route("register")]
    public IActionResult Register(Account account)
    {
        if(account.Username != null && accountService.Exists(account.Username)){
            ModelState.AddModelError("Username", "Username da ton tai ");
        }
        // kiem tra du lieu co hop le khong
        if (ModelState.IsValid)
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            // tam thoi cho status bang true de dang nhap
            account.Status = true;
            if (accountService.Create(account))
            {
                return RedirectToAction("Login");
            }
            else
            {
                TempData["msg"] = "Register Failed";
                return RedirectToAction("register");
            }
        }
        else
        {
            return View("register");
        }
    }
    // welcome page 
    [Route("welcome")]
    public IActionResult Welcome()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        return View();
    }


    //  [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        ViewBag.account = accountService.findAll();
        return View();
    }
    [Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
        ViewBag.account = accountService.findById(id);
        return View();
    }
    [Route("accdetail/{username}")]
    public IActionResult Accdetail(string username)
    {
        var accDetail = accountService.findByUsername(username);
        
        return View("accdetail", accDetail);
    }


    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var account = new Account();

        return View("add", account);
    }


    [HttpPost]
    [Route("add")]
    public IActionResult Add(Account account)
    {
        // Mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(account.Password);

        // Gán mật khẩu đã mã hóa vào account
        account.Password = hashedPassword;

        // Thực hiện lưu account vào cơ sở dữ liệu
        if (accountService.Create(account))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }

        return RedirectToAction("Index");
    }

    //delete
    [HttpGet]
    [Route("delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (accountService.Delete(id))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("update/{id}")]
    public IActionResult Update(int id)
    {

        var account = accountService.findById(id);
        return View("update", account);
    }

    [HttpPost]
    [Route("update/{id}")]
    public IActionResult Update(int id,Account account)
    {
        account.Id = id;
        if (accountService.Update(account))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }

        return RedirectToAction("Index");
    }



}
