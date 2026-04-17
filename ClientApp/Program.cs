using System.Net.Http.Json;

// Console app to test API's
var client = new HttpClient();

// TrackService port
client.BaseAddress = new Uri("http://localhost:5167/");

// Create a track session
var session = new
{
    carId = 1,
    trackName = "Canadian Tire DDT",
    lapTime = 117.48
};

Console.WriteLine("(POST) Sending track session...");

var response = await client.PostAsJsonAsync("api/track", session);
var result = await response.Content.ReadAsStringAsync();

// Post response
Console.WriteLine("POST Response:");
Console.WriteLine(result);

Console.WriteLine("\n(GET) Fetching all track sessions...");

var getResponse = await client.GetAsync("api/track");
var getResult = await getResponse.Content.ReadAsStringAsync();

// Get response
Console.WriteLine("GET Response:");
Console.WriteLine(getResult);

Console.WriteLine("\n(GET) Fetching car THROUGH TrackService...");

var carResponse = await client.GetAsync("api/track/car/1");
var carResult = await carResponse.Content.ReadAsStringAsync();
