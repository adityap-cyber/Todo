using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly TodoRepoInterface _repository;

    public TodosController(
        TodoRepoInterface repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _repository.GetByIdAsync(id);

        if (todo == null)
            return NotFound();

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        TodoItem todo)
    {
        await _repository.AddAsync(todo);

        return Ok(todo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        TodoItem todo)
    {
        todo.Id = id;

        await _repository.UpdateAsync(todo);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);

        return Ok();
    }
}