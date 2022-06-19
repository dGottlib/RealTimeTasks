using Microsoft.EntityFrameworkCore;

namespace Homework67_Tasks.Data
{
    public class TasksManagerContext : DbContext
    {
        private readonly string _connectionString;

        public TasksManagerContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
    }
}
