using Microsoft.EntityFrameworkCore;
using TeamTaskManager.API.Models;

// Alias the Task model to avoid conflict with System.Threading.Tasks.Task
using TaskModel = TeamTaskManager.API.Models.Task;

namespace TeamTaskManager.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<TaskModel> Tasks { get; set; } = null!;
    }
}
