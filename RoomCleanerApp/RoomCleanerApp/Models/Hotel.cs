using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Models
{
    public class Hotel:Entity
    {
        public string City { get; set; }
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
