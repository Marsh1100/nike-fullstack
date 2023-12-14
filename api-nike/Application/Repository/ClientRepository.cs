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

    public override async Task<(int totalRegistros, IEnumerable<Client> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Clients as IQueryable<Client>;
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p=>p.FirstName.ToLower().Contains(search) || p.SecondName.ToLower().Contains(search) ||  p.Surname.ToLower().Contains(search) ||  p.SecondSurname.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query 
                            .Skip((pageIndex-1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        return (totalRegistros, registros);
    }

   
}
