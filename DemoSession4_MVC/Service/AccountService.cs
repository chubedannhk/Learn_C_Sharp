using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public interface AccountService
{
    public List<Account> findAll();

    public Account findById(int id);
}
