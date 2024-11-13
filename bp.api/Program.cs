using bp.api.Commands.Generic;
using bp.api.Extensions;
using bp.domain.Interfaces;
using bp.domain.Models;
using bp.efc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("postgres") ?? throw new ArgumentException("Database connectionstring is not defined in the appsettings");

builder.Services.AddDatabaseContext(connectionString);

builder.Services.AddBasicEndpointFunctionality<Customer>();
builder.Services.AddBasicEndpointFunctionality<Product>();
builder.Services.AddBasicEndpointFunctionality<Assignment>();
builder.Services.AddBasicEndpointFunctionality<AssignmentType>();

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