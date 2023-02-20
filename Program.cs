using Microsoft.AspNetCore.Authentication;
using DatabaseContext;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using Interfaces;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<MyDbContext>(opt =>
    opt.UseInMemoryDatabase("RideList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<ICredentials, CredentialServices>();
    services.AddScoped<IBookedRide, BookedRideServices>();
    services.AddScoped<IOfferedRide, OfferedRideServices>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
