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

    public async Task<string> ConfirmSale(Bill modelBill, List<Sale> listProducts)
    {
        var existClient = await _context.Clients.Where(u => u.Id == modelBill.IdClient).FirstOrDefaultAsync();
        if(existClient == null)
        {
            return "No existe cliente";
        }
        var newBill = new Bill
        {
            IdClient = modelBill.IdClient,
            Date = DateTime.UtcNow,
        };
        try
        {
            _context.Bills.Add(newBill);
            await _context.SaveChangesAsync();
            var billCreated = await _context.Bills
                                        .Where(u => u.Id == newBill.Id)
                                        .FirstOrDefaultAsync();

            List<Sale> newSaleProducts = new();
            foreach (var saleProduct in listProducts)
            {
                var product = await _context.Products
                                    .Where(u => u.Id == saleProduct.IdProduct)
                                    .FirstOrDefaultAsync();
                newSaleProducts.Add(new Sale
                {
                    IdBill = billCreated.Id,
                    IdProduct = saleProduct.IdProduct,
                    Quantity = saleProduct.Quantity

                });
                if (product.Quantity >= saleProduct.Quantity || saleProduct.Quantity !=0)
                {

                    product.Quantity -= saleProduct.Quantity;
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                }
                else

                {
                    _context.Bills.Remove(newBill);
                    _context.Sales.Remove(saleProduct);
                    await _context.SaveChangesAsync();
                    if( saleProduct.Quantity ==0){return "No se puede hacer una compra con cantidad 0";}
                    return "No hay productos suficientes";
                }
            }
            try
            {
                _context.Sales.AddRange(newSaleProducts);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _context.Bills.Remove(newBill);
                await _context.SaveChangesAsync();
                return ex.Message + "holaa";
            }
        }
        catch (Exception ex)
        {
            _context.Bills.Remove(newBill);
            await _context.SaveChangesAsync();
            return ex.Message + " Algo salio de la chingada";
        }
        return "Venta realizada con éxito!!";
    }

   
}
