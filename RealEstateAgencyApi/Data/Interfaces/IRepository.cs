using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Interfaces;

public interface IRepository
{
    
    /// Agency
    /// CREATE
    public Task CreateAgencyAsync(Agency newAgency);
    /// READ
    public Task<List<Agency>> GetAllAgenciesAsync();
    /// READ
    public Task<Agency?> GetAgencyByIdAsync(int agencyId);
    /// UPDATE
    public Task<Agency?> UpdateAgency(int oldAgencyId, string newAgencyName);
    /// DELETE
    public Task DeleteAgencyByIdAsync(int deleteAgencyId);
   
    /// PROPERTY
    /// CREATE
    public Task CreatePropertyAsync(Property newProperty);
    /// READ
    public Task<List<Property>> GetAllPropertiesAsync();
    /// READ
    public Task<Property?> GetPropertyByIdAsync(int propertyId);
    /// UPDATE
    public Task<Property?> UpdateProperty(Property newProperty);
    /// DELETE
    public Task DeletePropertyById(int deletePropertyId);
    
    
    /// ADDRESS
    /// CREATE
    public Task CreateAddressAsync(Address newAddress);
    /// READ
    public Task<List<Address>> GetAllAddressesAsync();
    /// READ
    public Task<Address?> GetAddressByIdAsync(int addressId);
    /// UPDATE
    public Task<Address?> UpdateAddress(Address newAddress);
    /// DELETE
    public Task DeleteAddressById(int deleteAddressId);
}