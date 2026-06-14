using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TechniqueController(ITechniqueService techniqueService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await techniqueService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await techniqueService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateTechniqueDto dto)
    {
        var result = await techniqueService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditTechniqueDto dto) => Ok(await techniqueService.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await techniqueService.DeleteAsync(id)) ? NoContent() : NotFound();
}
