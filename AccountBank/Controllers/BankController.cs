using AccountBank.Helpers;
using AccountBank.Models;
using AccountBank.Service;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text;

namespace AccountBank.Controllers;
[Route("bank")]
public class BankController : Controller
{
    private IConfiguration configuration;
    private AccountService accountService;
    private TransactionDetailService transactionDetailService;


    public BankController(AccountService _accountService, TransactionDetailService _transactionDetailService, IConfiguration _configuration)
    {
        accountService = _accountService;
        transactionDetailService = _transactionDetailService;
        configuration = _configuration;
    }
    //[Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.accid = HttpContext.Session.GetString("accid");
        ViewBag.balance = HttpContext.Session.GetString("balance");
        return View();
    }
    [HttpPost]
    [Route("autobank/{id}")]
    public IActionResult AutoBank(int id, TransactionDetail transaction)
    {
        // Get the account with given id
        var account = accountService.GetAccountById(id);

        // Check if account exists
        if (account == null)
        {
            return NotFound();
        }

        // Check if the transaction amount is valid
        if (transaction.TransType == 2 && transaction.TransMonry > account.Balance)
        {
            ModelState.AddModelError("transaction.TransMonry", "Not enough balance");
            return View("error","bank");
        }

        TransactionDetail transactionDetail = new TransactionDetail();
        transactionDetail.AccId = id;
        transactionDetail.TransMonry = transaction.TransMonry;
        transactionDetail.TransType = transaction.TransType;
        transactionDetail.DateOfTrans = DateTime.Now;
        transactionDetailService.CreateTransactionDetail(transactionDetail);

        // Update account balance and create transaction record
        if (transaction.TransType == 1)
        {
            account.Balance += transaction.TransMonry;
            accountService.UpdateBalance(account.AccId, account.Balance);
            HttpContext.Session.SetString("balance", account.Balance.ToString()); // Lưu giá trị mới vào session

        }
        else if (transaction.TransType == 2)
        {
            account.Balance -= transaction.TransMonry;
            accountService.UpdateBalance(account.AccId, account.Balance);
            HttpContext.Session.SetString("balance", account.Balance.ToString()); // Lưu giá trị mới vào session
        }

        var mailHelper = new MailHelper(configuration);

        // Tạo nội dung email thông báo thành công giao dịch
        var content = $"Giao dịch: Nạp/rút tiền thành công vào tài khoản {account.AccId}. Số dư hiện tại của tài khoản là {account.Balance}.";
      //  mailHelper.Send(account.Email, "nguyenhoangkhai.010103@gmail.com", content)
        mailHelper.Send(configuration["Gmail:Username"], account.Email, "Successful Transaction", content);
        return RedirectToAction("Index", "Home");
    }

    [Route("error")]
    public IActionResult error()
    {
        return View();
    }
}
