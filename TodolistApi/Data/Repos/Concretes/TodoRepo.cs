using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodolistApi.Data.Repos.Interfaces;
using TodolistApi.Models;

namespace TodolistApi.Data.Repos.Concretes;

/// <inheritdoc/>
public class TodoRepo : ITodoRepo
{
    private readonly TodolistDbContext _dbContext;

    /// <summary>
    /// Initialise une instance de <see cref="TodoRepo"/>.
    /// </summary>
    /// <param name="dbContext">Contexte de base de données.</param>
    public TodoRepo(TodolistDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc/>
    public async Task<int> CreateAsync(Todo todo)
    {
        await _dbContext.Todos.AddAsync(todo);
        await _dbContext.SaveChangesAsync();
        return todo.Id;
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Todo todo)
    {
        _dbContext.Todos.Remove(todo);
        await _dbContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Todo>> ReadAllAsync()
    {
        return await _dbContext.Todos.ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Todo?> ReadByIdAsync(int id)
    {
        return await _dbContext.Todos.FirstOrDefaultAsync(t => t.Id == id);
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<Todo>> ReadManyAsync(Expression<Func<Todo, bool>> filter)
    {
        return await _dbContext.Todos
            .Where(filter)
            .ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Todo?> ReadOneAsync(Expression<Func<Todo, bool>> filter)
    {
        return await _dbContext.Todos.FirstOrDefaultAsync(filter);
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(Todo todo)
    {
        _dbContext.Todos.Update(todo);
        await _dbContext.SaveChangesAsync();
    }
}