using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Dtos
{
    public class CreateHotelDto
    {
        public List<HotelDto> HotelDtos { get; set; }
        public string Address { get; set; }
        public int TotalRooms { get; set; }
        public int CityId { get; set; }
        public List<City> AllCities { get; set; }
    }
}
