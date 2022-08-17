using System.Text.Json.Serialization;
using goodfood_orders.Entities;
using goodfood_orders.Repositories;
using goodfood_orders.Repositories.Interfaces;
using goodfood_orders.Services;
using goodfood_orders.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

builder.Services.AddDbContext<OrderContext>(opt =>
    opt.UseInMemoryDatabase("Orders"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ILineRepository, LineRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ILineService, LineService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
