using Microsoft.AspNetCore.Mvc;
using RealEstateAgencyApi.Data.Interfaces;
using RealEstateAgencyApi.Models;

namespace RealEstateAgencyApi.Controllers;

[Controller]
[Route("api/address")]
public class AddressController : ControllerBase
{
    public IRepository _repository;

    public AddressController(IRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAddress([FromBody]Address newAddress)
    {
        try
        {
            if (ModelState.IsValid)
            {
                await _repository.CreateAddressAsync(newAddress);
                return CreatedAtAction(nameof(GetAddressById), new { id = newAddress.Id }, newAddress);
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
    public async Task<ActionResult<List<Address>>> GetAllAddresses()
    {
        List<Address> addresses = await _repository.GetAllAddressesAsync();
        try
        {
            if (ModelState.IsValid)
            {
                return Ok(addresses);
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
    public async Task<ActionResult<Address?>> GetAddressById(int id)
    {
        try
        {
            var address = await _repository.GetAddressByIdAsync(id);
            
            if (address == null)
            {
                return NotFound();
            }
            
            return Ok(address);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPut]
    //[Route("{oldAddressId:int}")]
    public async Task<IActionResult> UpdateAddress([FromBody] Address newAddress)
    {
        var original = await _repository.GetAddressByIdAsync(newAddress.Id);
        if (original == null) return NotFound(original);
        var updated = await _repository.UpdateAddress(newAddress);
        try
        {
            // var updated = await _repository.UpdateAddress(oldAddressId, newAddress);
            return CreatedAtAction(nameof(GetAddressById), new { id = updated!.Id }, updated);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpDelete]
    [Route("{deleteAddress:int}")]
    public async Task<ActionResult> DeleteAddressById(int deleteAddress)
    {
        var exists = await _repository.GetAddressByIdAsync(deleteAddress);
        try
        {
            if (exists == null)
            {
                return NotFound();
            }
            // TODO: should anything be returned ? if so, is this correct ? 
            await _repository.DeleteAddressById(deleteAddress);
            return Ok(exists);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}