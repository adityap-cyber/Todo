using Microsoft.EntityFrameworkCore;
using TodoDDD.Domain.Entities;

namespace TodoDDD.Infrastructure.Persistence;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> Todos => Set<TodoItem>();
}