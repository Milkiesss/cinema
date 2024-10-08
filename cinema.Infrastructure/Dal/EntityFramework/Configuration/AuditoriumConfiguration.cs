using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Infrastructure.Dal.EntityFramework.Configuration
{
    public class AuditoriumConfiguration : IEntityTypeConfiguration<Auditorium>
    {
        public void Configure(EntityTypeBuilder<Auditorium> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Capacity)
                .IsRequired();
            builder.Property(x => x.Name)
                .IsRequired();
            builder.HasMany(x => x.Seats)
                .WithOne(x => x.Auditorium)
                .HasForeignKey(x => x.AuditoriumId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
}
