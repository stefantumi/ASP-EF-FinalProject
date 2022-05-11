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
    public Task<Agency?> GetAgencyByIdAsync(int agencyId);
    /// UPDATE
    public Agency? UpdateAgency(int oldAgencyId, Agency newAgency);
    /// DELETE
    public Task DeleteAgencyByIdAsync(int deleteAgencyId);
    
    
    
    /// PROPERTY
    /// CREATE
    public Task CreateProperty(Property newProperty);
    /// READ
    public List<Property> GetAllProperties();
    public Property GetPropertyById(int propertyId);
    /// UPDATE
    public Task UpdateProperty(Property oldProperty, Property newProperty);
    /// DELETE
    public Task DeletePropertyById(int deletePropertyId);



    /// AGENT
    /// CREATE
    public Task CreateAgentAsync(Agent newAgent);
    /// READ
    public Task<List<Agent>> GetAllAgentsAsync();
    public Task<Agent> GetAgentByIdAsync(int agentId);

    /// UPDATE
    public Task UpdateAgent(int oldAgentId, Agent newAgent);
    /// DELETE
    public Task DeleteAgentById(int deleteAgentId);
}