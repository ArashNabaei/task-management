namespace task_management.Entities
{
    public class SubTask
    {
        public int Id { get; set; }

        public string Titile { get; set; }

        public string Description { get; set; }

        public Status Status { get; set; }

        public Priority Priority { get; set; }

        public DateTime CreatedAt { get; set; }

        public int LoggedHours { get; set; }

        public int ParentId { get; set; }

        public Task ParentTask { get; set; }
    }
}
