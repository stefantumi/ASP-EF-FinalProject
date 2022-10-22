using Microsoft.EntityFrameworkCore;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Repositories;

public class AgencyRepository : IRepository
{
    public AgencyContext _dbContext;
    
    public AgencyRepository()
    {
        _dbContext = new AgencyContext();

    }

    /// Agency Create
    public async Task CreateAgencyAsync(Agency newAgency)
    {
        var db = _dbContext;
        await db.Agencies.AddAsync(newAgency);
        await db.SaveChangesAsync();
        
    }
    /// Agency Read
    public async Task<List<Agency>> GetAllAgenciesAsync()
    {
        var db = _dbContext;
        // return await db.Agencies.ToListAsync();
        return await db.Agencies
            .ToListAsync();
    }
    /// Agency Read
    public async Task<Agency?> GetAgencyByIdAsync(int agencyId)
    {
        var db = _dbContext;
        var agency = await db.Agencies
            .Include(x => x.Properties)!
            .ThenInclude(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == agencyId);
        return agency;
    }
    

    /// Agency Update
    public async Task<Agency?> UpdateAgency(int AgencyId, string newAgencyName)
    {
        var db = _dbContext;
        var agencyToUpdate = await db.Agencies.FirstOrDefaultAsync(x => x.Id == AgencyId);
        
        if (agencyToUpdate == null)
        {
            return null;
        }
        
        agencyToUpdate.Name = newAgencyName;
        await db.SaveChangesAsync();

        return agencyToUpdate;
    }
    /// Agency Delete
    public async Task DeleteAgencyByIdAsync(int deleteAgencyId)
    {
        var db = _dbContext;
        var removeEntity = await db.Agencies.FirstOrDefaultAsync(x => x.Id == deleteAgencyId);
        if (removeEntity != null)
        {
            db.Agencies.Remove(removeEntity);
            await db.SaveChangesAsync();    
        }
    }

    /// Property Create
    public async Task CreatePropertyAsync(Property newProperty)
    {
        var db = _dbContext;
        var agencyExists = await db.Agencies.FirstOrDefaultAsync(x => x.Id == newProperty.AgencyId);
        if (agencyExists == null)
        {
            newProperty.AgencyId = null;
        }
        
        await db.Properties.AddAsync(newProperty);
        await db.SaveChangesAsync();
    }

    /// Property Read
    public async Task<List<Property>> GetAllPropertiesAsync()
    {
        var db = _dbContext;
        var properties = await db.Properties.Include(x => x.Address).ToListAsync();
        return properties;
    }

    /// Property Read
    public Task<Property?> GetPropertyByIdAsync(int propertyId)
    {
        var db = _dbContext; 
        var property = db.Properties
            .Include(x => x.Address)
            .FirstOrDefaultAsync(x => x.Id == propertyId);
        return property;
    }
    /// Property Update
    public async Task<Property?> UpdateProperty(Property newProperty)
    {
        var db = _dbContext;
        var propertyToUpdate = await db.Properties.FirstOrDefaultAsync(x => x.Id == newProperty.Id);

        if (propertyToUpdate == null) return null;

        propertyToUpdate.Size = newProperty.Size;
        propertyToUpdate.Address!.Street = newProperty.Address!.Street;
        propertyToUpdate.Address.HouseNo = newProperty.Address.HouseNo;
        propertyToUpdate.Address.Zip = newProperty.Address.Zip;
        propertyToUpdate.Price = newProperty.Price;
        await db.SaveChangesAsync();
        
       var updatedResult = await db.Properties.FirstOrDefaultAsync(x => x.Id == newProperty.Id);

       return updatedResult;
    }
    /// Property Delete
    public async Task DeletePropertyById(int deletePropertyId)
    {
        var db = _dbContext;
        var propertyToBeRemoved = await db.Properties.FirstOrDefaultAsync(x => x.Id == deletePropertyId);
        if (propertyToBeRemoved != null)
        {
            db.Properties.Remove(propertyToBeRemoved);
            await db.SaveChangesAsync();
        }
    }


    public async Task CreateAddressAsync(Address newAddress)
    {
        var db = _dbContext;
        await db.Addresses.AddAsync(newAddress);
        await db.SaveChangesAsync();
    }
    /// Property Read
    public async Task<List<Address>> GetAllAddressesAsync()
    {
        var db = _dbContext;
        var addresses = await db.Addresses.ToListAsync();
        return addresses;
    }
    /// Address Read
    public Task<Address?> GetAddressByIdAsync(int addressId)
    {
        var db = _dbContext; 
        var address = db.Addresses
            .FirstOrDefaultAsync(x => x.Id == addressId);
        return address;
    }
    /// Address Update
    public async Task<Address?> UpdateAddress(Address newAddress)
    {
        var db = _dbContext;
        var addressToUpdate = await db.Addresses.FirstOrDefaultAsync(x => x.Id == newAddress.Id);

        if (addressToUpdate == null) return null;

        addressToUpdate.Id = newAddress.Id;
        addressToUpdate.Street = newAddress.Street;
        addressToUpdate.Zip = newAddress.Zip;
        addressToUpdate.HouseNo = newAddress.HouseNo;
        
        await db.SaveChangesAsync();
        
        var updatedResult = await db.Addresses.FirstOrDefaultAsync(x => x.Id == newAddress.Id);

        return updatedResult;
    }
    /// Address Delete
    public async Task DeleteAddressById(int deleteAddressId)
    {
        var db = _dbContext;
        var addressToBeRemoved = await db.Addresses.FirstOrDefaultAsync(x => x.Id == deleteAddressId);
        if (addressToBeRemoved != null)
        {
            db.Addresses.Remove(addressToBeRemoved);
            await db.SaveChangesAsync();
        }
    }
}