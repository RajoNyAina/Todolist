using System.Linq.Expressions;
using TodolistApi.Models;

namespace TodolistApi.Data.Repos.Interfaces;

/// <summary>
/// Repository pour les todo .
/// </summary>
public interface ITodoRepo
{
    /// <summary>
    /// Crée un todo.
    /// </summary>
    /// <param name="todo">Todo à créer.</param>
    /// <returns>Identifiant du nouveau todo créé.</returns>
    Task<int> CreateAsync(Todo todo);

    /// <summary>
    /// Récupère un todo par son identifiant.
    /// </summary>
    /// <param name="id">Identifiant du todo à récupéré.</param>
    /// <returns>Le todo correspondant à <paramref name="id"/> ou <c>null</c> si non trouvé.</returns>
    Task<Todo?> ReadByIdAsync(int id);

    /// <summary>
    /// Récupère un todo selon un filtre.
    /// </summary>
    /// <param name="filter">Filtre de récupération du todo.</param>
    /// <returns>Le premier todo respectant <paramref name="filter"/> ou <c>null</c> si aucun ne correspond.</returns>
    Task<Todo?> ReadOneAsync(Expression<Func<Todo, bool>> filter);

    /// <summary>
    /// Récupère tous les todo.
    /// </summary>
    /// <returns>Tous les todo.</returns>
    Task<IEnumerable<Todo>> ReadAllAsync();

    /// <summary>
    /// Récupère tous les todo respectant un filtre.
    /// </summary>
    /// <param name="filter">Filtre de récupération des todo.</param>
    /// <returns>Tous les todo respectant <paramref name="filter"/>.</returns>
    Task<IEnumerable<Todo>> ReadManyAsync(Expression<Func<Todo, bool>> filter);

    /// <summary>
    /// Met à jour un todo.
    /// </summary>
    /// <param name="todo">Todo à mettre à jour.</param>
    /// <returns>Tâche de mise à jour.</returns>
    Task UpdateAsync(Todo todo);

    /// <summary>
    /// Supprime un todo.
    /// </summary>
    /// <param name="todo">Todo à supprimer.</param>
    /// <returns>Tâche de suppression.</returns>
    Task DeleteAsync(Todo todo);
}