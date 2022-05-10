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
    public async Task DeleteAgencyById(int deleteAgencyId)
    {
        await using var db = _dbContext;
        var removeEntity = db.Agencies.FirstOrDefault(x => x.Id == deleteAgencyId);
        db.Agencies.Remove(removeEntity);
        await db.SaveChangesAsync();
    }
    
    

    /// Property Create
    public async Task CreateProperty(Property newProperty)
    {
        await using var db = _dbContext;
        await db.Properties.AddAsync(newProperty);
        await db.SaveChangesAsync();
    }
    /// Property Read
    public List<Property> GetAllProperties()
    {
        using var db = _dbContext;
        return db.Properties.ToList();
    }
    /// Property Read
    public Property GetPropertyById(int propertyId)
    {
        using var db = _dbContext;
        return db.Properties.FirstOrDefault(x => x.Id == propertyId)!;
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
    public async Task CreateAgent(Agent newAgent)
    {
        using var db = _dbContext;
        await db.Agents.AddAsync(newAgent);
    }
    /// Agent Read
    public List<Agent> GetAllAgents()
    {
        using var db = _dbContext;
        return db.Agents.ToList();
    }
    /// Agent Read
    public Agent GetAgentById(int agentId)
    {
        using var db = _dbContext;
        return db.Agents.FirstOrDefault(x => x.Id == agentId)!;
    }
    /// Agent Update
    public async Task UpdateAgent(int oldAgentId, Agent newAgent)
    {
        await using var db = _dbContext;
        var orginal = await db.Agents.FirstOrDefaultAsync(x => x.Id == newAgent.Id)!;
        orginal.Id = newAgent.Id;
        orginal.FirstName = newAgent.FirstName; 
        orginal.LastName = newAgent.LastName;
        orginal.SSID = newAgent.SSID;
        orginal.Property = newAgent.Property;
        await db.SaveChangesAsync();
    }
    /// Agent Delete
    public async Task DeleteAgentById(int deleteAgentId)
    {
        using var db = _dbContext;
        var toDelete = await db.Agents.FirstOrDefaultAsync(x => x.Id == deleteAgentId);
        db.Agents.Remove(toDelete);
        await db.SaveChangesAsync();
    }
}