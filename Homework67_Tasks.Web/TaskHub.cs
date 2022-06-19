using Homework67_Tasks.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskStatus = Homework67_Tasks.Data.TaskStatus;

namespace Homework67_Tasks.Web
{
    public class TaskHub : Hub
    {
        private readonly string _connectionString;
        public TaskHub(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [Authorize]
        public void GetTasks()
        {
            var repo = new TasksRepository(_connectionString);
            Clients.All.SendAsync("getTasks", repo.GetTasks());
        }
        [Authorize]
        public void AddTask(string title)
        {
            var repo = new TasksRepository(_connectionString);
            repo.AddTaskItem(title);
            Clients.All.SendAsync("addTask", repo.GetTasks());
        }
        [Authorize]
        public void MarkAsDoing(TaskItem taskItem)
        {
            var repo = new TasksRepository(_connectionString);
            var user = GetCurrentUser();
            if(user != null)
            {
                repo.MarkAsDoing(taskItem, user);
            }

            Clients.All.SendAsync("markAsDoing",repo.GetTasks());
        }
        [Authorize]
        public void MarkAsDone(TaskItem taskItem)
        {
            var user = GetCurrentUser();
            if (user.Id != taskItem.UserId)
            {
                return;
            }

            var repo = new TasksRepository(_connectionString);
            
            if (user != null)
            {
                repo.MarkAsDone(taskItem);
            }

            Clients.All.SendAsync("markAsDone", repo.GetTasks());
        }
        private User GetCurrentUser()
        {
            var userRepo = new UserRepository(_connectionString);
            var user = userRepo.GetByEmail(Context.User.Identity.Name);
            return user;
        }
    }   
}
