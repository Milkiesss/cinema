using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Infrastructure.Dal.EntityFramework.Configuration;

public class ScreeningStatisticConfiguration : IEntityTypeConfiguration<ScreeningStatistic>
{
    public void Configure(EntityTypeBuilder<ScreeningStatistic> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Screening)
            .WithOne()
            .HasForeignKey<ScreeningStatistic>(x => x.ScreeningId)
            .IsRequired();
        builder.Property(x => x.ScreeningDate)
            .HasColumnType("date")
            .IsRequired();
        builder.Property(x => x.SeatOccupancy);
    }
}