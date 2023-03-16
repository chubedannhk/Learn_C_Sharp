using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoSession1_MVC.Models;

public class EmployeeMetaData
{
    [MaxLength(10)]
    [MinLength(5)]
    // ran buoc phai nhap Username
    [Required]
    public string Username { get; set; }
    [Required]
    // ((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})
    [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
    public string Password { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Url]
    // luu y: neu khong yeu cau bat buoc nhap thi phai them dau ?
    public string? Website { get; set; }

    [Range(18, 60)]
    public int Age { get; set; }

    [Required]
    public string FullName {get; set;}
    
}
[ModelMetadataType(typeof(EmployeeMetaData))]
public partial class Employee
{

}
