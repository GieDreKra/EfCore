using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    public class TagController : Controller
    {
        private DataContext _context;

        public TagController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Tag> tags = _context.Tags.ToList();
            return View(tags);
        }

        public IActionResult AddTag()
        {
            return View();
        }

        public IActionResult SendSubmitData(Tag model)
        {
            if (model.Name is not null)
            {
                object tag = new Tag { Name = model.Name };
                _context.Add(tag);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var items = _context.ShopItemTags.Where(tid => tid.TagId == id).ToList();
            foreach (var item in items)
            {
                item.isDeleted = true;
            }
            var tag = _context.Tags.Find(id);
            _context.Remove(tag);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var tag = _context.Tags.Find(id);
            return View(tag);
        }

        [HttpPost]
        public IActionResult Update(Tag model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Tags.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
