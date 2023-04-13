using FlowerShop.Models;

namespace FlowerShop.Service;

public class CategoryServiceImpl : CategoryService
{
    private DatabaseContext db;
    public CategoryServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }

    public List<Category> findAll()
    {
        return db.Categories.ToList();
    }
}
