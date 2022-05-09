using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Repositories;

public class AgencyRepository : IRepository
{
    private readonly AgencyContext _dbContext;

    public AgencyRepository()
    {
        _dbContext = new AgencyContext();
    }


    public async Task CreateAgency(Agency newAgency)
    {
        await using var db = _dbContext;
        await db.Agencies.AddAsync(newAgency);
        await db.SaveChangesAsync();
    }

    public List<Agency> GetAllAgencies()
    {
        using var db = _dbContext;
        return db.Agencies.ToList();
    }

    public Agency GetAgencyById(int agencyId)
    {
        using var db = _dbContext;
        return db.Agencies.FirstOrDefault(x => x.Id == agencyId)!;
    }
    
    public Agency? UpdateAgency(int oldAgencyId, Agency newAgency)
    {
        using var db = _dbContext;
        var agencyToUpdate = db.Agencies.FirstOrDefault(x => x.Id == oldAgencyId);
        
        if (agencyToUpdate == null)
        {
            return null;
        }

        agencyToUpdate.Id = newAgency.Id;
        agencyToUpdate.Agents = newAgency.Agents;
        agencyToUpdate.Name = newAgency.Name;
        agencyToUpdate.Properties = newAgency.Properties;

        return agencyToUpdate;
    }

    public async Task<Agency>? DeleteAgencyById(int deleteAgencyId)
    {
        await using var db = _dbContext;
        var removeEntity = db.Agencies.FirstOrDefault(x => x.Id == deleteAgencyId);
        if (removeEntity == null) return null;
        db.Agencies.Remove(removeEntity);
        await db.SaveChangesAsync();
        return removeEntity;
    }

    public Task AddProperty(Property propertyToAdd)
    {
        throw new NotImplementedException();
    }

    public List<Property> GetAllProperties()
    {
        throw new NotImplementedException();
    }

    public Property GetPropertyById(int propertyId)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> UpdateProperty(Property oldProperty, Property newProperty)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> DeletePropertyById(int deletePropertyId)
    {
        throw new NotImplementedException();
    }

    public Task CreateAgent(Agent newAgent)
    {
        throw new NotImplementedException();
    }

    public List<Agent> GetAllAgents()
    {
        throw new NotImplementedException();
    }

    public Agent GetAgentById(int agentId)
    {
        throw new NotImplementedException();
    }

    public Task<IActionResult> UpdateAgent(Agent oldAgent, Agent newAgent)
    {
        throw new NotImplementedException();
    }

    public void DeleteAgentById(int deleteAgentId)
    {
        throw new NotImplementedException();
    }
}