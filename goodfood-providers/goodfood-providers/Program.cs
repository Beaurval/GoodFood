using System.Text.Json.Serialization;
using goodfood_provider.Entities;
using goodfood_provider.Repositories;
using goodfood_provider.Repositories.Interfaces;
using goodfood_provider.Services;
using goodfood_provider.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProviderContext>(opt =>
    opt.UseInMemoryDatabase("Provider"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IProviderService, ProviderService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5001); // to listen for incoming http connection on port 5001
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}*/

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
