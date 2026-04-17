using Client.Client;

builder.Services.AddHttpClient<CarServiceClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5036/");
});