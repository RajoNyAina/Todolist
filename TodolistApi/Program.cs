using Microsoft.EntityFrameworkCore;
using TodolistApi.Data;
using TodolistApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodolistDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddRepos()
    .AddServices();

var app = builder.Build();

app.MapTodoEndpoints();

app.Run();
