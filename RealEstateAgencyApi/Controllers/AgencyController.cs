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

    [HttpPost]
    public async Task<IActionResult> CreateAgency([FromBody]Agency newAgency)
    {
        try
        {
            if (ModelState.IsValid)
            {
                //TODO: fix this
                await _repository.CreateAgencyAsync(newAgency);
                return CreatedAtAction(nameof(GetAgencyByIdAsync), new { id = newAgency.Id }, newAgency);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    
    [HttpGet]
    public async Task<ActionResult<List<Agency>>> GetAllAgenciesAsync()
    {
        try
        {
            if (ModelState.IsValid)
            {
                List<Agency> agencies = await _repository.GetAllAgenciesAsync();
                return Ok(agencies);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Agency>> GetAgencyByIdAsync(int id)
    {
        try
        {
            var agency = await _repository.GetAgencyByIdAsync(id);
            
            if (agency == null)
            {
                return NotFound();
            }
            
            return Ok(agency);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    
    [HttpPut]
    public async Task<IActionResult> UpdateAgency(int oldAgencyId, Agency newAgency)
    {
        var original = await _repository.GetAgencyByIdAsync(oldAgencyId);
        try
        {


        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}