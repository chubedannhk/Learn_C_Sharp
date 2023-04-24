﻿using System;
using System.Collections.Generic;

namespace DemoSession4_MVC.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool Status { get; set; }

    public string? SecutiryCode { get; set; }

    public virtual ICollection<Invoice> Invoices { get; } = new List<Invoice>();

    public virtual ICollection<Role> Roles { get; } = new List<Role>();
}