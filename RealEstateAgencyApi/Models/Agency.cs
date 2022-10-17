using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

namespace RealEstateAgencyApi.Models;

public class Agency
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public List<Property>? Properties { get; } = new();
    
}