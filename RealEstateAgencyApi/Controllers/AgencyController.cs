using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[ApiController]
[Route("api")]
public class AgencyController : Controller
{
    private readonly IRepository _repository;

    public AgencyController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [Route("agency")]
    public List<Agency> GetAllAgencies()
    {
        return _repository.GetAllAgencies();
    }

    [HttpGet]
    [Route("agency/{id:int}")]
    public Agency GetAgencyById(int id)
    {
        return _repository.GetAgencyById(id: id);
    }

    [HttpGet]
    [Route("agent")]
    public List<Agent> GetAllAgents()
    {
        return _repository.GetAllAgents();
    }

    [HttpGet]
    [Route("agent/{id:int}")]
    public Agent GetAgentById(int id)
    {
        return _repository.GetAgentById(id: id);
    }

    [HttpGet]
    [Route("property")]
    public List<Property> GetAllProperties()
    {
        return _repository.GetAllProperties();
    }

    [HttpGet]
    [Route("property/{id:int}")]
    public Property GetPropertyById(int id)
    {
        return _repository.GetPropertyById(id: id);
    }

}