using TrackService.Clients;
using Microsoft.EntityFrameworkCore;
using TrackService.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<CarServiceClient>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5036/");
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

app.UseHttpsRedirection();

app.MapControllers();

app.Run();