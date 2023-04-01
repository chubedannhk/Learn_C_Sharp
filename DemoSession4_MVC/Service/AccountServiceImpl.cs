using DemoSession4_MVC.Models;
using System.Diagnostics;

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
    public bool Create(Account account)
    {
        try
        {
            db.Accounts.Add(account);
            return db.SaveChanges() > 0;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
