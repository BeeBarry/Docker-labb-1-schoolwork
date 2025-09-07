using Microsoft.EntityFrameworkCore;
using BackendApi.Models;

namespace BackendApi.Data;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }
    
    public DbSet<TodoTask> TodoTasks { get; set; } = default!;
}