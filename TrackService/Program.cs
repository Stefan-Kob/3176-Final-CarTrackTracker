using TrackService.Clients;
using Microsoft.EntityFrameworkCore;
using TrackService.Data;

var builder = WebApplication.CreateBuilder(args);

// For render.com
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var carServiceUrl = builder.Configuration["CarServiceUrl"];

builder.Services.AddHttpClient<CarServiceClient>(client =>
{
    client.BaseAddress = new Uri(carServiceUrl!);
});

builder.Services.AddDbContext<TrackServiceDbContext>(options =>
    options.UseInMemoryDatabase("TrackDb"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();