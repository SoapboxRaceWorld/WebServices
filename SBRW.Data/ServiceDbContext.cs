// This file is part of SBRW.Data by heyitsleo.
// 
// Created: 11/23/2019 @ 10:06 AM.

using Microsoft.EntityFrameworkCore;
using SBRW.Data.Entities;

namespace SBRW.Data
{
    public class ServiceDbContext : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        public ServiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Server>().Property(s => s.Category).HasConversion<string>();
            modelBuilder.Entity<ServerStats>().Property(s => s.Status).HasConversion<string>();
        }
    }
}