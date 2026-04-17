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

    // Returns all the track sessions
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sessions = await _context.TrackSessions.ToListAsync();
        return Ok(sessions);
    }

    // Calls the other service to check if the car exists before creating a track session
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