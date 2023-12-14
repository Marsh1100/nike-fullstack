using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class BillDto
{
    public int Id { get; set; }
    public int IdClient { get; set; }

    public DateOnly Date { get; set; }
    
}
