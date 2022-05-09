using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Interfaces;

public interface IRepository
{
    
    /// Agency
    /// CREATE
    public Task CreateAgency(Agency newAgency);
    /// READ
    public List<Agency> GetAllAgencies();
    public Agency GetAgencyById(int agencyId);
    /// UPDATE
    public Agency? UpdateAgency(Agency oldAgency, Agency newAgency);
    /// DELETE
    public Task<Agency> DeleteAgencyById(int deleteAgencyId);
    
    
    
    /// PROPERTY
    /// CREATE
    public Task AddProperty(Property propertyToAdd);
    /// READ
    public List<Property> GetAllProperties();
    public Property GetPropertyById(int propertyId);
    /// UPDATE
    public Task<IActionResult> UpdateProperty(Property oldProperty,Property newProperty);
    /// DELETE
    public Task<IActionResult> DeletePropertyById(int deletePropertyId);



    /// AGENT
    /// CREATE
    public Task CreateAgent(Agent newAgent);
    /// READ
    public List<Agent> GetAllAgents();
    public Agent GetAgentById(int agentId);

    /// UPDATE
    public Task<IActionResult> UpdateAgent(Agent oldAgent, Agent newAgent);
    /// DELETE
    public void DeleteAgentById(int deleteAgentId);
}