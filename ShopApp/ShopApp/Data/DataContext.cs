using Microsoft.EntityFrameworkCore;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
    : base(options)
        {
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopItem> ShopsItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop()
            {
                Id=1,
                Name = "Shop1"
            }, new Shop()
            {
                Id = 2,
                Name = "Shop2"
            });
            modelBuilder.Entity<ShopItem>().HasData(new ShopItem()
            {
                Id = 1,
                Name = "ShopItem1",
                ExpiryDate = DateTime.Now.AddDays(10)
            }, new ShopItem()
            {
                Id = 2,
                Name = "ShopItem2",
                ExpiryDate = DateTime.Now.AddDays(100)
            }, new ShopItem()
            {
                Id = 3,
                Name = "ShopItem3",
                ExpiryDate = DateTime.Now.AddDays(10)
            },new ShopItem()
            {
                Id = 4,
                Name = "ShopItem4",
                ExpiryDate = DateTime.Now.AddDays(100)
            }, new ShopItem()
            {
                Id = 5,
                Name = "ShopItem5",
                ExpiryDate = DateTime.Now.AddDays(10)
            }
            );
        }
    }
}
