using DemoSession4_MVC.Models;

namespace DemoSession4_MVC.Service;

public interface AccountService
{
    public List<Account> findAll();

    public Account findById(int id);
    public Account findByUsername(string username);
    public bool Create(Account account);
    public bool Delete(int id);
    public bool Update(Account account);

    // kiem tra username ton tai hay khong
    public bool Exists(string username);

    public bool Login(string username, string password);



}
