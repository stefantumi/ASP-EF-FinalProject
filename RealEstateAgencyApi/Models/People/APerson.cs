using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAgencyApi.Models;

public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SSID { get; set; }
    
}