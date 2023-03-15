namespace DemoSession1_MVC.Models;

public class Login
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string speciallNeeds { get; set; }
    public string email { get; set; }

    public InfoAddress infoAddress { get; set; }

     public string Status { get; set; }

      public PhoneNumber Phone { get; set; }
    //// date
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}
