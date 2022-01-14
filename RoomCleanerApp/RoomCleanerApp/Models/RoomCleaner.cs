namespace RoomCleanerApp.Models
{
    public class RoomCleaner : Entity
    {
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int CleanerId { get; set; }
        public Cleaner Cleaner { get; set; }
        public bool Cleaned { get; set; } = false;
    }
}
