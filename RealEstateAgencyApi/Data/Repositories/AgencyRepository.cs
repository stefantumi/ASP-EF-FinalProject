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

    /*BEGIN AGENCY GET*/
    public List<Agency> GetAllAgencies()
    {
        return _dbContext.Agencies.ToList();
    }

    public Agency GetAgencyById(int id)
    {
        return _dbContext.Agencies.FirstOrDefault(x => x.Id == id)!;
    }
    /*END AGENCY GET*/
    
    public List<Property> GetAllProperties()
    {
        return _dbContext.Properties.ToList();
    }

    public Property GetPropertyById(int id)
    {
        return _dbContext.Properties.FirstOrDefault(x => x.Id == id)!;
    }

    public List<Agent> GetAllAgents()
    {
        return _dbContext.Agents.ToList();
    }

    public Agent GetAgentById(int id)
    {
        return _dbContext.Agents.FirstOrDefault(x => x.Id == id)!;
    }
}