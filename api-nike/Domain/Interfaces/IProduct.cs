using Domain.Entities;

namespace Domain.Interfaces;

public interface IProduct : IGenericRepository<Product> 
{ 
   
    Task<object> GetProductsByCategory();
}
