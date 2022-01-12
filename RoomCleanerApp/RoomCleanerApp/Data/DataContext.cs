using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Dtos;
using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCleaner> RoomsCleaners { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id=1,
                City = "Kaunas",
                Address = "Perkūno g. 1",
                TotalRooms = 5
            }, new Hotel
            {
                Id=2,
                City = "Kaunas",
                Address = "Jonavos g. 1",
                TotalRooms = 2
            });

        }
    }
}
