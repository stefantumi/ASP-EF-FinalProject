using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Interfaces;

public interface IRepository
{
    public List<Agency> GetAllAgencies();
    public Agency GetAgencyById(int id);
    
    public List<Property> GetAllProperties();
    public Property GetPropertyById(int id);

    public List<Agent> GetAllAgents();
    public Agent GetAgentById(int id);

}