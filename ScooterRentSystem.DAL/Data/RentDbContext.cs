using Microsoft.EntityFrameworkCore;
using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.DAL.Data
{
    public class RentDbContext : DbContext
    {
        public RentDbContext(DbContextOptions<RentDbContext> options)
            : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Scooter> Scooters { get; set; }
        public DbSet<City> Cities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
