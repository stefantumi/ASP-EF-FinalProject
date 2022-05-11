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
    public async Task<ActionResult> CreateAgency([FromBody]Agency newAgency)
    {
        
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAgencyAsync(newAgency);
                return CreatedAtAction(nameof(GetAgencyById), new { id = newAgency.Id }, newAgency);
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
    public async Task<ActionResult<List<Agency>>> GetAllAgencies()
    {
        List<Agency> agencies = await _repository.GetAllAgenciesAsync();
        try
        {
            if (ModelState.IsValid)
            {
                
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
    public async Task<ActionResult<Agency>> GetAgencyById(int id)
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
            if (original == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetAgencyById), new { id = newAgency.Id }, newAgency);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteAgencyById(int deleteAgencyId)
    {
        var exists = await _repository.GetAgencyByIdAsync(deleteAgencyId);
        try
        {
            if (exists == null)
            {
                return NotFound();
            }
            // TODO: should anything be returned ? if so, is this correct ? 
            await _repository.DeleteAgencyByIdAsync(deleteAgencyId);
            return Ok(exists);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}