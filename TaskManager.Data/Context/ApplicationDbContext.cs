using TaskManager.Data.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManager.Data.Task.Entities;
using TaskManager.Data.User.Entities;

namespace TaskManager.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> roles { get; set; }
        public DbSet<UserEntity> users { get; set; }
        public DbSet<UserEntity> taskStatuses { get; set; }
        public DbSet<TaskEntity> tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<TaskEntity>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<Entities.TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatuses");
                entity.HasKey(e => e.Id);
            });
        }
    }
}
