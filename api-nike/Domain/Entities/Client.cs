using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Client : BaseEntity
{
    public int IdUser { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string Surname { get; set; }

    public string SecondSurname { get; set; }

    public virtual ICollection<Bill> Bills { get; set; } = new List<Bill>();

    public virtual User Users { get; set; }
}
