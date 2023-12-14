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

    public override async Task<(int totalRegistros, IEnumerable<Bill> registros)> GetAllAsync2(int pageIndex, int pageSize, int search)
    {
        var query = _context.Bills as IQueryable<Bill>;
        if(search != 0 && !string.IsNullOrEmpty(search.ToString()) )
        {
            query = query.Where(p=>p.Id == search);
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query 
                            .Skip((pageIndex-1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        return (totalRegistros, registros);
    }

   
}
