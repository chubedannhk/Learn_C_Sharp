using DemoSesion2_MVC.Models;

namespace DemoSesion2_MVC.Services;

public interface ProductService
{
    public List<Product> findAll();
    // khai bao function share du lieu
    public List<Product> searchByKeyword(string keyword);

    public List<Product> searchByPrices(double min, double max);

   public List<Product> searchByDateRange(string from ,string to);


    // cua Demo2
    public Product find(int id);
}
