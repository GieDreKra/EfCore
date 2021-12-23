using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApp.Data;
using ShopApp.Dtos;
using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    public class ShopItemsController : Controller
    {
        private DataContext _context;

        public ShopItemsController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<ShopItem> shops = _context.ShopsItems
                .Include(c => c.Shop)
                .Include(t => t.ShopItemTags.Where(t => t.isDeleted == false))
                .ThenInclude(t => t.Tag)
                .Where(c => c.ShopId != null)
                .ToList();
            return View(shops);
        }

        public IActionResult Add()
        {
            var addShopItem = new AddShopItem()
            {
                ShopItem = new ShopItem(),
                AllShops = _context.Shops.ToList(),
                Tags = _context.Tags.ToList(),
            };
            return View(addShopItem);
        }

        [HttpPost]
        public IActionResult Add(AddShopItem model)
        {
            if (!ModelState.IsValid)
            {
                model.AllShops = _context.Shops.ToList();
                return View(model);
            }
            _context.ShopsItems.Add(model.ShopItem);
            _context.SaveChanges();
            foreach (var tagId in model.SelectedTagIds)
            {
                _context.ShopItemTags.Add(new ShopItemTag()
                {
                    TagId = tagId,
                    ShopItemId = model.ShopItem.Id,
                });
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _context.ShopsItems.Find(id);
            _context.Remove(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var addShopItem = new AddShopItem()
            {
                ShopItem = _context.ShopsItems.Find(id),
                AllShops = _context.Shops.ToList(),
                Tags = _context.Tags.ToList(),
            };
            return View(addShopItem);
        }

        [HttpPost]
        public IActionResult Update(int id, AddShopItem model)
        {
            if (!ModelState.IsValid)
            {
                model.AllShops = _context.Shops.ToList();
                return View(model);
            }
            model.ShopItem.Id = id;
            _context.ShopsItems.Update(model.ShopItem);
            _context.SaveChanges();
            List<ShopItemTag> shopItemTags = _context.ShopItemTags.Where(i => i.ShopItemId == id).ToList();
            foreach (var item in shopItemTags)
            {
                _context.Remove(item);
            }
            _context.SaveChanges();
            foreach (var tagId in model.SelectedTagIds)
            {
                if (_context.ShopItemTags.Where(i => i.ShopItemId == id & i.TagId == tagId & i.isDeleted == true).SingleOrDefault() != null)
                {
                    ShopItemTag item = _context.ShopItemTags.Where(i => i.ShopItemId == id & i.TagId == tagId & i.isDeleted == true).SingleOrDefault();
                    item.isDeleted = false;
                }
                else
                {
                    _context.ShopItemTags.Add(new ShopItemTag()
                    {
                        TagId = tagId,
                        ShopItemId = id,
                    });
                }
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
