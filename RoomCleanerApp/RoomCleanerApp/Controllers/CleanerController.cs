using Microsoft.AspNetCore.Mvc;
using RoomCleanerApp.Data;
using RoomCleanerApp.Dtos;
using RoomCleanerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomCleanerApp.Controllers
{
    public class CleanerController : Controller
    {
        private DataContext _context;
        public CleanerController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var createCleanerModel = new CreateCleanerDto()
            {
                Cleaners = _context.Cleaners.ToList(),
            };
            return View(createCleanerModel);
        }

        public IActionResult Create(CreateCleanerDto createCleanerDto)
        {
            _context.Cleaners.Add(new Cleaner
            {
                Name = createCleanerDto.Name,
                Surname = createCleanerDto.Surname,
                City = createCleanerDto.City
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _context.Remove(_context.Cleaners.First(i => i.Id == id));
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
            var cleanedRoom = _context.RoomsCleaners.Where(i => i.CleanerId == cleanerid && i.RoomId == roomid)
                .First();
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
