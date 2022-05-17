using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[Controller]
[Route("api/property")]
public class PropertyController : ControllerBase
{
    public IRepository _repository;

    public PropertyController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateProperty([FromBody]Property newProperty)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreatePropertyAsync(newProperty);
                return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty);
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
    public async Task<ActionResult<List<Property>>> GetAllProperties()
    {
        List<Property> properties = await _repository.GetAllPropertiesAsync();
        try
        {
            if (ModelState.IsValid)
            {
                return Ok(properties);
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
    public async Task<ActionResult<Property?>> GetPropertyById(int id)
    {
        try
        {
            var property = await _repository.GetPropertyByIdAsync(id);
            
            if (property == null)
            {
                return NotFound();
            }
            
            return Ok(property);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    [Route("{oldProperty:int}")]
    public async Task<IActionResult> UpdateProperty(int oldPropertyId, Property newProperty)
    {
        var original = await _repository.GetPropertyByIdAsync(oldPropertyId);
        if (original == null) return NotFound(original); 
        try
        {
            var updated = await _repository.UpdateProperty(oldPropertyId, newProperty);
            return CreatedAtAction(nameof(GetPropertyById), new { id = updated.Id }, updated);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    [Route("{deleteProperty:int}")]
    public async Task<ActionResult> DeletePropertyById(int deleteProperty)
    {
        var exists = await _repository.GetPropertyByIdAsync(deleteProperty);
        try
        {
            if (exists == null)
            {
                return NotFound();
            }
            // TODO: should anything be returned ? if so, is this correct ? 
            await _repository.DeletePropertyById(deleteProperty);
            return Ok(exists);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}