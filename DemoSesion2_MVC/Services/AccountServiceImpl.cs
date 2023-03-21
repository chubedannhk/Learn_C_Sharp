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
              password = "$2b$10$kCtOepPJ7ednvTCS9mVEK.dS/wAJ4f965ruggSmXpCW38zlYpwSsi",
              fullName = "admin master",
          },
          new Account()
          {
              userName = "admin2",
              password = "$2b$10$ti1H7nd1lUZdtZjwG6v7WerIs.KgpeBb0C.nvysuW.XAVQTySkWFC",
              fullName = "admin master2"
          }
        };
    }
    public bool login(string userName, string password)
    {
        throw new NotImplementedException();
    }
}
