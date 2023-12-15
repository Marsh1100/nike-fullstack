using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class ProductRepository : GenericRepository<Product>, IProduct
{
    private readonly ApiDbContext _context;

    public ProductRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<(int totalRegistros, IEnumerable<Product> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var query = _context.Products as IQueryable<Product>;
        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(p=>p.Name.ToLower().Contains(search));
        }
        var totalRegistros = await query.CountAsync();
        var registros = await query 
                            .Skip((pageIndex-1)*pageSize)
                            .Take(pageSize)
                            .ToListAsync();
        return (totalRegistros, registros);
    }

    public async Task<object> GetProductsByCategory()
    {
        return await _context.Products.Include(a=>a.Categories).GroupBy(d=> d.IdCategory)
                     .Select(s=> new
                     {
                        category = s.Key,
                        products = s.Select(p=> new 
                        {
                            p.Id,
                            p.Name,
                            p.Price,
                            p.Imagen
                        })
                     })
                     .ToListAsync();
    }
}
