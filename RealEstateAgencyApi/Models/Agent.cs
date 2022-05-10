namespace RealEstateAgencyApi.Models;

public class Agent
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SSID { get; set; }


    public List<Property> Property { get; set; } = new();
}