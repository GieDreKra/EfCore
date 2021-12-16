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
    public class ShopItemsController : Controller
    {
        private DataContext _context;

        public ShopItemsController(DataContext context)
        {
            _context = context; 
        }
        public IActionResult Index()
        {
            List<ShopItem> shops = _context.ShopsItems.Include(c=>c.Shop).ToList();

            //List<ShopItem> items = _context.ShopsItems.ToList(); 
            return View(shops);
        }
    }
}
