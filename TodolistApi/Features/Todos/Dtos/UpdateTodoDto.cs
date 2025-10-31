using TodolistApi.Features.Todos.Enums;

namespace TodolistApi.Features.Todos.Dtos;

/// <summary>
/// Représente un DTO pour la mise à jour d'un todo.
/// </summary>
/// <param name="Id">Identifiant unique du todo.</param>
/// <param name="Title">Titre du todo.</param>
/// <param name="Description">Description du todo.</param>
/// <param name="DueDate">Date d'échéance du todo.</param>
/// <param name="Status">Statut du todo.</param>
public record UpdateTodoDto(int Id, string Title, string? Description, DateTime DueDate, TodoStatus Status);