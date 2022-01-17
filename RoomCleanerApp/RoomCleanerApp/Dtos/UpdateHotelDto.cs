namespace RoomCleanerApp.Dtos
{
    public class UpdateHotelDto
    {
        public List<CleanRoom> CleanRooms { get; set; }
        public int MaxRooms { get; set; } = 0;
        public int Floor { get; set; }
        public int HotelId { get; set; }
        public string ErrorMessage { get; set; }
    }
}
