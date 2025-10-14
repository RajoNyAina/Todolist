namespace TodolistApi.Features.Todos.Dtos;

/// <summary>
/// Représente un DTO pour un statut de todo.
/// </summary>
/// <param name="Value">Valeur du statut.</param>
/// <param name="Label">Libellé du statut.</param>
public record TodoStatusDto(int Value, string Label);