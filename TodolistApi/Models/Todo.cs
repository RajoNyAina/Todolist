namespace TodolistApi.Models;

/// <summary>
/// Représente un todo.
/// </summary>
public class Todo
{
    /// <summary>
    /// Identifiant unique du todo.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Titre du todo.
    /// </summary>
    public required string Title { get; set; }

    /// <summary>
    /// Description optionnelle du todo.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Date d'échéance du todo.
    /// </summary>
    public DateTime DueDate { get; set; }

    /// <summary>
    /// Statut du todo : new - in progress - blocked - done.
    /// </summary>
    public required string Status { get; set; }
}