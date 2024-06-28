using System;
using APICrud.Models;
using Microsoft.EntityFrameworkCore;

namespace APICrud.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Country> Countries { get; set; }
		public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                       .HasData(
            new City
            {
                Id = 1,
                Name = "Baku",
                CountryId = 1
            },

            new City
            {
                Id = 2,
                Name = "Shusha",
                CountryId = 1
            },

            new City
            {
                Id = 3,
                Name = "Ankara",
                CountryId = 2
            },

            new City
            {
                Id = 4,
                Name = "Istanbul",
                CountryId = 2
            },

            new City
            {
                Id = 5,
                Name = "Toronto",
                CountryId = 3
            }
           );

            modelBuilder.Entity<Country>()
                        .HasData(
            new Country
            {
                Id = 1,
                Name = "Azerbaycan",
            },

            new Country
            {
                Id = 1,
                Name = "Turkiye"
            },

            new Country
            {
                Id = 1,
                Name = "Canada",
            }
           );
        }
    }
}

