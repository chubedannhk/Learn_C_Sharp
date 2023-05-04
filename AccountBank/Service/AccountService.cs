using AccountBank.Models;

namespace AccountBank.Service;

public interface AccountService
{
    // register tai khoan
    public bool Create(Account account);

    public bool Exists(string username);

    // login tai khoan
    public bool Login(string username, string password);

    public Account findByUsername(string username);
    public Account GetAccountById(int accid);

    //update tai khoan
    public bool Update(Account account);
    //public bool UpdateBalance(Account account);
    public bool UpdateBalance(int accountId, decimal newBalance);
}
