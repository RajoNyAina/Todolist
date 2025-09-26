using Microsoft.EntityFrameworkCore;
using TodolistApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodolistDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("default")));

var app = builder.Build();

app.Run();
