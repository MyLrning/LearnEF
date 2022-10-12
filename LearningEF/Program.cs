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

app.MapControllers();

app.Run();
