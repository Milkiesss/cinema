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
    public class ReservationStatisticConfiguration : IEntityTypeConfiguration<ReservationStatistic>
    {
        public void Configure(EntityTypeBuilder<ReservationStatistic> builder)
        {
            builder.HasKey(x => new { x.ReservationId, x.Userid });
            builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.Userid)
               .IsRequired();
            builder.HasOne(x => x.Reservation)
               .WithMany()
               .HasForeignKey(x => x.ReservationId)
               .IsRequired();
            builder.Property(x => x.Arrived)
                .IsRequired();
        }
    }
}
