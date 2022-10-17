using Microsoft.EntityFrameworkCore;
using RealEstateAgencyApi.Data.Repositories;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data;

public class AgencyContext : DbContext
{

    public DbSet<Agency> Agencies { get; set; }
    
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Property> Properties { get; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;User Id=SA;Password=StefanTumi.7;Database=Agencydatabase;Trusted_Connection=false");
    }
} 