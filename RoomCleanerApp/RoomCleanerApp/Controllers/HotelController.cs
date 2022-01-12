using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoomCleanerApp.Data;
using RoomCleanerApp.Dtos;
using RoomCleanerApp.Models;
using RoomCleanerApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Controllers
{
    public class HotelController : Controller
    {
        private DataContext _context;
        public HotelController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Hotel> hotelList = new List<Hotel> { };
            foreach (var hotel in _context.Hotels.Include(i => i.Rooms).ToList())
            {
                if (hotel.TotalRooms > hotel.Rooms.Where(i => i.HotelId == hotel.Id).Count())
                {
                    hotelList.Add(hotel);
                }
            }
            return View(hotelList);
        }

        public IActionResult HotelsBooking()
        {
            List<Hotel> hotelList = new List<Hotel> { };
            foreach (var hotel in _context.Hotels.Include(i => i.Rooms).ToList())
            {
                hotelList.Add(hotel);
            }
            return View(hotelList);
        }

        public IActionResult Update(int hotelid, string form)
        {
            var updateModel = new UpdateHotelDto()
            {
                CleanRooms = getRoomList(hotelid),
                MaxRooms = _context.Hotels.First(i => i.Id == hotelid).TotalRooms,
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


        public int getCleanerId()
        {
            var cleaners = _context.RoomsCleaners.Include(i => i.Cleaner).
                Where(i => i.Cleaned == false).GroupBy(i => new { i.CleanerId }, i => i, (key, g) =>
                new { cleanerId = key.CleanerId/*, Count = g.Count()*/ });
            int[] arr = cleaners.Select(i => i.cleanerId).ToArray();
            foreach (var cleaner in _context.Cleaners.ToList())
            {
                if (arr.Contains(cleaner.Id) == false)
                {
                    arr = arr.Concat(new int[] { cleaner.Id }).ToArray();
                }
            }
            Random _random = new Random();

            return arr[_random.Next(0, arr.Length)];
        }

        public IActionResult Release(int id, int hotelid)
        {
            Room room = new Room();
            room = _context.Rooms.First(i => i.Id == id);
            room.Booked = false;
            _context.Rooms.Update(room);

            RoomCleaner roomCleaner = new RoomCleaner
            {
                RoomId = id,
                CleanerId = getCleanerId()
            };
            _context.RoomsCleaners.Add(roomCleaner);

            _context.SaveChanges();

            var updateModel = new UpdateHotelDto()
            {
                CleanRooms = getRoomList(hotelid),
                MaxRooms = _context.Hotels.First(i => i.Id == hotelid).TotalRooms,
                HotelId = id,
            };
            return View("UpdateBookingRooms", updateModel);
        }

        [HttpPost]
        public IActionResult Create(UpdateHotelDto updateHotelDto)
        {
            Room room = new Room
            {
                Floor = updateHotelDto.Floor,
                HotelId = updateHotelDto.HotelId
            };
            _context.Rooms.Add(room);
            _context.SaveChanges();
            return RedirectToAction("Update", new { id = updateHotelDto.HotelId, form = "create" });
        }

    }
}
