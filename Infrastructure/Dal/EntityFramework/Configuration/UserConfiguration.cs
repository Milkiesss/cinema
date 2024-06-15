using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace cinema.Infrastructure.Dal.EntityFramework.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.FullName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.Password)
                .HasMaxLength(100)
                .IsRequired();
            builder.HasMany(x => x.Reservations)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();
        }
    }
}
