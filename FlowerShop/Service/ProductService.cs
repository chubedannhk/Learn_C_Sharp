using FlowerShop.Models;

namespace FlowerShop.Service;

public interface ProductService
{
    public List<Product> findAll();
    public Product findById(int id);

    // ham tiem kiem
    public List<Product> searchByName(string keyword);

    // ham sort
    public List<Product> sort(string direction);

    public List<Product> Featured(int n);

    // kiem tra add product duoc hay khong
    public bool Create(Product product);

    public bool Delete(int id);

    public bool Update(Product product);

    // 
    public List<Product> sortPro(int amount);

}
