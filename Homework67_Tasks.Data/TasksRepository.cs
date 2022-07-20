using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework67_Tasks.Data
{
    public class TasksRepository
    {
        private readonly string _connectionString;

        public TasksRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<TaskItem> GetTasks()
        {
            var context = new TasksManagerContext(_connectionString);
            return context.TaskItems.Include(t => t.User).Where(t => t.Status != TaskStatus.Completed).ToList();
        }
        public void AddTaskItem(string title)
        {
            var context = new TasksManagerContext(_connectionString);

            if (title == null || title == "")
            {
                return;
            }

            var task = new TaskItem();
            task.Title = title;
            task.Status = TaskStatus.Pending;

            context.TaskItems.Add(task);
            context.SaveChanges();
        }
        public void MarkAsDoing(TaskItem taskItem, User user)
        {
            var context = new TasksManagerContext(_connectionString);

            if (taskItem.Status == TaskStatus.Pending)
            {
                taskItem.Status = TaskStatus.InProcess;
                taskItem.UserId = user.Id;
                context.TaskItems.Update(taskItem);
                context.SaveChanges();
            }
        }
        public void MarkAsDone(TaskItem taskItem)
        {
            var context = new TasksManagerContext(_connectionString);
            taskItem.Status = TaskStatus.Completed;
            context.TaskItems.Update(taskItem);
            context.SaveChanges();
        }
    }
}
