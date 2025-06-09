using Microsoft.EntityFrameworkCore;
using TeamTaskManager.API.Data;
using Microsoft.EntityFrameworkCore; // For UseInMemoryDatabase
using Microsoft.OpenApi.Models;      // For Swagger configuration
using Microsoft.AspNetCore.Builder; // For WebApplication

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TeamTaskManagerDb"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
