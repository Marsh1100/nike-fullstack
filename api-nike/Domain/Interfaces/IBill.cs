using Domain.Entities;

namespace Domain.Interfaces;

public interface IBill : IGenericRepository<Bill> 
{ 
   
    Task<string> ConfirmSale(Bill modelBill, List<Sale> listProducts);
}
