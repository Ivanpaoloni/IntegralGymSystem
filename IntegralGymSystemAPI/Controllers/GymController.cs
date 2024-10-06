using IntegralGymSystem.Contracts.Services;
using IntegralGymSystem.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[Authorize(Policy = "SuperAdminOnly")] // Only admin access
public class GymController : ControllerBase
{
    private readonly IGymService _gymService;

    public GymController(IGymService gymService)
    {
        this._gymService = gymService;
    }

    [HttpGet]
    public async Task<IEnumerable<Gym>> GetGyms()
    {
        var gyms = await _gymService.GetAllAsync();
        return gyms;
    }

    [HttpGet("{id}")]
    public async Task<Gym> GetGym(Guid id)
    {
        return await _gymService.GetById(id);
    }

    [HttpPost]
    public async Task<Guid> CreateGym(Gym gym)
    {
        return await _gymService.CreateGymAsync(gym, saveChanges: true);
    }
}
