﻿using Microsoft.EntityFrameworkCore;
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

    }
}
