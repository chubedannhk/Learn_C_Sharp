using DemoSession4_MVC.Models;
using System.Diagnostics;

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

    public List<Product> searchByName(string keyword)
    {
        return db.Products.Where(p => p.Name.Contains(keyword)).ToList();
    }

    public List<Product> sort(string direction)
    {
        if (direction == "asc")
        {
            return db.Products.OrderBy(p => p.Price).ToList();
        }
        return db.Products.OrderByDescending(p => p.Price).ToList();

    }


    public bool Create(Product product)
    {
        try
        {
            db.Products.Add(product);
            return db.SaveChanges() > 0;
        }catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            db.Products.Remove(db.Products.Find(id));

            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    //update product 
    public bool Update(Product product)
    {
        try
        {
            db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }

    

    public List<Product> sortPro(int amount)
    {
        return db.Products.OrderByDescending(p => p.Id).Take(amount).ToList();
    }

    // doi tuong an danh
    public dynamic findByIdAjax(int id)
    {
        return db.Products.Where(p => p.Id == id).Select(p => new
        {
            id = p.Id,
            name = p.Name,
            price = p.Price,
        }).FirstOrDefault();
    }

    public dynamic findAllAjax()
    {
        return db.Products.Select(p => new
        {
            id = p.Id,
            name = p.Name,
            price = p.Price,
            quantity = p.Quantity,
            description = p.Description,
            status = p.Status,
            photo = p.Photo,
            created = p.Created,
            feature = p.Featured,
            Category = p.Category.Name
        }).ToList();
    }

    // ham search san pham
    public List<string> searchAutoComplete(string keyword)
    {
        return db.Products.Where(p => p.Name.Contains(keyword)).Select(p=> p.Name).ToList();
    }

    public dynamic searchByKeywordAjax(string keyword)
    {
        return db.Products.Where(p => p.Name.Contains(keyword)).Select(p => new
        {
            id=p.Id,
            name = p.Name,
            price = p.Price,
            quantity = p.Quantity,
            description = p.Description,
            status = p.Status,
            photo = p.Photo,
            created = p.Created,
            feature = p.Featured,
            Category = p.Category.Name
        }).ToList() ;
    }

    public dynamic searchByCategoryAjax(int categoryId)
    {
        return db.Products.Where(p => p.Category.Id == categoryId).Select(p => new
        {
            id = p.Id,
            name = p.Name,
            price = p.Price,
            quantity = p.Quantity,
            description = p.Description,
            status = p.Status,
            photo = p.Photo,
            created = p.Created,
            featured = p.Featured,
            category = p.Category.Name
        }).ToList();
    }

    public Product getProductById(int id)
    {
        return db.Products.Find(id);
    }
}
