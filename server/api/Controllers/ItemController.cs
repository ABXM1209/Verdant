using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemController(IItemService itemService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await itemService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await itemService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateItemDto dto)
    {
        var result = await itemService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditItemDto dto) => Ok(await itemService.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await itemService.DeleteAsync(id)) ? NoContent() : NotFound();
}
