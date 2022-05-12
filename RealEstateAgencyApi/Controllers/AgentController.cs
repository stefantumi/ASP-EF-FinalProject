using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[Controller]
[Route("api/agent")]
public class AgentController : ControllerBase
{
    public IRepository _repository;

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
                return NotFound(ModelState);
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
        var agents = await _repository.GetAllAgentsAsync();
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
    public async Task<ActionResult<Agent?>> GetAgentById(int id)
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
    [Route("{oldAgentId:int}")]
    public async Task<IActionResult> UpdateAgent(int oldAgentId, Agent newAgent)
    {
        var original = await _repository.GetAgentByIdAsync(oldAgentId);
        if (original == null) return NotFound(original);
        try
        {
            var updated = await _repository.UpdateAgent(oldAgentId, newAgent);
            return CreatedAtAction(nameof(GetAgentById), new { id = updated.Id }, updated);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    [Route("{deleteAgentId:int}")]
    public async Task<ActionResult> DeleteAgentById(int deleteAgentId)
    {
        var exists = await _repository.GetAgentByIdAsync(deleteAgentId);
        try
        {
            if (exists == null)
            {
                return NotFound();
            }
            // TODO: should anything be returned ? if so, is this correct ? 
            await _repository.DeleteAgentByIdAsync(deleteAgentId);
            return Ok(exists);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}