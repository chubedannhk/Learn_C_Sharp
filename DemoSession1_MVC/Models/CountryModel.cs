namespace DemoSession1_MVC.Models;

public class CountryModel
{
    public List<InfoAddress> findAll()
    {
        return new List<InfoAddress>()
        {
            new InfoAddress()  {Country="Viet Nam"},
            new InfoAddress() {Country="America"},
            new InfoAddress() {Country="Korea"},
            new InfoAddress() {Country="France"}

        };
    }
}
