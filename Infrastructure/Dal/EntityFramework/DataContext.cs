using cinema.Domain.Entities;
using cinema.Infrastructure.Dal.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinema.Infrastructure.Dal.EntityFramework
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Auditorium> auditoriums { get; set; }
        public DbSet<Seats> seats { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Screening> screenings { get; set; }
        public DbSet<Movie> movies { get; set; }
        public DbSet<MovieStatistic> movieStatistics { get; set; }
        public DbSet<ReservationStatistic> reservationStatistics { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new SeatsConfiguration());
            modelBuilder.ApplyConfiguration(new AuditoriumConfiguration());
            modelBuilder.ApplyConfiguration(new ScreeningConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationStatisticConfiguration());
            modelBuilder.ApplyConfiguration(new MovieStatisticConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

        }
    }
}
