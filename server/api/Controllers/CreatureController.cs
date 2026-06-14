using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreatureController(ICreatureService creatureService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await creatureService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await creatureService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCreatureDto dto)
    {
        var result = await creatureService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditCreatureDto dto)
    {
        var result = await creatureService.UpdateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await creatureService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}
