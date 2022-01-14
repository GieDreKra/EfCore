using RoomCleanerApp.Models;

namespace RoomCleanerApp.Dtos
{
    public class CreateCleanerDto
    {
        public List<CleanerDto> CleanerDtos { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CityId { get; set; }
        public List<City> AllCities { get; set; }

    }
}
