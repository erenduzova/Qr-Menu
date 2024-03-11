using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QrMenu.Models;

namespace QrMenu.Data
{
    public class QrMenuContext : DbContext
    {
        public QrMenuContext (DbContextOptions<QrMenuContext> options)
            : base(options)
        {
        }
        public DbSet<QrMenu.Models.State>? States { get; set; }
        public DbSet<QrMenu.Models.Company>? Companies { get; set; }
        public DbSet<QrMenu.Models.Restaurant>? Restaurants { get; set; }
        public DbSet<QrMenu.Models.Category>? Categories { get; set; }
        public DbSet<QrMenu.Models.Food>? Foods { get; set; }
        public DbSet<QrMenu.Models.User>? Users { get; set; }
        public DbSet<QrMenu.Models.RestaurantUser>? RestaurantUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RestaurantUser>().HasKey(ru => new { ru.RestaurantId, ru.UserId });
        }
    }
}
