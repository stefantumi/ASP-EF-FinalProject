using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[Controller]
[Route("api/agency")]
public class AgencyController : ControllerBase
{
    private readonly IRepository _repository;

    public AgencyController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public List<Agency> GetAllAgencies()
    {
        return _repository.GetAllAgencies();
    }

    [HttpGet]
    [Route("{id:int}")]
    public Agency GetAgencyById(int id)
    {
        return _repository.GetAgencyById(id: id);
    }
}