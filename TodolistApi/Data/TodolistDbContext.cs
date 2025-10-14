using Microsoft.EntityFrameworkCore;
using TodolistApi.Data.Converters;
using TodolistApi.Models;

namespace TodolistApi.Data;

/// <summary>
/// Contexte de base de données.
/// </summary>
public class TodolistDbContext : DbContext
{
    /// <summary>
    /// Représente les todo en base de données.
    /// </summary>
    public DbSet<Todo> Todos { get; set; }

    /// <summary>
    /// Initialise une instance de <see cref="TodolistDbContext"/>.
    /// </summary>
    /// <param name="options">Options de configuration de la connexion à la base de données.</param>
    public TodolistDbContext(DbContextOptions<TodolistDbContext> options) : base(options)
    {
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion<UtcDateTimeConverter>();
    }
}