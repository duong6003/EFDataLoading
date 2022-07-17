using Microsoft.AspNetCore.Mvc;
using Web.EntitiesDTO;
using Web.Services;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class PrizeController : ControllerBase
{
    private readonly IPrizeService PrizeService;

    public PrizeController(IPrizeService PrizeService)
    {
        this.PrizeService = PrizeService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(AddPrize request)
    {
        string? error = await PrizeService.CreateAsync(request);
        if(error != null) return BadRequest(error);
        return Ok("Success");
    }
    [HttpPost("{id}/items")]
    public async Task<IActionResult> CreatePrizeItemAsync(string id, List<AddPrizeItem> request)
    {
        string? error = await PrizeService.CreateItemAsync(id, request);
        if(error != null) return BadRequest(error);
        return Ok("Success");
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await PrizeService.GetAllAsync());
    }
}
