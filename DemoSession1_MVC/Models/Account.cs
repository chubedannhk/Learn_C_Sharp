namespace DemoSession1_MVC.Models;

public class Account
{
    public string userName { get; set; }
    public string password { get; set; }
    public string description { get; set; }
    public string details { get; set; }
    public string Gender { get; set; }
    public string CertId { get; set; }
    public bool Status { get; set; }

    public int[] LanguageId { get; set; }

    public int RoleId { get; set;}

    public int Id { get; set; }
}
