using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class BillRepository : GenericRepository<Bill>, IBill
{
    private readonly ApiDbContext _context;

    public BillRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

   
}
