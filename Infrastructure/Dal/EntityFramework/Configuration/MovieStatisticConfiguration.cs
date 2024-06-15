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
    public class MovieStatisticConfiguration : IEntityTypeConfiguration<MovieStatistic>
    {
        public void Configure(EntityTypeBuilder<MovieStatistic> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Movie)
                .WithOne()
                .HasForeignKey<MovieStatistic>(x => x.MovieId);
            builder.Property(x => x.BoxOfficeReceipts)
                .IsRequired();
        }
    }
}
