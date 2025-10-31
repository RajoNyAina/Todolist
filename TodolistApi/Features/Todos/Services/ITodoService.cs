using TodolistApi.Features.Todos.Dtos;

namespace TodolistApi.Features.Todos.Services;

/// <summary>
/// Service pour les traitements métiers de la gestion des todo.
/// </summary>
public interface ITodoService
{
    /// <summary>
    /// Crée un nouveau todo.
    /// </summary>
    /// <param name="dto">Informations du nouveau todo.</param>
    /// <returns>Le nouveau todo créé avec son identifiant unique et son statut.</returns>
    Task<ReadTodoDto> CreateAsync(CreateTodoDto dto);

    /// <summary>
    /// Récupère tous les todo.
    /// </summary>
    /// <returns>Liste de tous les todo.</returns>
    Task<IEnumerable<ReadTodoDto>> GetAllAsync();

    /// <summary>
    /// Récupère un todo à partir de son identifiant.
    /// </summary>
    /// <param name="id">Identifiant unique du todo.</param>
    /// <returns>Le todo correspondant à <paramref name="id"/> ou <c>null</c> si non trouvé.</returns>
    Task<ReadTodoDto?> GetByIdAsync(int id);

    /// <summary>
    /// Met à jour un todo.
    /// </summary>
    /// <param name="id">Identifiant du todo à mettre à jour.</param>
    /// <param name="dto"></param>
    /// <returns></returns>
    Task UpdateAsync(int id, UpdateTodoDto dto);

    /// <summary>
    /// Supprime un todo définitivement.
    /// </summary>
    /// <param name="id">Identifiant du todo à supprimer.</param>
    /// <returns></returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Récupère un statut de todo à partir de sa valeur.
    /// </summary>
    /// <param name="value">Valeur du statut à récupérer.</param>
    /// <returns>Statut de todo correspondant à la valeur donnée.</returns>
    TodoStatusDto? GetTodoStatusByValue(int value);

    /// <summary>
    /// Récupérer tous les statuts de todo.
    /// </summary>
    /// <returns>Liste de tous les statuts de todo.</returns>
    IEnumerable<TodoStatusDto> GetAllTodoStatus();
}