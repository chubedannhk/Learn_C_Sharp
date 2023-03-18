using DemoSesion2_MVC.Models;
using System.Globalization;

namespace DemoSesion2_MVC.Services;

public class ProductServiceImpl : ProductService
{
    private List<Product> products;
    public ProductServiceImpl()
    {
        products = new List<Product>()
        {
           new Product()
           {
               Id = 1,
               Name = "Test",
               Photo = "angel.png",
               Price = 2343,
               Created = DateTime.ParseExact("20/10/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
           },
           new Product()
           {
               Id = 2,
               Name = "Test",
               Photo = "girlviet.png",
               Price = 2243,
               Created = DateTime.ParseExact("20/11/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
           },
            new Product()
           {
               Id = 3,
               Name = "Test",
               Photo = "girlviet.png",
               Price = 1943,
               Created = DateTime.Now,
           }

        };
    }
    public List<Product> findAll()
    {
        return products;
    }
}
