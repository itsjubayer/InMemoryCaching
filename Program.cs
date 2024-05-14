using InMemoryCaching.Data;
using InMemoryCaching.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDBContext") ?? throw new InvalidOperationException("Connection string 'AppDBContext' not found.")));
//builder.Services.AddDbContext<AppContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));

builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBConnectionString")));

builder.Services.AddMemoryCache();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
