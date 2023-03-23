using DemoSesion2_MVC.Models;

namespace DemoSesion2_MVC.Services;

public class AccountServiceImpl : AccountService
{
    private List<Account> accounts;
    public AccountServiceImpl()
    {
        accounts = new List<Account>()
        {
          new Account()
          {
              userName = "admin",
              Password = "$2b$10$kCtOepPJ7ednvTCS9mVEK.dS/wAJ4f965ruggSmXpCW38zlYpwSsi",
              fullName = "admin master",
          },
          new Account()
          {
              userName = "admin2",
              Password = "$2b$10$ti1H7nd1lUZdtZjwG6v7WerIs.KgpeBb0C.nvysuW.XAVQTySkWFC",
              fullName = "admin master2"
          }
        };
    }


    public bool login(string username, string password)
    {
        var account = accounts.SingleOrDefault(a => a.userName == username);
        if(account != null)
        {
            return BCrypt.Net.BCrypt.Verify(password, account.Password);
        }
        return false;
    }



    public Account find(string username)
    {
        return accounts.SingleOrDefault(a => a.userName == username);
    }
}
