﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Models
{
    public class Shop : EntityName
    {
        public List<ShopItem> Items { get; set; }
    }
}