namespace RealEstateAgencyApi.Models.DTO;

public class ContactDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<Property> Property { get; } = new();
}