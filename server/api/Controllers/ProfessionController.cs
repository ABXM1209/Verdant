using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfessionController(IProfessionService professionService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await professionService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await professionService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateProfessionDto dto)
    {
        var result = await professionService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditProfessionDto dto) => Ok(await professionService.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await professionService.DeleteAsync(id)) ? NoContent() : NotFound();
}
