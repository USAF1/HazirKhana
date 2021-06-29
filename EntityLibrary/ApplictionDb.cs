using EntityLibrary.CuisineManagment;
using EntityLibrary.LocationManagment;
using EntityLibrary.ProductsManagment;
using EntityLibrary.RestaurantManagment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLibrary
{
    public class ApplictionDb: DbContext
    {

        public DbSet<Cuisine> Cuisines { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Provience> Proviences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
        .HasIndex(u => new { u.Name , u.PostalCode })
        .IsUnique();

            modelBuilder.Entity<Provience>()
        .HasIndex(u => u.Name)
        .IsUnique();
        }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.; user id=sa; password=Charli1122#; Initial Catalog=HazirKhanaDB");
        }

    }
}
