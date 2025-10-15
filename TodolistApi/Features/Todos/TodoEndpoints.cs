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

        group.MapDelete("/{id}", Delete);
    }

    /// <summary>
    /// Handler du endpoint permettant de récupérer un statut de todo à partir de sa valeur.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <param name="value">Valeur du statut de todo à récupérer.</param>
    /// <returns>Une réponse HTTP 200 contenant le statut demandé ou une réponse HTTP 404 si le statut est introuvable.</returns>
    private static IResult GetStatusByValue(ITodoService todoService, int value)
    {
        var status = todoService.GetTodoStatusByValue(value);
        if (status == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(status);
    }

    /// <summary>
    /// Handler permettant de récupérer tous les statuts de todo.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <returns>Une réponse HTTP 200 contenant la liste de tous les statuts de todo.</returns>
    private static IResult GetAllStatus(ITodoService todoService)
    {
        return Results.Ok(todoService.GetAllTodoStatus());
    }

    /// <summary>
    /// Handler permettant de supprimer un todo définitivement.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <param name="id">Identifiant du todo à supprimer.</param>
    /// <returns></returns>
    private static async Task<IResult> Delete(ITodoService todoService, int id)
    {
        await todoService.DeleteAsync(id);
        return Results.Ok();
    }

    /// <summary>
    /// Handler permettant de mettre à jour un todo.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <param name="id">Identifiant du todo à mettre à jour.</param>
    /// <param name="dto">Informations sur la mise à jour du todo.</param>
    /// <returns>
    /// Une réponse HTTP 200 si la mise à jour est réussi.
    /// Une réponse HTTP 404 si le todo à mettre à jour est introuvable.
    /// Une réponse HTTP 401 si des erreurs se sont produites.
    /// </returns>
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

    /// <summary>
    /// Handler du endpoint permettant de récupérer un todo à partir de son identifiant.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <param name="id">Identifiant du todo à récupérer.</param>
    /// <returns>Une réponse HTTP 200 contenant le todo demandé ou une réponse HTTP 404 si le todo n'est pas trouvé.</returns>
    private static async Task<IResult> GetById(ITodoService todoService, int id)
    {
        var todo = await todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return Results.NotFound();
        }

        return Results.Ok(todo);
    }

    /// <summary>
    /// Handler du endpoint permettant de récupérer la liste des todo.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <returns>Une réponse HTTP 200 contenant la liste des todo.</returns>
    private static async Task<IResult> Get(ITodoService todoService)
    {
        var todos = await todoService.GetAllAsync();
        return Results.Ok(todos);
    }

    /// <summary>
    /// Handler du endpoint permettant de créer un todo.
    /// </summary>
    /// <param name="todoService">Service de traitement métier des todo.</param>
    /// <param name="dto">Informations sur le todo à créer.</param>
    /// <returns>Une réponse HTTP 201 contenant le todo créé ou une réponse HTTP 400 en cas d'erreur.</returns>
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