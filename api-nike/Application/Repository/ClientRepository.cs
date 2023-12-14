using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ClientRepository : GenericRepository<Client>, IClient
{
    private readonly ApiDbContext _context;

    public ClientRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

   
}
