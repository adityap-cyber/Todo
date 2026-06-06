using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TodoDDD.Domain.Entities;

namespace TodoDDD.Domain.Interfaces;

public interface ITodoRepository
{
    Task<List<TodoItem>> GetAllAsync();

    Task<TodoItem?> GetByIdAsync(Guid id);

    Task AddAsync(TodoItem todo);

    void Update(TodoItem todo);

    void Delete(TodoItem todo);

    Task SaveChangesAsync();
}