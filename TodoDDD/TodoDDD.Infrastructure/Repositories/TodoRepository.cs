using Microsoft.EntityFrameworkCore;
using TodoDDD.Domain.Entities;
using TodoDDD.Domain.Interfaces;
using TodoDDD.Infrastructure.Persistence;

namespace TodoDDD.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<TodoItem?> GetByIdAsync(Guid id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task AddAsync(TodoItem todo)
    {
        await _context.Todos.AddAsync(todo);
    }

    public void Update(TodoItem todo)
    {
        _context.Todos.Update(todo);
    }

    public void Delete(TodoItem todo)
    {
        _context.Todos.Remove(todo);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}