namespace RoomCleanerApp.Models
{
    public class Hotel : Entity
    {
        public int CityId { get; set; }
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public List<Room> Rooms { get; set; }
    }
}
