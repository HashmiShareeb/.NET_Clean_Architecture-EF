using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using crispy_winner.Domain.Entities;
namespace crispy_winner.infrastructure.context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Users>().HasKey(u => u.UserId);
            // modelBuilder.Entity<Categories>().HasKey(c => c.CategoryId);
            // modelBuilder.Entity<Transaction>().HasKey(t => new { t.UserId, t.CategoryId, t.Date });
            // modelBuilder.Entity<Budget>().HasKey(b => new { b.UserId, b.CategoryId, b.Month });

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    UserId = Guid.NewGuid(),
                    UserName = "Admin",
                    Email = "admin@example.com",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}