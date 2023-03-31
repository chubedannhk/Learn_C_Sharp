using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public class ProductServiceImpl : ProductService
{
    private DatabaseContext db;
    public ProductServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<Product> findAll()
    {
       return db.Products.ToList();
    }

    public Product findById(int id)
    {
        return db.Products.SingleOrDefault(p => p.Id == id);
    }
}
