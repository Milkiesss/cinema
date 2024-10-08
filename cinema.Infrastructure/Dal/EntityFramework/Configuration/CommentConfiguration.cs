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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasIndex(x => x.Id);
            builder.HasOne(x => x.Movie)
                .WithMany(a => a.Comments)
                .HasForeignKey(x => x.MovieId);
            builder.HasOne(x => x.User)
               .WithMany()
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.Property(x => x.Text)
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
