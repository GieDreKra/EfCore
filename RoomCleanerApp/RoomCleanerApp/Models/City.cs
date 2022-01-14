namespace RoomCleanerApp.Models
{
    public class City : Entity
    {
        public string Name { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Cleaner> Cleaners { get; set; }
    }
}
