using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencyApi.Models;

public class Owner : Person
{
    public List<Property> Property { get; } = new();
}