using System.Text.Json.Serialization;

namespace Homework67_Tasks.Data
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
