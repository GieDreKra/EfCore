using Microsoft.AspNetCore.Mvc;
using RoomCleanerApp.Data;
using RoomCleanerApp.Dtos;
using RoomCleanerApp.Models;
using RoomCleanerApp.Repositories;

namespace RoomCleanerApp.Controllers
{
    public class CleanerController : Controller
    {
        private DataContext _context;
        public HotelRepository _hotelRepository;

        public CleanerController(DataContext context, HotelRepository hotelRepository)
        {
            _context = context;
            _hotelRepository = hotelRepository;
        }
        public IActionResult Index()
        {
            List<CleanerDto> cleanerList = new List<CleanerDto> { };
            foreach (var cleaner in _context.Cleaners.ToList())
            {
                cleanerList.Add(new CleanerDto { Cleaner = cleaner, City = _context.Cities.Where(i => i.Id == cleaner.CityId).First().Name });
            }
            var createCleanerModel = new CreateCleanerDto()
            {
                CleanerDtos = cleanerList,
                AllCities = _context.Cities.ToList(),
            };
            return View(createCleanerModel);
        }

        public IActionResult Create(CreateCleanerDto createCleanerDto)
        {
            _context.Cleaners.Add(new Cleaner
            {
                Name = createCleanerDto.Name,
                Surname = createCleanerDto.Surname,
                CityId = createCleanerDto.CityId
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int cleanerid)
        {
            foreach (var roomCleaner in _context.RoomsCleaners
                .Where(i => i.CleanerId == cleanerid && i.Cleaned == false).ToList())
            {
                var newCleanerid = _hotelRepository.getCleanerId(
                    _context.Rooms.Where(i => i.Id == roomCleaner.RoomId).First().HotelId, cleanerid);
                if (newCleanerid != 0)
                {
                    roomCleaner.CleanerId = newCleanerid;
                    _context.Update(roomCleaner);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            _context.SaveChanges();

            foreach (var roomCleaner in _context.RoomsCleaners
               .Where(i => i.CleanerId == cleanerid).ToList())
            {
                roomCleaner.isDeleted = true;
                _context.Update(roomCleaner);
            }
            _context.SaveChanges();

            var cleaner = _context.Cleaners.Find(cleanerid);
            cleaner.isDeleted = true;
            _context.Update(cleaner);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public List<CleanRoom> getRoomList(int cleanerid)
        {
            List<CleanRoom> cleanRooms = new List<CleanRoom>() { };
            foreach (var r in _context.Rooms.ToList())
            {
                var listas = _context.RoomsCleaners.Where(i => i.RoomId == r.Id)
                    .Where(i => i.Cleaned == false)
                    .Where(i => i.CleanerId == cleanerid).ToList();
                if (_context.RoomsCleaners.Where(i => i.RoomId == r.Id)
                    .Where(i => i.Cleaned == false)
                    .Where(i => i.CleanerId == cleanerid).ToList().Count() != 0)
                {
                    cleanRooms.Add(new CleanRoom { Room = r, Cleaned = false });
                }
            }
            return cleanRooms;
        }

        public IActionResult Update(int cleanerid)
        {
            var updateModel = new UpdateCleanerDto()
            {
                CleanRooms = getRoomList(cleanerid),
                CleanerId = cleanerid
            };
            return View(updateModel);
        }

        public IActionResult Cleaned(int roomid, int cleanerid)
        {
            var cleanedRoom = _context.RoomsCleaners
                .Where(i => i.CleanerId == cleanerid && i.RoomId == roomid && i.Cleaned == false).First();
            cleanedRoom.Cleaned = true;
            _context.Update(cleanedRoom);
            _context.SaveChanges();

            var updateModel = new UpdateCleanerDto()
            {
                CleanRooms = getRoomList(cleanerid),
                CleanerId = cleanerid
            };
            return View("Update", updateModel);
        }
    }
}
