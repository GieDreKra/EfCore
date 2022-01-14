namespace RoomCleanerApp.Models
{
    public class Cleaner : Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CityId { get; set; }
        public List<RoomCleaner> RoomCleaners { get; set; }
    }
}
