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
    public class ScreeningConfiguration : IEntityTypeConfiguration<Screening>
    {
        public void Configure(EntityTypeBuilder<Screening> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Movie)
                .WithMany()
                .HasForeignKey(x => x.MovieId)
                .IsRequired();
            builder.Property(x => x.StartScreening)
                .HasColumnType("timestamptz")
                .IsRequired();
            builder.Property(x => x.EndScreening)
                .HasColumnType("timestamptz")
                .IsRequired();
            builder.HasOne(x => x.Auditorium)
                .WithMany()
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();
        }
    }
}
