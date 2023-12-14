using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
namespace Application.Repository;
public class CategoryRepository : GenericRepository<Category>, ICategory
{
    private readonly ApiDbContext _context;

    public CategoryRepository(ApiDbContext context) : base(context)
    {
        _context = context;
    }

   
}
