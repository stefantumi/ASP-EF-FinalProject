using Microsoft.EntityFrameworkCore;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data;

public class AgencyContext : DbContext
{

    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Property> Properties { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Agency sAgency = new Agency()
        {
            Id = 1,
            Name = "Remax"
        };
        Address sAddr = new Address()
        {
            Id = 1, Street = "Uglugata", HouseNo = 2, Zip = 270, PropertyId = 1
        };
        Property sprop = new Property()
        {
            Id = 1, Price = 1890000, Size = 139, AgencyId = sAgency.Id, 
        };

        modelBuilder.Entity<Agency>().HasData(sAgency);
        modelBuilder.Entity<Property>().HasData(sprop);
        modelBuilder.Entity<Address>().HasData(sAddr);
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // for use with docker 
        // optionsBuilder.UseSqlServer(@"Data Source=127.0.0.1;User Id=SA;Password=StefanTumi.7;Database=Agencydatabase;Trusted_Connection=false");
        // for Windows with local sql server
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Agencydatabase1;Trusted_Connection=True;");
    }
} 