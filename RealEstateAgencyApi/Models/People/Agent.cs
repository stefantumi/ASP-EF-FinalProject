namespace RealEstateAgencyApi.Models;

public class Agent : Person
{
    public List<Property> Catalogue { get; set; } = new();
}