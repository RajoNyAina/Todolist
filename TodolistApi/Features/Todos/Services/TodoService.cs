using System.Linq;
using TodolistApi.Data.Repos.Interfaces;
using TodolistApi.Features.Todos.Dtos;
using TodolistApi.Features.Todos.Enums;
using TodolistApi.Models;

namespace TodolistApi.Features.Todos.Services;

/// <inheritdoc/>
public class TodoService : ITodoService
{
    private readonly ITodoRepo _todoRepo;

    /// <summary>
    /// Initialise une instance de <see cref="TodoService"/>.
    /// </summary>
    /// <param name="todoRepo">Repository pour les todo.</param>
    public TodoService(ITodoRepo todoRepo)
    {
        _todoRepo = todoRepo;
    }

    /// <inheritdoc/>
    public async Task<ReadTodoDto> CreateAsync(CreateTodoDto dto)
    {
        ArgumentNullException.ThrowIfNull(dto, nameof(dto));

        var todo = new Todo
        {
            Title = dto.Title,
            Description = dto.Description,
            DueDate = dto.DueDate,
            Status = TodoStatus.New.ToString()
        };
        var createdTodoId = await _todoRepo.CreateAsync(todo);

        return new ReadTodoDto(createdTodoId, todo.Title, todo.Description, todo.DueDate, Enum.Parse<TodoStatus>(todo.Status));
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<ReadTodoDto>> GetAllAsync()
    {
        return (await _todoRepo.ReadAllAsync()).Select(todo => new ReadTodoDto
        (
            todo.Id,
            todo.Title,
            todo.Description,
            todo.DueDate,
            Enum.Parse<TodoStatus>(todo.Status, ignoreCase: true)
        ));
    }

    /// <inheritdoc/>
    public async Task<ReadTodoDto?> GetByIdAsync(int id)
    {
        var todo = await _todoRepo.ReadByIdAsync(id);
        if (todo != null)
        {
            return new ReadTodoDto
            (
                todo.Id,
                todo.Title,
                todo.Description,
                todo.DueDate,
                Enum.Parse<TodoStatus>(todo.Status, ignoreCase: true)
            );
        }

        return null;
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(int id, UpdateTodoDto dto)
    {
        if (id != dto.Id)
        {
            throw new ArgumentException("L'identifiant du todo à mettre à jour ne correspond pas à l'identifiant fourni.");
        }

        var existingTodo = await _todoRepo.ReadByIdAsync(id) ?? throw new NullReferenceException();
        var possibleTodoStatusChange = GetPossibleTodoStatusChange(Enum.Parse<TodoStatus>(existingTodo.Status));
        if (!possibleTodoStatusChange.Contains(dto.Status))
        {
            throw new ArgumentException($"Impossible de changer de statut {existingTodo.Status} en {dto.Status}");
        }

        existingTodo.Title = dto.Title;
        existingTodo.Description = dto.Description;
        existingTodo.DueDate = dto.DueDate;
        existingTodo.Status = dto.Status.ToString();

        await _todoRepo.UpdateAsync(existingTodo);
    }

    /// <inheritdoc/>
    public TodoStatusDto? GetTodoStatusByValue(int value)
    {
        var status = Enum.GetName((TodoStatus)value);
        return string.IsNullOrEmpty(status) ? null : new TodoStatusDto(value, status);
    }

    /// <inheritdoc/>
    public IEnumerable<TodoStatusDto> GetAllTodoStatus()
    {
        return Enum.GetValues<TodoStatus>().Select(s => new TodoStatusDto((int)s, s.ToString()));
    }

    private static TodoStatus[] GetPossibleTodoStatusChange(TodoStatus status)
    {
        return status switch
        {
            TodoStatus.New => [.. Enum.GetValues<TodoStatus>().Except([TodoStatus.Done])],
            TodoStatus.InProgress or
                TodoStatus.Done or
                TodoStatus.Cancelled or
                TodoStatus.Blocked or
                TodoStatus.Archived or
                TodoStatus.Deleted => [.. Enum.GetValues<TodoStatus>().Except([TodoStatus.New])],
            _ => [],
        };
    }
}