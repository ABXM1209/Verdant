using Application.Common.Interfaces.Services.CRUD;
using Application.DTOs.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await userService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id) => Ok(await userService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto dto)
    {
        var result = await userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    public async Task<IActionResult> Update(EditUserDto dto) => Ok(await userService.UpdateAsync(dto));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id) => (await userService.DeleteAsync(id)) ? NoContent() : NotFound();
}
