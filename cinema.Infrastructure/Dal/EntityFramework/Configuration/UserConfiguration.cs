using cinema.Domain.Entities;
using cinema.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Infrastructure.Dal.EntityFramework.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.OwnsOne(x => x.FullName, fullname =>
        {
            fullname.Property(n => n.firstName)
                .IsRequired();
            fullname.Property(n => n.lastName)
                .IsRequired();
        });
        builder.Property(x => x.Email)
            .IsRequired();
        builder.Property(x => x.BirthDate)
            .HasColumnType("timestamp with time zone")
            .IsRequired();
        builder.Property(x => x.Password)
            .IsRequired();
        
        builder.Property(x => x.Role)
            .IsRequired()
            .HasDefaultValue(EnumRole.User);
        
        builder.Property(x => x.Token)
            .IsRequired();
        
        builder.HasMany(x => x.Reservations)
            .WithOne(x => x.User)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}