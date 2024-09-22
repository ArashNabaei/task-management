using Microsoft.EntityFrameworkCore;
using task_management.Entities;

namespace task_management.Persistence
{
    public class EfContext : DbContext
    {

        public EfContext(DbContextOptions<EfContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        
        public DbSet<Entities.Task> Tasks { get; set; }
        
        public DbSet<SubTask> SubTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Project>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Project>()
               .HasOne<User>(p => p.User)
               .WithMany(u => u.Projects)
               .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Entities.Task>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Entities.Task>()
               .HasOne<Project>(t => t.Project)
               .WithMany(p => p.Tasks)
               .HasForeignKey(t => t.ProjectId);

            modelBuilder.Entity<SubTask>()
               .HasKey(st => st.Id);

            modelBuilder.Entity<SubTask>()
                .HasOne<Entities.Task>(st => st.ParentTask)
                .WithMany(t => t.SubTasks)
                .HasForeignKey(st => st.ParentId);
        }

    }
}
