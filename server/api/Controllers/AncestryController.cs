using Application.Common.Interfaces;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AncestryController(IAncestryService ancestryService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await ancestryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await ancestryService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAncestryDto dto)
    {
        var result = await ancestryService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditAncestryDto dto)
    {
        var result = await ancestryService.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await ancestryService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
