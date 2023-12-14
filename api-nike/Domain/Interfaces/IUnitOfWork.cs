using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;

public interface IUnitOfWork
{
    IRolRepository Roles { get; }
    IUserRepository Users { get; }

    IBill Bills { get; }
    ICategory Categories { get; }
    IClient Clients { get; }
    IProduct Products { get; }
    ISale Sales { get; }
    Task<int> SaveAsync();
}
