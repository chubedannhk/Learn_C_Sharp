using DemoSession1_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession1_MVC.Controllers;
[Route("product")]
public class ProductController : Controller
{
    [Route("")]
    [Route("index")]
   // "~/" dung de khai bao thang controller nao la chay mac dinh, luu y: trong 1 project chi co [Route("~/")] de chay mac dinh thoi
    [Route("~/")]
    public IActionResult Index()
    {
        // goi den ProductModel();
        var productModel = new ProductModel();
        ViewBag.products = productModel.findAll();
        return View();
    }
    // hien thi san pham chi tiet
    [Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
        var productModel = new ProductModel();
        ViewBag.products = productModel.find(id);
        return View("Detail");
    }

    //search san pham can tim kiem
    [Route("searchByProduct")]
    public IActionResult SearchByProduct(string keyword)
    {
        // goi den ProductModel();
        var productModel = new ProductModel();
        ViewBag.products = productModel.search(keyword);
        // dong nay de luu lai ket qua vua tim kiem
        ViewBag.keyword = keyword;
        return View("Index");
    }
    // search theo min va max
    [Route("searchByPrices")]
    public IActionResult SearchByPrices(double min, double max)
    {
        // goi den ProductModel();
        var productModel = new ProductModel();
        ViewBag.products = productModel.searchPrices(min, max);
        // dong nay de luu lai ket qua vua tim kiem
        ViewBag.min = min;
        ViewBag.max = max;
        return View("Index");
    }
}
