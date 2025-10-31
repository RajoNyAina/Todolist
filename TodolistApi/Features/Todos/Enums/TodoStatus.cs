namespace TodolistApi.Features.Todos.Enums;

/// <summary>
/// Enumération des statuts possibles pour un todo.
/// </summary>
public enum TodoStatus : int
{
    /// <summary>
    /// Statut de todo nouvellement créé.
    /// </summary>
    New,

    /// <summary>
    /// Statut de todo en cours.
    /// </summary>
    InProgress,

    /// <summary>
    /// Statut de todo terminé.
    /// </summary>
    Done,

    /// <summary>
    /// Statut de todo annulé.
    /// </summary>
    Cancelled,

    /// <summary>
    /// Statut de todo bloqué.
    /// </summary>
    Blocked,

    /// <summary>
    /// Statut de todo archivé.
    /// </summary>
    Archived,

    /// <summary>
    /// Statut de todo supprimé.
    /// </summary>
    Deleted
}