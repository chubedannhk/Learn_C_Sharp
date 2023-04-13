﻿using System;
using System.Collections.Generic;

namespace FlowerShop.Models;

public partial class Invoice
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Payment { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime Created { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; } = new List<InvoiceDetail>();
}
