namespace TrackService.Models;

// TrackSession model represents a single track session for a car
public class TrackSession
{
    public int Id { get; set; }
    public int CarId { get; set; }
    public string TrackName { get; set; }
    public double LapTime { get; set; }
}