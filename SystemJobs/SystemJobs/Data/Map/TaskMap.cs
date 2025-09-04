using Microsoft.EntityFrameworkCore;
using SystemJobs.Models;

namespace SystemJobs.Data.Map
{
    public class TaskMap : IEntityTypeConfiguration<TaskModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<TaskModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
        }
    }
}
