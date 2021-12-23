using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Dtos
{
    public class ShopItemTag
    {
        public ShopItem ShopItem { get; set; }
        public int ShopItemId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
