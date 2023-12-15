using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string Imagen { get; set; }

    public int IdCategory { get; set; }
    
}
