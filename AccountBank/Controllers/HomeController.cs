using AccountBank.Models;
using AccountBank.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Numerics;

namespace AccountBank.Controllers;
[Route("home")]
public class HomeController : Controller
{
    private AccountService accountService;
    private TransactionDetailService transactionDetailService;

    public HomeController(AccountService _accountService, TransactionDetailService _transactionDetailService)
    {
        accountService = _accountService;
        transactionDetailService = _transactionDetailService;
    }
    //  [Route("~/")]
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.username = HttpContext.Session.GetString("username");
        ViewBag.email = HttpContext.Session.GetString("email") ?? "";
        ViewBag.phone = HttpContext.Session.GetString("phone") ?? "";
        ViewBag.fullname = HttpContext.Session.GetString("fullname") ?? "";
        ViewBag.balance = HttpContext.Session.GetString("balance") ?? "";
        ViewBag.accid = HttpContext.Session.GetString("accid") ?? "";
        decimal balance;
        if (decimal.TryParse(HttpContext.Session.GetString("balance"), out balance))
        {
            ViewBag.balance = balance;
        }
        else
        {
            ViewBag.balance = 0; // hoặc giá trị mặc định nếu không thể parse đc dữ liệu balance từ session
        }


        ViewBag.email = TempData["email"]?.ToString() ?? ViewBag.email;
        ViewBag.phone = TempData["phone"]?.ToString() ?? ViewBag.phone;
        ViewBag.fullname = TempData["fullname"]?.ToString() ?? ViewBag.fullname;
        return View();
    }
    
    

    // update
    [HttpGet]
    [Route("update/{username}")]
    public IActionResult Update(string username)
    {
        var accoutInfo = accountService.findByUsername(username);
        accoutInfo.Password = "******";
        return View("update", accoutInfo);
    }

    [HttpPost]
    [Route("update/{username}")]
    public IActionResult Update(string username, Account account)
    {
        account.Username = username;
       

        if (accountService.Update(account))
        {
            var updatedAccount = accountService.findByUsername(username);
            // Truyền thông tin tài khoản vào ViewBag để hiển thị lên View
            ViewBag.Account = updatedAccount;
            TempData["msg"] = "Update Success";
            TempData["email"] = updatedAccount.Email;
            TempData["phone"] = updatedAccount.Phone;
            TempData["fullname"] = updatedAccount.Fullname;
        }
        else
        {
            TempData["msg"] = "Update Failed";
        }
      
        return RedirectToAction("index", "home", new { username = username });
    }

    [Route("history/{id}")]
    public IActionResult History()
    {
        ViewBag.accid = HttpContext.Session.GetString("accid");
        return View();
    }

    [Route("recharge/{id}")]
    public IActionResult Recharge(int id)
    {
        List<TransactionDetail> transactions = transactionDetailService.searchTrans(id);
        ViewBag.Transactions = transactions;
        ViewBag.accid = id;
        return View("history");
    }
    [Route("draw/{id}")]
    public IActionResult Draw(int id)
    {
        List<TransactionDetail> transactionss = transactionDetailService.searchTransWithDraw(id);
        ViewBag.Transactions = transactionss;
        //   ViewBag.Transactionsdraw = transactionss;
        ViewBag.accid = id;
        return View("history");
    }

    

}
