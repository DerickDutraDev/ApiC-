using Microsoft.EntityFrameworkCore;
using SystemJobs.Models;

namespace SystemJobs.Data.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
        }
    }
}
