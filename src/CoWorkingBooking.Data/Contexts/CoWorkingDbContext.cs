﻿using Microsoft.EntityFrameworkCore;
using CoWorkingBooking.Domain.Entities.Users;
using CoWorkingBooking.Domain.Entities.Orders;
using CoWorkingBooking.Domain.Entities.CoWorkings;

namespace CoWorkingBooking.Data.Contexts
{
    public class CoWorkingDbContext : DbContext
    {
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Payment> Payments  { get; set; }
        public virtual DbSet<CoWorking> CoWorkings { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }

        public CoWorkingDbContext(
           DbContextOptions<CoWorkingDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>()
                .HasIndex(p => p.OrderId)
                .IsUnique();

            modelBuilder.Entity<User>()
               .HasIndex(u => u.Username)
               .IsUnique();
        }
    }
}