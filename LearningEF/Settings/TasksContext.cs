using LearningEF.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningEF.Settings;

public class TasksContext: DbContext
{
    public DbSet<Duty> Tasks { get; set; }
    public DbSet<Category> Categories { get; set; }

    public TasksContext(DbContextOptions<TasksContext> options) : base(options) { }
    
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TasksDB;Trusted_Connection=True;");
    //}
}

