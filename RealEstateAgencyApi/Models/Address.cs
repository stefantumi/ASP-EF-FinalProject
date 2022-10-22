namespace RealEstateAgencyApi.Models;

public class Address
{
    public int Id { get; set; }
    public string? Street { get; set; }
    public int HouseNo { get; set; }
    public int Zip { get; set; }
    
    public int? PropertyId { get; set; }
    public Property? Property { get; set; }
}