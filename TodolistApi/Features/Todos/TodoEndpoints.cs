using TodolistApi.Features.Todos.Dtos;
using TodolistApi.Features.Todos.Services;

namespace TodolistApi.Features.Todos;

/// <summary>
/// Définit les endpoints pour la gestion des todo.
/// </summary>
public static class TodoEndpoints
{
    private const string PREFIX = "/todo";

    /// <summary>
    /// Ajoute les endpoints de traitement des todo.
    /// </summary>
    /// <param name="routeBuilder">Générateur de routes pour l'application.</param>
    public static void Map(IEndpointRouteBuilder routeBuilder)
    {
        var group = routeBuilder.MapGroup(PREFIX);

        group.MapPost(string.Empty, Create);

        group.MapGet(string.Empty, Get);
        group.MapGet("/{id}", GetById);
        group.MapGet("/status", GetAllStatus);
        group.MapGet("/status/{value}", GetStatusByValue);

        group.MapPut("/{id}", Update);
    }

    private static IResult GetStatusByValue(ITodoService todoService, int value)
    {
        var status = todoService.GetTodoStatusByValue(value);
        if (status == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(status);
    }

    private static IResult GetAllStatus(ITodoService todoService)
    {
        return Results.Ok(todoService.GetAllTodoStatus());
    }

    private static async Task<IResult> Update(ITodoService todoService, int id, UpdateTodoDto dto)
    {
        try
        {
            await todoService.UpdateAsync(id, dto);
            return Results.Ok();
        }
        catch (NullReferenceException)
        {
            return Results.NotFound();
        }
        catch (ArgumentException ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }

    private static async Task<IResult> GetById(ITodoService todoService, int id)
    {
        var todo = await todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(todo);
    }

    private static async Task<IResult> Get(ITodoService todoService)
    {
        var todos = await todoService.GetAllAsync();
        return Results.Ok(todos);
    }

    private static async Task<IResult> Create(ITodoService todoService, CreateTodoDto dto)
    {
        try
        {
            var todo = await todoService.CreateAsync(dto);
            return Results.Created($"{PREFIX}/{todo.Id}", todo);
        }
        catch (Exception ex)
        {
            return Results.BadRequest(ex.Message);
        }
    }
}