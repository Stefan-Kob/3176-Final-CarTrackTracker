namespace Client.Client;

// Car service client to check if a car exists in the database
public class CarServiceClient
{
    private readonly HttpClient _httpClient;

    public CarServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> CarExists(int carId)
    {
        var response = await _httpClient.GetAsync($"api/cars/{carId}");
        return response.IsSuccessStatusCode;
    }
}