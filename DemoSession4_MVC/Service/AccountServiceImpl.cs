using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    public AccountServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    public List<Account> findAll()
    {
        return db.Accounts.ToList();
    }

    public Account findById(int id)
    {
        return db.Accounts.Find(id);
    }
}
