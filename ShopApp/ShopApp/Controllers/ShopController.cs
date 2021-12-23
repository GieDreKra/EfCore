using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp
{
    public class ShopController : Controller
    {
        private DataContext _context;

        public ShopController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Shop> shops = _context.Shops.Include(c => c.Items).ToList();
            return View(shops);
        }

        public IActionResult AddShop()
        {
            return View();
        }

        public IActionResult SendSubmitData(Shop model)
        {
            if (model.Name is not null)
            {
                object shop = new Shop { Name = model.Name };
                _context.Add(shop);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var items = _context.ShopsItems.Where(sid => sid.ShopId == id).ToList();
            foreach (var item in items)
            {
                item.ShopId = null;
            }
            var shop = _context.Shops.Find(id);
            _context.Remove(shop);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var shop = _context.Shops.Find(id);
            return View(shop);
        }

        [HttpPost]
        public IActionResult Update(Shop model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _context.Shops.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
