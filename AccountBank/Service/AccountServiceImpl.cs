using AccountBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AccountBank.Service;

public class AccountServiceImpl : AccountService
{
    private DatabaseContext db;
    public AccountServiceImpl(DatabaseContext _db)
    {
        db = _db;
    }
    // register -> tao tai khoan moi
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
    // kiem tra tai khoan da ton tai hay chua
    public bool Exists(string username)
    {
        return db.Accounts.Count(a => a.Username == username) > 0;
    }

   

    // login tai khoan
    public bool Login(string username, string password)
    {
        try
        {
            var account = db.Accounts.SingleOrDefault(a => a.Username == username);
            if (account != null)
            {
                return BCrypt.Net.BCrypt.Verify(password, account.Password);
            }
            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public Account findByUsername(string username)
    {
        return db.Accounts.SingleOrDefault(p => p.Username == username);
    }


    // update tai khoan
    public bool Update(Account account)
    {
       
        try
        {
            var accountToUpdate = db.Accounts.FirstOrDefault(a => a.Username == account.Username);
            if (accountToUpdate == null)
            {
                return false;
            }
            accountToUpdate.Fullname = account.Fullname;
            accountToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            accountToUpdate.Email = account.Email;
            accountToUpdate.Phone = account.Phone;

            db.SaveChanges();

            return true;
        }
        catch
        {
            return false;

        }
    }

}
