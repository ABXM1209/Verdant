using application.dtos.entities;
using domain.entities;
using domain.interfaces.repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AncestryController(
    IAncestryRepository ancestryRepository): BaseController
{

    [HttpGet(Name = "GetAllAncestries")]
    public async Task<IActionResult> GetAllAncestries()
    {
        var allAncestries = await ancestryRepository.GetAllAsync();
        return Ok(allAncestries);
    }

    [HttpPost(Name = "CreateAncestry")]
    public async Task<IActionResult> CreateAncestry(CreateAncestryDto ancestryDto)
    {
        var ancestry = new Ancestry
        {
            Name = ancestryDto.Name,
            Lifespan = ancestryDto.Lifespan,
            Size = ancestryDto.Size,
            Elements = ancestryDto.Elements
        };

        await ancestryRepository.AddAsync(ancestry);
        return Ok(ancestry);
    }
    
}