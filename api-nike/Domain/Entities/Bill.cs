using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Bill : BaseEntity
{

    public int IdClient { get; set; }

    public DateOnly Date { get; set; }

    public virtual Client Clients { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
