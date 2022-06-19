using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Homework67_Tasks.Data
{
    public class TasksManagerContextFactory : IDesignTimeDbContextFactory<TasksManagerContext>
    {
        public TasksManagerContext CreateDbContext(string [] args)
        {
            var config = new ConfigurationBuilder()
              .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}Homework67_Tasks.Web"))
              .AddJsonFile("appsettings.json")
              .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new TasksManagerContext(config.GetConnectionString("ConStr"));
        }
    }
}
