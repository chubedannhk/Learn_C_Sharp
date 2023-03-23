using DemoSesion2_MVC.Models;

namespace DemoSesion2_MVC.Services;

public interface AccountService
{
    public bool login(string username, string password);

    public Account find(string username);
}
