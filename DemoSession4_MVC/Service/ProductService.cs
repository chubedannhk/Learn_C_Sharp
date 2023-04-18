using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public interface ProductService
{
    public List<Product> findAll();
    public Product findById(int id);

    // ham tiem kiem
    public List<Product> searchByName(string keyword);

    // ham sort
    public List<Product> sort(string direction);

    // kiem tra add product duoc hay khong
    public bool Create(Product product);

    public bool Delete(int id);

    public bool Update(Product product);

    // 
    public List<Product> sortPro(int amount);

    //public dynamic : doi tuong an danh
    public dynamic findByIdAjax(int id);

    public dynamic findAllAjax();

    // lay danh sach ten san pham
    public List<string> searchAutoComplete(string keyword);

    public dynamic searchByKeywordAjax(string keyword);

    public dynamic searchByCategoryAjax(int categoryId);

    public Product getProductById(int id);
}
