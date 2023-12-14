using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class SaleDto
{
    public int Id { get; set; }
    public int IdBill { get; set; }
    public int IdProduct { get; set; }
    public int Quantity { get; set; }
    
}
