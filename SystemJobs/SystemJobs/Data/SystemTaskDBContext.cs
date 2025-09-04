using Microsoft.EntityFrameworkCore;
using SystemJobs.Data.Map;
using SystemJobs.Models;

namespace SystemJobs.Data
{
    public class SystemTaskDBContext : DbContext
    {

        public SystemTaskDBContext(DbContextOptions<SystemTaskDBContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}
