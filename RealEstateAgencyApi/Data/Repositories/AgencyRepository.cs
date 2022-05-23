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
        return await db.Agencies.Include(x => x.Properties).ToListAsync();
    }
    /// Agency Read
    public async Task<Agency?> GetAgencyByIdAsync(int agencyId)
    {
        var db = _dbContext;
        var agency = await db.Agencies.FirstOrDefaultAsync(x => x.Id == agencyId);
        return agency;
    }
    /// Agency Update
    public async Task<Agency?> UpdateAgency(int oldAgencyId, string newAgencyName)
    {
        var db = _dbContext;
        var agencyToUpdate = await db.Agencies.FirstOrDefaultAsync(x => x.Id == oldAgencyId);
        
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
    
    
    /// Agent Create
    public async Task CreateAgentAsync(Agent newAgent)
    {
        var db = _dbContext;
        await db.Agents.AddAsync(newAgent);
        await db.SaveChangesAsync();
    }
    /// Agent Read
    public async Task<List<Agent>> GetAllAgentsAsync()
    {
        var db = _dbContext;
        return await db.Agents.ToListAsync();
    }
    /// Agent Read
    public async Task<Agent?> GetAgentByIdAsync(int agentId)
    {
        var db = _dbContext;
        var agent = await db.Agents.FirstOrDefaultAsync(x => x.Id == agentId);
        return agent;
    }
    /// Agent Update
    public async Task<Agent?> UpdateAgent(int oldAgentId, Agent newAgent)
    {
        var db = _dbContext;
        var agentToUpdate = await db.Agents.FirstOrDefaultAsync(x => x.Id == oldAgentId);
        
        if (agentToUpdate == null) return null;
        
        agentToUpdate.Id = newAgent.Id;
        agentToUpdate.FirstName = newAgent.FirstName; 
        agentToUpdate.LastName = newAgent.LastName;
        agentToUpdate.SSID = newAgent.SSID;
        await db.SaveChangesAsync();

        return agentToUpdate;
    }
    /// Agent Delete
    public async Task DeleteAgentByIdAsync(int deleteAgentId)
    {
        
        var db = _dbContext;
        var toDelete = await db.Agents.FirstOrDefaultAsync(x => x.Id == deleteAgentId);
        if (toDelete != null)
        {
            db.Agents.Remove(toDelete);
        }
        await db.SaveChangesAsync();
    }
    
    
    /// Property Create
    public async Task CreatePropertyAsync(Property newProperty)
    {
        var db = _dbContext;
        await db.Properties.AddAsync(newProperty);
        await db.SaveChangesAsync();
    }
    /// Property Read
    public async Task<List<Property>> GetAllPropertiesAsync()
    {
        var db = _dbContext;
        var properties = await db.Properties.ToListAsync();
        return properties;
    }
    /// Property Read
    public Task<Property?> GetPropertyByIdAsync(int propertyId)
    {
        var db = _dbContext; 
        var property = db.Properties.FirstOrDefaultAsync(x => x.Id == propertyId);
        return property;
    }
    /// Property Update
    public async Task<Property?> UpdateProperty(int oldPropertyId, Property newProperty)
    {
        var db = _dbContext;
        var propertyToUpdate = await db.Properties.FirstOrDefaultAsync(x => x.Id == oldPropertyId);

        if (propertyToUpdate == null) return null;
        
        propertyToUpdate.Id = newProperty.Id;
        propertyToUpdate.Size = newProperty.Size;
        propertyToUpdate.Price = newProperty.Price;
        propertyToUpdate.Owner = newProperty.Owner;
        propertyToUpdate.Buyer = newProperty.Buyer;
        await db.SaveChangesAsync();
        
        return propertyToUpdate;
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
}