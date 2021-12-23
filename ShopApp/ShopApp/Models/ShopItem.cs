using Microsoft.AspNetCore.Mvc.Rendering;
using ShopApp.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class ShopItem : EntityDeleted
    {
        public Shop Shop { get; set; }
        public int? ShopId { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;

        public List<ShopItemTag> ShopItemTags { get; set; }
    }
}
