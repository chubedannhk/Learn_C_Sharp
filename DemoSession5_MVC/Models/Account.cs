using System;
using System.Collections.Generic;

namespace QuanLyHoaDon.Models;

public partial class Account
{
    public int AccId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Fullname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public decimal? Balance { get; set; }

    public virtual ICollection<TransactionDetail> TransactionDetails { get; } = new List<TransactionDetail>();
}
