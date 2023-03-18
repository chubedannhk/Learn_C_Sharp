namespace DemoSesion2_MVC.Services;

public class DemoServiceImpl : DemoService
{
    public string Hello()
    {
        return "Hello nguyen hoang khai";
    }

    public string Hi(string name)
    {
        return "Hello " + name;
    }
}
