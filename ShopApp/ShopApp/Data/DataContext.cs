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
                   
        }
    }
}
