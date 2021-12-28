using Microsoft.EntityFrameworkCore;
using ShopApp.Dtos;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ShopItemTag> ShopItemTags { get; set; }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

       // public override Task SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
       // {
       //     UpdateSoftDeleteStatuses();
       //     return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
       // }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["isDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["isDeleted"] = true;
                        break;
                }
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ShopItemTag>().HasKey(bc => new { bc.TagId, bc.ShopItemId });
            modelBuilder.Entity<Shop>().Property<bool>("isDeleted");
            modelBuilder.Entity<Shop>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
            modelBuilder.Entity<ShopItem>().Property<bool>("isDeleted");
            modelBuilder.Entity<ShopItem>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
            modelBuilder.Entity<Tag>().Property<bool>("isDeleted");
            modelBuilder.Entity<Tag>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);
            //modelBuilder.Entity<ShopItemTag>().Property<bool>("isDeleted");
            //modelBuilder.Entity<ShopItemTag>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

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
