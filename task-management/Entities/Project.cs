namespace task_management.Entities
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public List<WorkTask> Tasks { get; set; }
    }
}
