namespace task_management.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public int ProjectId { get; set; }

        public int LoggedHours { get; set; }
    }
}
