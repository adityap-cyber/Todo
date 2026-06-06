using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using TodoDDD.Domain.Entities;
using TodoDDD.Domain.Interfaces;

namespace TodoDDD.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoRepository _repository;

    public TodoController(ITodoRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var todos = await _repository.GetAllAsync();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        var todo = new TodoItem(title);

        await _repository.AddAsync(todo);
        await _repository.SaveChangesAsync();

        return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, string title)
    {
        var todo = await _repository.GetByIdAsync(id);

        if (todo is null)
            return NotFound("Todo not found");

        todo.UpdateTitle(title);

        _repository.Update(todo);
        await _repository.SaveChangesAsync();

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var todo = await _repository.GetByIdAsync(id);

        if (todo is null)
            return NotFound("Todo not found");

        _repository.Delete(todo);
        await _repository.SaveChangesAsync();

        return NoContent();
    }
}