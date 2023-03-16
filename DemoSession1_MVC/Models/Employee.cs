using System.ComponentModel.DataAnnotations;

namespace DemoSession1_MVC.Models;

public partial class Employee
{
  
    public string Username { get; set; }
  
    public string Password { get; set; }
   
    public string Email {get; set; }
 
    public string? Website { get; set; }

    public int Age { get; set; }

    public string FullName { get; set; }
}
