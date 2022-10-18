using Microsoft.EntityFrameworkCore;
using RealEstateAgencyApi.Data.Repositories;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data;

public class AgencyContext : DbContext
{

    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Property> Properties { get; set; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // for use with docker 
        // optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;User Id=SA;Password=StefanTumi.7;Database=Agencydatabase;Trusted_Connection=false");
        // for Windows with local sql server
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Agencydatabase1;Trusted_Connection=True;");
    }
} 