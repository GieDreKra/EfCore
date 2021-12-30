using Microsoft.EntityFrameworkCore;
using RegistrationItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<RegistrationItem> RegistrationItems { get; set; }
        public DbSet<Value> Values { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistrationItem>().HasData(new RegistrationItem()
            {
                Id = 1,
                Name = "Reikia atlikti rangos darbus"
            }, new RegistrationItem()
            {
                Id = 2,
                Name = "Rangos darbus atliks"
            }, new RegistrationItem()
            {
                Id = 3,
                Name = "Verslo klientas"
            }, new RegistrationItem()
            {
                Id = 4,
                Name = "Skaičiavimo metodas"
            }, new RegistrationItem()
            {
                Id = 5,
                Name = "Svarbus klientas"
            });

            modelBuilder.Entity<Value>().HasData(new Value()
            {
                Id = 1,
                Name = " "
            }, new Value()
            {
                Id = 2,
                Name = " "
            }, new Value()
            {
                Id = 3,
                Name = " "
            }, new Value()
            {
                Id = 4,
                Name = " "
            }, new Value()
            {
                Id = 5,
                Name = " "
            }, new Value()
            {
                Id = 6,
                Name = "Taip"
            }, new Value()
            {
                Id = 7,
                Name = "Ne"
            }, new Value()
            {
                Id = 8,
                Name = "Metinis rangovas"
            }, new Value()
            {
                Id = 9,
                Name = "Mėnesinis rangovas"
            }, new Value()
            {
                Id = 10,
                Name = "Taip"
            }, new Value()
            {
                Id = 11,
                Name = "Ne"
            }, new Value()
            {
                Id = 12,
                Name = "Automatinis"
            }, new Value()
            {
                Id = 13,
                Name = "Rankinis"
            }, new Value()
            {
                Id = 14,
                Name = "Taip"
            }, new Value()
            {
                Id = 15,
                Name = "Ne"
            });
        }
    }
}
