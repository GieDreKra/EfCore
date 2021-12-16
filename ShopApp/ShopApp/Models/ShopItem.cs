using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class ShopItem : EntityName
    {
        public Shop Shop { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow;
    }
}
