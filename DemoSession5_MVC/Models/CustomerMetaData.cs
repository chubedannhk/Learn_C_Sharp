using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace QuanLyHoaDon.Models;

public class CustomerMetaData
{
    [MinLength(10)]
    [MaxLength(11)]
    public string Phone { get; set; }
}
[ModelMetadataType(typeof(CustomerMetaData))]
public partial class Customer
{

}
