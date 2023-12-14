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

   
}
