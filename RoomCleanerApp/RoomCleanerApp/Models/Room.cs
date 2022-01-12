using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Models
{
    public class Room:Entity
    {
        public int Floor { get; set; }
        public int HotelId { get; set; }
        public bool Booked { get; set; } = false;
        public List<RoomCleaner> RoomCleaners { get; set; }

    }
}
