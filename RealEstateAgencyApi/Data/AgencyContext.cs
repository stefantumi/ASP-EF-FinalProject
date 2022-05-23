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
        optionsBuilder.UseSqlServer(
            @"Data Source=192.168.1.81;User Id=SA;Password=StefanTumi.7;Database=Agencydatabase;Trusted_Connection=false");
        
        // optionsBuilder.UseMySQL("server=localhost;database=library;user=user;password=password");

    }
}