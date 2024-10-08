using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Infrastructure.Dal.EntityFramework.Configuration
{
    public class SeatsConfiguration : IEntityTypeConfiguration<Seats>
    {
        public void Configure(EntityTypeBuilder<Seats> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Auditorium)
                .WithMany(a => a.Seats)
                .HasForeignKey(x => x.AuditoriumId)
                .IsRequired();
            builder.Property(x => x.SeatNumber)
                .IsRequired();
            builder.Property(x => x.RowNumber)
                .IsRequired();
            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
