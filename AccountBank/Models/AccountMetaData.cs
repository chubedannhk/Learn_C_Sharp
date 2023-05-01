using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AccountBank.Models;

public class AccountMetaData

{
    [MinLength(3, ErrorMessage = "Tối thiểu 3 ký tự và tối đa 25 ký tự")]
    [MaxLength(25, ErrorMessage = "Tối thiểu 3 ký tự và tối đa 25 ký tự")]
    public string Username { get; set; }

    [RegularExpression("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})",
 ErrorMessage = "Nhập password phải có ký tự thường, hoa, số và đặc biệt")]
    public string Password { get; set; }

    public string Fullname { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone chỉ được nhập số")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone phải có độ dài 10 số")]
    public string Phone { get; set; }
}

[ModelMetadataType(typeof(AccountMetaData))]
public partial class Account
{

}