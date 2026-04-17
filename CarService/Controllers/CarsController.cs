namespace CarService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarService.Data;
using CarService.Models;

// This controller provides endpoints for creating and retrieving cars in the CarService application.
[ApiController]
[Route("api/[controller]")]
public class CarsController : ControllerBase
{
    private readonly CarDbContext _context;

    public CarsController(CarDbContext context)
    {
        _context = context;
    }

    // Endpoint to create a car
    [HttpPost]
    public async Task<IActionResult> Create(Car car)
    {
        _context.Cars.Add(car);
        await _context.SaveChangesAsync();
        return Ok(car);
    }

    // Endpoint to retrieve a car by its ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var car = await _context.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }

        return Ok(car);
    }
}