using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[ApiController]
[Route("api/agent")]
public class AgentController : Controller
{

    private readonly IRepository _repository;

    public AgentController(IRepository repository)
    {
        _repository = repository;
    }
    
    
    [HttpGet]
    public List<Agent> GetAllAgents()
    {
        return _repository.GetAllAgents();
    }

    [HttpGet]
    [Route("{id:int}")]    
    public Agent GetAgentById(int id)
    {
        return _repository.GetAgentById(id: id);
    }
}