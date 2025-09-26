using Microsoft.EntityFrameworkCore;
using TodolistApi.Models;

namespace TodolistApi.Data;

public class TodolistDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }

    public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
    {
    }
}