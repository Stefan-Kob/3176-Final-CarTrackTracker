namespace TrackService.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackService.Data;
using TrackService.Models;
using TrackService.Clients;

// Controller for managing track sessions
[ApiController]
[Route("api/[controller]")]
public class TrackController : ControllerBase
{
    private readonly TrackServiceDbContext _context;
    private readonly CarServiceClient _carClient;

    public TrackController(TrackServiceDbContext context, CarServiceClient carClient)
    {
        _context = context;
        _carClient = carClient;
    }

    // Get all track sessions
    [HttpPost]
    public async Task<IActionResult> CreateSession(TrackSession session)
    {
        var exists = await _carClient.CarExists(session.CarId);
        if (!exists)
        {
            return BadRequest("Car does not exist");
        }

        _context.TrackSessions.Add(session);
        await _context.SaveChangesAsync();

        return Ok(session);
    }
}