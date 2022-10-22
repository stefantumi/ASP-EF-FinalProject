namespace RealEstateAgencyApi.Models;
public class Property
{

    public int Id { get; set; }
    public Address? Address { get; set; }

    public int? AgencyId { get; set; }
    public double Size { get; set; }
    public double Price { get; set; }

}
