using TodolistApi.Data.Repos.Concretes;
using TodolistApi.Data.Repos.Interfaces;
using TodolistApi.Features.Todos.Services;

namespace TodolistApi.Extensions;

/// <summary>
/// Classe d'extension pour l'injection des dépendances.
/// </summary>
public static class DependencyExtensions
{
    /// <summary>
    /// Ajoute les services de repository.
    /// </summary>
    /// <param name="services">Collection des services.</param>
    /// <returns>Le même service appelant pour pouvoir enchaîner des appels multiples.</returns>
    public static IServiceCollection AddRepos(this IServiceCollection services)
    {
        services.AddScoped<ITodoRepo, TodoRepo>();
        return services;
    }

    /// <summary>
    /// Ajoute les services métiers.
    /// </summary>
    /// <param name="services">Collection des services.</param>
    /// <returns>Le même service appelant pour pouvoir enchaîner des appels multiples.</returns>
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}