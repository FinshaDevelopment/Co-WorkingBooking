using CoWorkingBooking.Domain.Entities.CoWorkings;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace CoWorkingBooking.Data.Contexts
{
    public class CoWorkingDbContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<CoWorking> CoWorkings { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        public CoWorkingDbContext(
           DbContextOptions<CoWorkingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasIndex(u => u.Username)
               .IsUnique();
        }
    }
}
