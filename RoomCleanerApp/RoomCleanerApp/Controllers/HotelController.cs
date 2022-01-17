using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Data;
using RoomCleanerApp.Dtos;
using RoomCleanerApp.Models;
using RoomCleanerApp.Repositories;

namespace RoomCleanerApp.Controllers
{
    public class HotelController : Controller
    {
        private DataContext _context;
        private HotelRepository _hotelRepository;

        public HotelController(DataContext context, HotelRepository hotelRepository)
        {
            _context = context;
            _hotelRepository = hotelRepository;
        }

        public IActionResult Index()
        {
            List<HotelDto> hotelList = new List<HotelDto> { };
            foreach (var hotel in _context.Hotels.Include(i => i.Rooms).ToList())
            {
                if (hotel.TotalRooms > hotel.Rooms.Where(i => i.HotelId == hotel.Id).Count())
                {
                    hotelList.Add(new HotelDto
                    {
                        Hotel = hotel,
                        City = _context.Cities
                        .Where(i => i.Id == hotel.CityId).First().Name
                    });
                }
            }
            var createHotelModel = new CreateHotelDto()
            {
                HotelDtos = hotelList,
                AllCities = _context.Cities.ToList()
            };
            return View(createHotelModel);
        }

        public IActionResult HotelsBooking()
        {
            List<HotelDto> hotelList = new List<HotelDto> { };
            foreach (var hotel in _context.Hotels.Include(i => i.Rooms).ToList())
            {
                hotelList.Add(new HotelDto
                {
                    Hotel = hotel,
                    City = _context.Cities
                    .Where(i => i.Id == hotel.CityId).First().Name
                });
            }
            return View(hotelList);
        }

        public IActionResult Update(int hotelid, string form)
        {
            var updateModel = new UpdateHotelDto()
            {
                CleanRooms = getRoomList(hotelid),
                MaxRooms = _context.Hotels.FirstOrDefault(i => i.Id == hotelid).TotalRooms,
                HotelId = hotelid
            };

            switch (form)
            {
                case "create":
                    return View(updateModel);
                case "book":
                    return View("UpdateBookingRooms", updateModel);
                default:
                    return View(updateModel);
            }
        }

        public IActionResult Book(int id, int hotelid)
        {
            Room room = new Room();
            room = _context.Rooms.First(i => i.Id == id);
            room.Booked = true;
            _context.Rooms.Update(room);
            _context.SaveChanges();

            var updateModel = new UpdateHotelDto()
            {
                CleanRooms = getRoomList(hotelid),
                MaxRooms = _context.Hotels.First(i => i.Id == hotelid).TotalRooms,
                HotelId = id
            };
            return View("UpdateBookingRooms", updateModel);
        }

        public List<CleanRoom> getRoomList(int hotelid)
        {
            List<CleanRoom> cleanRooms = new List<CleanRoom>() { };
            foreach (var r in _context.Rooms.Where(i => i.HotelId == hotelid).ToList())
            {
                var cleaned = false;
                if (_context.RoomsCleaners.Where(i => i.RoomId == r.Id && i.Cleaned == false).ToList().Count() == 0)
                {
                    cleaned = true;
                }
                cleanRooms.Add(new CleanRoom { Room = r, Cleaned = cleaned });
            }
            return cleanRooms;
        }

        public IActionResult Release(int id, int hotelid)
        {
            var errorMessage = _hotelRepository.setCleaner(id, hotelid, 0);
            var updateModel = new UpdateHotelDto()
            {
                CleanRooms = getRoomList(hotelid),
                MaxRooms = _context.Hotels.First(i => i.Id == hotelid).TotalRooms,
                HotelId = hotelid,
                ErrorMessage = errorMessage
            };
            return View("UpdateBookingRooms", updateModel);
        }

        [HttpPost]
        public IActionResult CreateRoom(UpdateHotelDto updateHotelDto)
        {
            Room room = new Room
            {
                Floor = updateHotelDto.Floor,
                HotelId = updateHotelDto.HotelId
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("Update", new { hotelid = updateHotelDto.HotelId, form = "create" });
        }

        [HttpPost]
        public IActionResult CreateHotel(CreateHotelDto createHotelDto)
        {
            Hotel hotel = new Hotel
            {
                Address = createHotelDto.Address,
                TotalRooms = createHotelDto.TotalRooms,
                CityId = createHotelDto.CityId
            };
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
