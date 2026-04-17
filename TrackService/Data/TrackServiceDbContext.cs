namespace TrackService.Data;
using Microsoft.EntityFrameworkCore;
using TrackService.Models;

// TrackServiceDbContext database for TrackService
public class TrackServiceDbContext : DbContext
{
    public TrackServiceDbContext(DbContextOptions<TrackServiceDbContext> options) : base(options) { }

    public DbSet<TrackSession> TrackSessions { get; set; }
}