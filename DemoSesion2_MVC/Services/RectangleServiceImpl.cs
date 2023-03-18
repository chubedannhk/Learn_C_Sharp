namespace DemoSesion2_MVC.Services;

public class RectangleServiceImpl : RectangleService
{
    private CalculateService calculateService;
    public RectangleServiceImpl(CalculateService _calculateService)
    {
        calculateService = _calculateService;
    }
    public int Area(int a, int b)
    {
        return calculateService.Mul(a, b);
    }

    public int Perimeter(int a, int b)
    {
       return calculateService.Mul(calculateService.Add(a, b),4);
    }
}
