using System.Collections.Generic;
using System.Threading.Tasks;

public interface TodoRepoInterface
{
    Task<List<TodoItem>> GetAllAsync();

    Task<TodoItem?> GetByIdAsync(int id);

    Task AddAsync(TodoItem todo);

    Task UpdateAsync(TodoItem todo);

    Task DeleteAsync(int id);
}