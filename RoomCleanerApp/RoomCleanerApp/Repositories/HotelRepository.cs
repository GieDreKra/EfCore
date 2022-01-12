using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Data;
using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Repositories
{
    public class HotelRepository<Hotel> //where Hotel:Hotel
    {
        public DataContext _context;
     //   private DbSet<Hotel> _dbSet;
        public HotelRepository(DataContext context)
        {
            _context = context;
         //   _dbSet = _context.Set<Hotel>();
        }


        public virtual List<Hotel> getAll(){
            List<Hotel> hotelList = new List<Hotel> { };
            foreach( var hotel in _context.Hotels)
            {
                if (hotel.TotalRooms > _context.Rooms.Where(i=>i.HotelId==hotel.Id).Count())
                {
                  //  hotelList.Add();
                } 
            }
            return hotelList;
        }
    }
}
