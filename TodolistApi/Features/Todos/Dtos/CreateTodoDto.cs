namespace TodolistApi.Features.Todos.Dtos;

/// <summary>
/// Représente un DTO de création de todo.
/// </summary>
/// <param name="Title">Titre du todo.</param>
/// <param name="Description">Description du todo.</param>
/// <param name="DueDate">Date d'échéance du todo.</param>
public record CreateTodoDto(string Title, string? Description, DateTime DueDate);