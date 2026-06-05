using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<TodoRepoInterface, TodoRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();