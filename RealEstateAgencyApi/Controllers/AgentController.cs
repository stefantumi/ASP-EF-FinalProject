using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[Controller]
[Route("api/agent")]
public class AgentController : ControllerBase
{
private readonly IRepository _repository;

    public AgentController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAgent([FromBody]Agent newAgent)
    {
        
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAgentAsync(newAgent);
                return CreatedAtAction(nameof(GetAgentById), new { id = newAgent.Id }, newAgent);
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
    public async Task<ActionResult<List<Agent>>> GetAllAgents()
    {
        List<Agent> agents = await _repository.GetAllAgentsAsync();
        try
        {
            if (ModelState.IsValid)
            {
                return Ok(agents);
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
    public async Task<ActionResult<Agent>> GetAgentById(int id)
    {
        try
        {
            var agent = await _repository.GetAgentByIdAsync(id);
            
            if (agent == null)
            {
                return NotFound();
            }
            
            return Ok(agent);
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