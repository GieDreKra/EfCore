using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Models;

namespace RoomCleanerApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Cleaner> Cleaners { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomCleaner> RoomsCleaners { get; set; }
        public DbSet<City> Cities { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hotel>().Property<bool>("isDeleted");
            modelBuilder.Entity<Hotel>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            modelBuilder.Entity<Room>().Property<bool>("isDeleted");
            modelBuilder.Entity<Room>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            modelBuilder.Entity<Cleaner>().Property<bool>("isDeleted");
            modelBuilder.Entity<Cleaner>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);

            modelBuilder.Entity<RoomCleaner>().Property<bool>("isDeleted");
            modelBuilder.Entity<RoomCleaner>().HasQueryFilter(m => EF.Property<bool>(m, "isDeleted") == false);


            modelBuilder.Entity<City>().HasData(
           new City
           {
               Id = 1,
               Name = "Kaunas",
           }, new City
           {
               Id = 2,
               Name = "Vilnius",
           });

            modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                CityId = 1,
                Address = "Perkūno g. 1",
                TotalRooms = 5
            }, new Hotel
            {
                Id = 2,
                CityId = 1,
                Address = "Jonavos g. 1",
                TotalRooms = 2
            },
            new Hotel
            {
                Id = 3,
                CityId = 2,
                Address = "Gedimino g. 1",
                TotalRooms = 3
            });
        }
    }
}
