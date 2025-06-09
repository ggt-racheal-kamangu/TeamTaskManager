using System;

namespace TeamTaskManager.API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public int AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }
    }
}
