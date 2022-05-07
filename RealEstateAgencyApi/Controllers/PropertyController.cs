using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[ApiController]
[Route("api/property")]
public class PropertyController : Controller
{

    private readonly IRepository _repository;

    public PropertyController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public List<Property> GetAllProperties()
    {
        return _repository.GetAllProperties();
    }

    [HttpGet]
    [Route("{id:int}")]
    public Property GetPropertyById(int id)
    {
        return _repository.GetPropertyById(id: id);
    }
}