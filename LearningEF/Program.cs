using LearningEF.Models;
using LearningEF.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<TasksContext>(options => options.UseInMemoryDatabase("TasksDB"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("Tasks"));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConnection", ([FromServices] TasksContext dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Task.FromResult(Results.Ok($"Database established in memory: {dbContext.Database.IsInMemory()}"));
});

app.MapGet("/api/tasks", ([FromServices] TasksContext dbContext) =>
{
    var tasks = dbContext.Tasks.Include(t => t.Category).ToList();
    return Task.FromResult(Results.Ok(tasks));
});

app.MapPost("/api/tasks", async ([FromServices] TasksContext dbContext, [FromBody] Duty task) =>
{
    task.CreateDate = DateTime.Now;

    await dbContext.Tasks.AddAsync(task);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapPut("/api/tasks/{id:int}", async ([FromServices] TasksContext dbContext, [FromBody] Duty task, [FromRoute] int id) =>
{
    var taskToUpdate = dbContext.Tasks.Find(id);

    if (taskToUpdate == null)
    {
        return Results.NotFound();
    }

    taskToUpdate.CategoryId = task.CategoryId;
    taskToUpdate.Title = task.Title;
    taskToUpdate.Description = task.Description;
    taskToUpdate.Priority = task.Priority;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/api/tasks/{id:int}", async ([FromServices] TasksContext dbContext, [FromRoute] int id) =>
{
    var taskToDelete = dbContext.Tasks.Find(id);

    if (taskToDelete == null)
    {
        return Results.NotFound();
    }

    dbContext.Tasks.Remove(taskToDelete);

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapControllers();

app.Run();
