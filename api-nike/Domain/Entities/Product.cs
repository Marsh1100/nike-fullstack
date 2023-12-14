using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Product : BaseEntity
{
    public string Name { get; set; }

    public int IdCategory { get; set; }

    public virtual Category Categories { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
