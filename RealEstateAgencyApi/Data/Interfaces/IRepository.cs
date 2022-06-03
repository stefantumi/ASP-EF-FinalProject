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
    
    
    /// AGENT
    /// CREATE
    public Task CreateAgentAsync(Agent newAgent);
    /// READ
    public Task<List<Agent>> GetAllAgentsAsync();
    /// READ
    public Task<Agent?> GetAgentByIdAsync(int agentId);
    /// UPDATE
    public Task<Agent?> UpdateAgent(int oldAgentId, Agent newAgent);
    /// DELETE
    public Task DeleteAgentByIdAsync(int deleteAgentId);
    // update property og delete agent

    
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
}