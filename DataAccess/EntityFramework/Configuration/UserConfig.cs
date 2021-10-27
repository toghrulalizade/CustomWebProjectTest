using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityFramework.Configuration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(p => p.IsConfirmed).IsRequired().HasDefaultValue(false);

            builder.HasIndex(p => p.Email ).IsUnique();
            builder.HasIndex(p => p.Username ).IsUnique();
        }
    }
}
