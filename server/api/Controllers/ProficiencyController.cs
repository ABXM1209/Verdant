using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProficiencyController(IProficiencyService proficiencyService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await proficiencyService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await proficiencyService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateProficiencyDto dto)
    {
        var result = await proficiencyService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditProficiencyDto dto) => Ok(await proficiencyService.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await proficiencyService.DeleteAsync(id)) ? NoContent() : NotFound();
}
