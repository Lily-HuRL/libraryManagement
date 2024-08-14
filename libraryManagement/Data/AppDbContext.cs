using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using libraryManagement.Models;

namespace libraryManagement.Data
{
    public class AppDbContext: DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalBooks> RentalBooks { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Customer>()
            //    .HasIndex(c => c.Phone)
            //    .IsUnique();

            //modelBuilder.Entity<Customer>()
            //    .HasIndex(c => c.Email)
            //    .IsUnique();
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            var property = typeof(AppDbContext).GetProperties()
            .FirstOrDefault(p => p.PropertyType == typeof(DbSet<T>));

            if (property != null)
            {
                return (DbSet<T>)property.GetValue(this);
            }

            throw new InvalidOperationException($"DbSet for type {typeof(T).Name} not found.");
        }
    }
}
