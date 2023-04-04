using DemoSession4_MVC.Models;
using Microsoft.EntityFrameworkCore;
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
    public Account findByUsername(string username)
    {
        return db.Accounts.SingleOrDefault(p => p.Username == username);
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

    public bool Delete(int id)
    {
        try
        {
            var account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
            db.SaveChanges();
            return account != null;
        }
        catch (Exception)
        {
            return false;
        }
    }

    //public bool Update(Account account)
    //{
    //    try
    //    {
    //        db.Entry(account).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    //        return db.SaveChanges() > 0;
    //    }
    //    catch
    //    {
    //        return false;
    //    }
    //}
    public bool Update(Account account)
    {
        try
        {
            var accountToUpdate = db.Accounts.Find(account.Id);
            if (accountToUpdate == null)
            {
                return false;
            }
            accountToUpdate.Username = account.Username;
            accountToUpdate.Password = account.Password;
            accountToUpdate.Email = account.Email;
            accountToUpdate.Status = account.Status;

            db.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    // phuong thuc kiem tra username ton tai hay chua
    public bool Exists(string username)
    {
        return db.Accounts.Count(a => a.Username == username) > 0;
    }

    public bool Login(string username, string password)
    {
        try
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username == username && a.Status);
            if (account != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            return false;
        }catch(Exception ex)
        {
            return false;
        }
        
    }

   
}
