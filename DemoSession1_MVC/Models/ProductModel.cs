namespace DemoSession1_MVC.Models;

public class ProductModel
{
    private List<Product> products;
    public ProductModel() {
        products = new List<Product>
        {

        new Product
        {
              Id = 1,
              Name = "angel",
              Photo = "angel.png",
              Price = 6000,
              Quantity = 3,
              Created = DateTime.Now
        },
        new Product
        {
              Id = 2,
              Name = "sexy girl",
              Photo = "angel.png",
              Price = 5000,
              Quantity = 3,
              Created = DateTime.Now
        },
        new Product
        {
              Id = 3,
              Name = "garachorm",
              Photo = "angel.png",
              Price = 4000,
              Quantity = 3,
              Created = DateTime.Now
        }

    };
    }
    // dung de tra ve danh sach cac san pham
    public List<Product> findAll() { return products; }
    public Product find(int id)
    {
        // su dung bieu thuc lamd la xong
        return products.SingleOrDefault(p => p.Id == id);
    }

    // search list product
    public List<Product> search(string keyword)
    {
        return products.Where(p => p.Name.Contains(keyword)).ToList();
    }

    public List<Product> searchPrices(double min, double max)
    {
        return products.Where(p => p.Price >= min && p.Price <= max).ToList();
    }
    //public List<Product> search(string keyword, decimal minPrice, decimal maxPrice)
    //{
    //    return products.Where(p => p.Name.Contains(keyword) && p.Price >= minPrice && p.Price <= maxPrice).ToList();
    //}
}

