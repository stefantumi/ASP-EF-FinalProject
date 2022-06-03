using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencyApi.Models;

public class Property
{
    public int Id { get; set; }
    public Address Address { get; set; }
    public double Size { get; set; }
    public double Price { get; set; }
    public Owner? Owner { get; set; }
    public Buyer? Buyer { get; set; }
    
    
    
}
