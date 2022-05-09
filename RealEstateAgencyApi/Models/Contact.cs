namespace RealEstateAgencyApi.Models;

public class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SSID { get; set; }

    public List<Property> Property { get; } = new();
}