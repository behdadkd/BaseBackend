using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Infrastructure.Persistence;
using BaseBackend.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<BaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IFirstService, FirstService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/Echo/{name}", (string name, IFirstService _firstService, CancellationToken cancellationToken) => _firstService.EchoAsync(name, cancellationToken)).WithName("Echo").WithOpenApi();
app.MapGet("/Save/{name}", (string name, IFirstService _firstService, CancellationToken cancellationToken) => _firstService.SaveAsync(name, cancellationToken)).WithName("Save").WithOpenApi();
app.MapGet("/Read/{id}", (long id, IFirstService _firstService, CancellationToken cancellationToken) => _firstService.ReadAsync(id, cancellationToken)).WithName("Read").WithOpenApi();

app.Run();

