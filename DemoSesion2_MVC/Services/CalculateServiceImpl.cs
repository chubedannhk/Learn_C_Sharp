namespace DemoSesion2_MVC.Services;

public class CalculateServiceImpl : CalculateService
{
    public int Add(int a, int b)
    {
       return a + b;
    }

    public int Mul(int a, int b)
    {
       return a * b;
    }
}
