using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Data;
using RoomCleanerApp.Models;

namespace RoomCleanerApp.Repositories
{
    public class HotelRepository
    {
        protected DataContext _context;

        public HotelRepository(DataContext context)
        {
            _context = context;
        }

        public int getCleanerId(int hotelid, int cleaneridExclude)
        {
            var hotelCityId = _context.Hotels.Find(hotelid).CityId;

            var cleaners = _context.RoomsCleaners.Include(i => i.Cleaner)
                .Where(i => i.Cleaned == false)
                .Where(i => i.Cleaner.CityId == hotelCityId)
                .Where(i => i.Cleaner.Id != cleaneridExclude)
                .GroupBy(i => new { i.CleanerId }, i => i, (key, g) =>
                    new { cleanerId = key.CleanerId, Count = g.Count() })
                .Where(i => i.Count < 5);

            int[] arr = cleaners.Select(i => i.cleanerId).ToArray();

            foreach (var cleaner in _context.Cleaners.ToList())
            {
                if (_context.RoomsCleaners.Where(i => i.CleanerId == cleaner.Id && i.Cleaned == false).Count() == 0)
                {
                    if ((arr.Contains(cleaner.Id) == false) &&
                        (cleaner.CityId == hotelCityId) &&
                        (cleaner.Id != cleaneridExclude))
                    {
                        arr = arr.Concat(new int[] { cleaner.Id }).ToArray();
                    }
                }
            }
            if (arr.Length == 0)
            {
                return 0;
            }
            else
            {
                Random _random = new Random();
                return arr[_random.Next(0, arr.Length)];
            }
        }

        public string setCleaner(int id, int hotelid, int cleaneridExclude)
        {
            var cleanerid = getCleanerId(hotelid, cleaneridExclude);
            string errorMessage = "";
            if (cleanerid != 0)
            {
                Room room = new Room();
                room = _context.Rooms.Find(id);
                room.Booked = false;
                _context.Rooms.Update(room);

                RoomCleaner roomCleaner = new RoomCleaner
                {
                    RoomId = id,
                    CleanerId = cleanerid
                };
                _context.RoomsCleaners.Add(roomCleaner);

                _context.SaveChanges();
            }
            else { errorMessage = "No available cleaner found"; }
            return errorMessage;
        }
    }
}
