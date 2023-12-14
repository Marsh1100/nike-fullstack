using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Sale : BaseEntity
{
    public int IdBill { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public virtual Bill Bills { get; set; }

    public virtual Product Products { get; set; }
}
