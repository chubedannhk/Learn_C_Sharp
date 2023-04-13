using System;
using System.Collections.Generic;

namespace FlowerShop.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; } = new List<Account>();
}
