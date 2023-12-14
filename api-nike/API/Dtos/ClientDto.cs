using System.ComponentModel.DataAnnotations;

namespace API.Dtos;

public class ClientDto
{
    public int Id { get; set; }
    public int IdUser { get; set; }

    public string FirstName { get; set; }

    public string SecondName { get; set; }

    public string Surname { get; set; }

    public string SecondSurname { get; set; }
    
}
