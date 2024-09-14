using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Context;
using TaskManager.Data.Task.Repository;
using TaskManager.Data.User.Repository;
using TaskManager.Domain.Task.Repository;
using TaskManager.Domain.User.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Context Configuration
string? connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options.UseSqlServer(connectionString));

// ADD SCOPES
builder.Services.AddScoped<IUsersRepository, UserRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
