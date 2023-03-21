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
               Name = "Time",
               Photo = "girlviet.png",
               Price = 2243,
               Created = DateTime.ParseExact("20/11/2023","dd/MM/yyyy",CultureInfo.InvariantCulture),
           },
            new Product()
           {
               Id = 3,
               Name = "Name",
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


    // function share keyword

    public List<Product> searchByKeyword(string keyword)
    {
       return products.Where(p=>p.Name.Contains(keyword)).ToList(); 
    }

    public List<Product> searchByPrices(double min, double max)
    {
       return products.Where(p =>p.Price>=min && p.Price<=max).ToList();
    }


    public List<Product> searchByDateRange(string from, string to)
    {
        // ep kieu du lieu 

        var start = DateTime.ParseExact(from, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        var end = DateTime.ParseExact(to, "MM/dd/yyyy", CultureInfo.InvariantCulture);
        return products.Where(p=> p.Created>=start && p.Created<=end).ToList();
    }


    // cua demo 2
    public Product find(int id)
    {
        return products.SingleOrDefault(p => p.Id == id);
    }
}
