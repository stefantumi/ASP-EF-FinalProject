using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    
    /// Agency Create
    public async Task CreateAgencyAsync(Agency newAgency)
    {
        await using var db = _dbContext;
        await db.Agencies.AddAsync(newAgency);
        await db.SaveChangesAsync();
    }
    /// Agency Read
    public async Task<List<Agency>> GetAllAgenciesAsync()
    {
        await using var db = _dbContext;
        return await db.Agencies.ToListAsync();
    }
    /// Agency Read
    public async Task<Agency?> GetAgencyByIdAsync(int agencyId)
    {
        await using var db = _dbContext;
        var agency = await db.Agencies.FirstOrDefaultAsync(x => x.Id == agencyId);
        return agency;
    }
    /// Agency Update
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
    /// Agency Delete
    public async Task DeleteAgencyByIdAsync(int deleteAgencyId)
    {
        await using var db = _dbContext;
        var removeEntity = db.Agencies.FirstOrDefault(x => x.Id == deleteAgencyId);
        db.Agencies.Remove(removeEntity);
        await db.SaveChangesAsync();
    }
    
    

    /// Property Create
    public async Task CreatePropertyAsync(Property newProperty)
    {
        await using var db = _dbContext;
        await db.Properties.AddAsync(newProperty);
        await db.SaveChangesAsync();
    }
    /// Property Read
    public async Task<List<Property>> GetAllPropertiesAsync()
    {
        await using var db = _dbContext;
        var properties = await db.Properties.ToListAsync();
        return properties;
    }
    /// Property Read
    public Task<Property?> GetPropertyByIdAsync(int propertyId)
    {
        using var db = _dbContext; 
        var property = db.Properties.FirstOrDefaultAsync(x => x.Id == propertyId);
        return property;
    }
    /// Property Update
    public async Task UpdateProperty(Property oldProperty, Property newProperty)
    {
        await using var db = _dbContext;
        var orginal = await db.Properties.FirstOrDefaultAsync(x => x == oldProperty);
        orginal.Id = newProperty.Id;
        orginal.Address = newProperty.Address;
        orginal.Size = newProperty.Size;
        orginal.Price = newProperty.Price;
        orginal.Owner = newProperty.Owner;
        orginal.Agency = newProperty.Agency;
        await db.SaveChangesAsync();
    }
    /// Property Delete
    public async Task DeletePropertyById(int deletePropertyId)
    {
        await using var db = _dbContext;
        var propertyToBeRemoved = await db.Properties.FirstOrDefaultAsync(x => x.Id == deletePropertyId);
        db.Properties.Remove(propertyToBeRemoved);
        await db.SaveChangesAsync();
    }

    
    
    /// Agent Create
    public async Task CreateAgentAsync(Agent newAgent)
    {
        await using var db = _dbContext;
        await db.Agents.AddAsync(newAgent);
        await db.SaveChangesAsync();
    }
    /// Agent Read
    public async Task<List<Agent>> GetAllAgentsAsync()
    {
        await using var db = _dbContext;
        return await db.Agents.ToListAsync();
    }
    /// Agent Read
    public async Task<Agent?> GetAgentByIdAsync(int agentId)
    {
        await using var db = _dbContext;
        var agent = await db.Agents.FirstOrDefaultAsync(x => x.Id == agentId);
        return agent;
    }
    /// Agent Update
    public async Task UpdateAgent(int oldAgentId, Agent newAgent)
    {
        await using var db = _dbContext;
        var original = await db.Agents.FirstOrDefaultAsync(x => x.Id == newAgent.Id)!;
        if (original != null)
        {
            original.Id = newAgent.Id;
            original.FirstName = newAgent.FirstName; 
            original.LastName = newAgent.LastName;
            original.SSID = newAgent.SSID;
            original.Property = newAgent.Property;
            await db.SaveChangesAsync();
        }
        
    }
    /// Agent Delete
    public async Task DeleteAgentByIdAsync(int deleteAgentId)
    {
        await using var db = _dbContext;
        var toDelete = await db.Agents.FirstOrDefaultAsync(x => x.Id == deleteAgentId);
        if (toDelete != null)
        {
            db.Agents.Remove(toDelete);
            await db.SaveChangesAsync();
        }
    }
}