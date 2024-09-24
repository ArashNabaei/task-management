namespace task_management.Entities
{
    public class WorkTask
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Status? Status { get; set; }

        public Priority? Priority { get; set; }

        public int ProjectId { get; set; }

        public Project? Project { get; set; }

        public int LoggedHours { get; set; }

        public List<SubTask>? SubTasks { get; set; }
    }
}
