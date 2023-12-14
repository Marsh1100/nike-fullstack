using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class SaleRepository : GenericRepository<Sale>, ISale
{
    private readonly ApiDbContext _context;

    public SaleRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

   
}
