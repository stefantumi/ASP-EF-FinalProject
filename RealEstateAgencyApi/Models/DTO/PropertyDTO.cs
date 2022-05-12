namespace RealEstateAgencyApi.Models.DTO;

public class PropertyDTO
{
    public int Id { get; set; }
    public Address Address { get; set; }
    public double Size { get; set; }

    public Owner Owner { get; set; }
    public List<Agency> Agency { get; set; }
}