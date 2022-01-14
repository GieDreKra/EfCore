using RoomCleanerApp.Models;

namespace RoomCleanerApp.Dtos
{
    public class CleanRoom
    {
        public Room Room { get; set; }
        public bool Cleaned { get; set; }
    }
}
