namespace CarService.Data;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

// CarDbContext database for CarService
public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
}