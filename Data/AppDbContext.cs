using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WhereToBingeFinal.Models;

namespace WhereToBingeFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<StreamingServices> StreamingServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string for your database
            optionsBuilder.UseSqlServer("Data Source=fontysgroopyswoopy.database.windows.net;Initial Catalog=WTB;Persist Security Info=True;User ID=beheerder;Password=Testtest!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<StreamingServices>()

                .Property(e => e.Netflix)
                .HasConversion<byte>();

            modelBuilder.Entity<StreamingServices>()

                .Property(e => e.AmazonPrime)
                .HasConversion<byte>();

            modelBuilder.Entity<StreamingServices>()

                .Property(e => e.DisneyPlus)
                .HasConversion<byte>();

            modelBuilder.Entity<StreamingServices>()

                .Property(e => e.HBO)
                .HasConversion<byte>();
        }
    }
}
