using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public interface ProductService
{
    public List<Product> findAll();
    public Product findById(int id);
}
