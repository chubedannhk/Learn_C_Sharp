using DemoSession4_MVC.Models;
using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("ajax")]
public class AjaxController : Controller
{
    private AccountService accountService;
    private ProductService productService;
    public AjaxController(AccountService _accountService, ProductService _productService)
    {
        accountService = _accountService;
        productService = _productService;
    }
   // [Route("~/")]
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }
    [Route("ajax1")]
    public IActionResult Ajax1()
    {
        return new JsonResult(new
        {
            msg = "Hello Master NguyenHoangKhai"
        });
    }

    [Route("ajax2")]
    public IActionResult Ajax2(string fullName)
    {
        return new JsonResult(new
        {
            msg = "Hello Master " + fullName
        });
    }

    [Route("ajax3")]
    public IActionResult Ajax3(Account account, string username)
    {
        //if (account.Username != null && accountService.Exists(account.Username))
        //{
        //    return new JsonResult(new
        //    {
        //        msg = username + " da ton tai"
        //    });
        //}
        //return new JsonResult(new
        //{
        //    msg = username + " hop le _ chua ton tai"
        //});

        // viet cach ngan gon hon
        return new JsonResult(new
        {
            exist = accountService.Exists(username)
        });

    }

    [HttpPost]
    [Route("login")]
    public IActionResult Login(string username, string password)
    {
        return new JsonResult(new
        {
            valig = accountService.Login(username, password)
        });
    }

    // ham cua demo5

    [Route("find")]
    public IActionResult findByIdAjax()
    {
        return new JsonResult(productService.findByIdAjax(6));
    }

    [Route("findAll")]
    public IActionResult findAllAjax()
    {
        return new JsonResult(productService.findAllAjax());
    }
    [Route("searchAotuComplete")]
    public IActionResult SearchAotuComplete(string term)
    {
        return new JsonResult(productService.searchAutoComplete(term));

    }
}
