using RoomCleanerApp.Models;

namespace RoomCleanerApp.Dtos
{
    public class UpdateHotelDto
    {
        public List<CleanRoom> CleanRooms { get; set; }

        public int MaxRooms { get; set; }

        public int Floor { get; set; }
        public int HotelId { get; set; }
        
    }
}
