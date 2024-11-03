using cinema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cinema.Infrastructure.Dal.EntityFramework.Configuration
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.ReleaseDate)
                .HasColumnType("date")
                .IsRequired();
            builder.Property(x => x.FilmRentalDurationDays)
                .IsRequired();
            builder.Property(x => x.DurationMinuts)
                .IsRequired();
            builder.Property(x => x.ImageUrl)
                .IsRequired();
            builder.Property(x => x.Restriction)
                .IsRequired();
            builder.Property(x => x.Genre)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
