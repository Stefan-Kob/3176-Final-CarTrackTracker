using Microsoft.EntityFrameworkCore;
namespace CarService.Data;

public class CarDbContext : DbContext
{
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
}