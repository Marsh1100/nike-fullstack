using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BillDto
{
    public int Id { get; set; }
    public int IdClient { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
}
public class BillManyProductsDto
{
    public int IdClient { get; set; }
    public List<SaleProductDto> ProductList { get; set; }

}
