using DemoSession1_MVC.Helpers;
using DemoSession4_MVC.Models;
using DemoSession4_MVC.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoSession4_MVC.Controllers;
[Route("product")]
public class ProductController : Controller
{
    private ProductService productService;
    private CategoryService categoryService;
    private IWebHostEnvironment WebHostEnvironment;
    public ProductController(ProductService _productService, CategoryService _categoryService, IWebHostEnvironment _webHostEnvironment)
    {
        productService = _productService;
        categoryService = _categoryService;
        WebHostEnvironment = _webHostEnvironment;
    }




    [Route("")]
  //  [Route("~/")]
    [Route("index")]
    public IActionResult Index()
    {
        ViewBag.product = productService.findAll();
        return View();
    }

    [Route("detail/{id}")]
    public IActionResult Detail(int id)
    {
        ViewBag.detail = productService.findById(id);
        return View();
    }

    [Route("searchByName")]
    public IActionResult searchByName(string keyword)
    {
        ViewBag.product = productService.searchByName(keyword);

        return View("index");
    }

    // sort
    [Route("sort")]
    public IActionResult Sort(string direction)
    {
        ViewBag.product = productService.sort(direction);

        return View("index");
    }

    // add product
    [HttpGet]
    [Route("add")]
    public IActionResult Add()
    {
        var product = new Product()
        {
            Created = DateTime.Now,
        };
        ViewBag.categories = categoryService.findAll();
        return View("add", product);
    }

    [HttpPost]
    [Route("add")]
    public IActionResult Add(Product product, IFormFile file)
    {
        if (file != null)
        {
            var fileName = FileHelper.generateFileName(file.FileName);

            // tao bien chua duong dan
            // combine dung de tra ve chuoi duong dan
            var path = Path.Combine(WebHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            product.Photo = fileName;
        }
        else
        {
            product.Photo = "no_images.png";
        }
        // hien thi thong bao
        if (productService.Create(product))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }
        return RedirectToAction("Index");
    }

    [Route("delete/{id}")]
    public IActionResult Delete(int id)
    {
        if (productService.Delete(id))
        {
            TempData["msg"] = "Done";
        }
        else
        {
            TempData["msg"] = "Failed";
        }
        return RedirectToAction("Index");
    }

    //update
   
    [HttpGet]
    [Route("update/{id}")]
    public IActionResult Update(int id)
    {
        var product = productService.findById(id);
        ViewBag.categories = categoryService.findAll();
        return View("update", product);
    }

    [HttpPost]
    [Route("update/{id}")]
    public IActionResult Update(int id, Product product, IFormFile file)
    {
        product.Id = id;
        if(file != null)
        {
            var fileName = FileHelper.generateFileName(file.FileName);

            // tao bien chua duong dan
            // combine dung de tra ve chuoi duong dan
            var path = Path.Combine(WebHostEnvironment.WebRootPath, "images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            product.Photo = fileName;
        }

        if (productService.Update(product))
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
