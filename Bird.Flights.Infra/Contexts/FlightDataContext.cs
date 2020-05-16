using Bird.Flights.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bird.Flights.Infra.Contexts {
    public class FlightDataContext : DbContext
    {
        public FlightDataContext(DbContextOptions<FlightDataContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }

/*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TodoItem>().ToTable("Todo");
            modelBuilder.Entity<TodoItem>().Property(x => x.Id);
            modelBuilder.Entity<TodoItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<TodoItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<TodoItem>().Property(x => x.Date);
            modelBuilder.Entity<TodoItem>().HasIndex(b => b.User);
            
        }
*/
    }
}
