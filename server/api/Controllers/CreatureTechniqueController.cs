using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CreatureTechniqueController(ICreatureTechniqueService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await service.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await service.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateCreatureTechniqueDto dto)
    {
        var result = await service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditCreatureTechniqueDto dto) => Ok(await service.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await service.DeleteAsync(id)) ? NoContent() : NotFound();
}
