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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Screening)
                .WithMany()
                .HasForeignKey(x => x.ScreeningId)
                .IsRequired();
            builder.HasOne(x => x.Seat)
                .WithMany()
                .HasForeignKey(x => x.SeatId)
                .IsRequired();
            builder.HasOne(x => x.User)
               .WithMany(u => u.Reservations)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
        }
    }
}
