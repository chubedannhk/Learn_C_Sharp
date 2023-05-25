using DemoSesion2_MVC.Models;
using DemoSesion2_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DemoSesion2_MVC.Controllers;
[Route("cart")]
public class CartController : Controller
{
    private ProductService productService;
    private IConfiguration configuration;
    public CartController(ProductService _productService, IConfiguration _configuration)
    {
        productService = _productService;
        configuration = _configuration;
    }
    [Route("")]
    [Route("index")]
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("cart") != null)
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
            ViewBag.cart = cart;
            // tinh tong tien san pham 
            ViewBag.total = cart.Sum(i => i.Product.Price * i.Quantity);
        }
        // khai bao duong dan den paypal

        ViewBag.postUrl = configuration["PayPal:PostUrl"];
        ViewBag.returnUrl = configuration["PayPal:ReturnUrl"];
        ViewBag.business = configuration["PayPal:Business"];
        return View("Index");
    }
    // ham xu ly mua san pham
    [Route("buy/{id}")]
    public IActionResult Buy(int id)
    {
        // lay san pham ra
        var product = productService.find(id);
        if (HttpContext.Session.GetString("cart") == null)
        {
            var cart = new List<Item>();
            cart.Add(new Item
            {
                Product = product,
                Quantity = 1,

            });
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        else
        {
            var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));

            var index = Exists(id, cart);
            if (index == -1)
            {
                cart.Add(new Item
                {
                    Product = product,
                    Quantity = 1,

                });
            }
            else
            {
                cart[index].Quantity++;
            }

            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
        return RedirectToAction("index");
    }

    // xu ly san pham khi bi trung
    private int Exists(int id, List<Item> cart)
    {
        for (var i = 0; i < cart.Count; i++)
        {
            if (cart[i].Product.Id == id)
            {
                return i;
            }
        }
        return -1;
    }


    // xoa san pham 
    [Route("reomove/{id}")]
    public IActionResult Remove(int id)
    {
        // bien gio hang thanh List
        var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        // tim den vi tri can xoa va gan cho bien index
        var index = Exists(id, cart);
        cart.RemoveAt(index);
        // sau do bien lai thanh session 
        HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        return RedirectToAction("index");
    }

    //update so luong san pham
    [HttpPost]
    [Route("update")]
    public IActionResult Update(int[] quantities)
    {
        // bien gio hang thanh List
        var cart = JsonConvert.DeserializeObject<List<Item>>(HttpContext.Session.GetString("cart"));
        // duyet qua tung vi tri tuong uong
        for (var i = 0;i<cart.Count;i++)
        {
            cart[i].Quantity = quantities[i];
        }
        // chuyen lai thanh session de luu lai
        HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        return RedirectToAction("index");
    }

    // XU LÝ VỚI PAYPAL
    [Route("success")]
    public IActionResult Success(string payer_email, string first_name, string last_name, string address_street)
    {
        Debug.WriteLine("Payer Email: " + payer_email);
        Debug.WriteLine("First name: " + first_name);
        Debug.WriteLine("Last name: " + last_name);
        Debug.WriteLine("Address street: " + address_street);
        // gửi email cho khach hang thong tin giao dich

        return View("Success");
    }
 }
