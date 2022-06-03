using Microsoft.EntityFrameworkCore;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data;

public class AgencyContext : DbContext
{
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Property> Properties { get; set; }
    public DbSet<Agent> Agents { get; set; }
    
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Agencydatabase;Trusted_Connection=True;");
        
    }
}