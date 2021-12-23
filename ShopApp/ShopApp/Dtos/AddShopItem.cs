using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos
{
    public class AddShopItem
    {
        public ShopItem ShopItem { get; set; }
        public List<Shop> AllShops { get; set; }
    }
}
