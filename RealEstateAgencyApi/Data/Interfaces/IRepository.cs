using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Data.Interfaces;

public interface IRepository
{
    /// <summary>
    /// GET AGENCY 
    /// </summary>
    public List<Agency> GetAllAgencies();
    public Agency GetAgencyById(int id);

    public Task<IActionResult> AddAgency();

    /// <summary>
    /// GET PROPERTY
    /// </summary>
    public List<Property> GetAllProperties();
    public Property GetPropertyById(int id);
    
    

    /// <summary>
    /// GET AGENT
    /// </summary>
    public List<Agent> GetAllAgents();
    public Agent GetAgentById(int id);

}