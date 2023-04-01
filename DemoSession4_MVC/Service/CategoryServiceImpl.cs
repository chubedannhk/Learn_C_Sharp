using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

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
