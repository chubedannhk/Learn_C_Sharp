using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DemoSession4_MVC.Models;


public class AccountMetaData

{
    [MinLength(1)]
    [MaxLength(25)]
    public string Username { get; set; }
    [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})")]
    public string Password { get; set; }

    public string FullName { get; set; }

    [EmailAddress]
    public string Email { get; set; }
}

[ModelMetadataType(typeof(AccountMetaData))]
public partial class Account
{

}