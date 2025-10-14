using TodolistApi.Features.Todos;

namespace TodolistApi.Extensions;

/// <summary>
/// Classe d'extension du générateur de route pour l'application.
/// </summary>
public static class EndpointRouteBuilderExtensions
{
    /// <summary>
    /// Ajoute les endpoints de traitement des todo.
    /// </summary>
    /// <param name="routeBuilder">Générateur de routes pour l'application.</param>
    /// <returns>Le même service appelant pour pouvoir enchaîner des appels multiples.</returns>
    public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        TodoEndpoints.Map(routeBuilder);
        return routeBuilder;
    }
}